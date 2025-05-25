Imports System.Net
Imports System.IO
Imports System.Configuration
Imports System.Security.Cryptography
Imports System.Speech.Synthesis
Imports System.Speech.Recognition
Imports System.Numerics

Public Class frmGPTChat

    Dim OPENAI_API_KEY As String = "" 'https://beta.openai.com/account/api-keys
    Dim oSpeechRecognitionEngine As SpeechRecognitionEngine = Nothing
    Dim oSpeechSynthesizer As System.Speech.Synthesis.SpeechSynthesizer = Nothing

    Private Sub frmGPTChat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim oAppSettingsReader As New AppSettingsReader()
        Dim sApiKey As String = oAppSettingsReader.GetValue("OPENAI_API_KEY", GetType(String)) & ""

        If sApiKey = "" Then
            MsgBox("Please enter your OpenAI API key in the App.config file.")
            End
        Else
            OPENAI_API_KEY = sApiKey
        End If

        'SetModels()
        cbModel.SelectedIndex = 0

        cbVoice.Items.Clear()
        Dim synth As New SpeechSynthesizer()
        For Each voice In synth.GetInstalledVoices()
            cbVoice.Items.Add(voice.VoiceInfo.Name)
        Next
        cbVoice.SelectedIndex = 0

    End Sub

    Private Sub chkListen_CheckedChanged(sender As Object, e As EventArgs) Handles chkListen.CheckedChanged
        If chkListen.Checked Then
            lblSpeech.Text = ""
            lblSpeech.Visible = True
            SpeechToText()
        Else
            oSpeechRecognitionEngine.RecognizeAsyncStop()
            lblSpeech.Visible = False
        End If
    End Sub
    Private Sub chkMute_CheckedChanged(sender As Object, e As EventArgs) Handles chkMute.CheckedChanged

        If chkMute.Checked Then
            lblVoice.Visible = False
            cbVoice.Visible = False
        Else
            lblVoice.Visible = True
            cbVoice.Visible = True
        End If

    End Sub

    Private Sub SpeechToText()

        If oSpeechRecognitionEngine IsNot Nothing Then
            oSpeechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple)
            Exit Sub
        End If

        oSpeechRecognitionEngine = New SpeechRecognitionEngine(New System.Globalization.CultureInfo("en-US"))
        oSpeechRecognitionEngine.LoadGrammar(New DictationGrammar())
        AddHandler oSpeechRecognitionEngine.SpeechRecognized, AddressOf OnSpeechRecognized
        AddHandler oSpeechRecognitionEngine.SpeechHypothesized, AddressOf OnSpeechHypothesized
        oSpeechRecognitionEngine.SetInputToDefaultAudioDevice()
        oSpeechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple)
    End Sub

    Private Sub OnSpeechRecognized(sender As Object, e As SpeechRecognizedEventArgs)
        lblSpeech.Text = "" 'Reset Hypothesized text

        If txtQuestion.Text <> "" Then
            txtQuestion.Text += vbCrLf
        End If

        Dim text As String = e.Result.Text
        txtQuestion.Text += text
    End Sub

    Private Sub OnSpeechHypothesized(sender As Object, e As SpeechHypothesizedEventArgs)
        Dim text As String = e.Result.Text
        lblSpeech.Text = text
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click

        Dim sQuestion As String = txtQuestion.Text
        If sQuestion = "" Then
            MsgBox("Type in your question!")
            txtQuestion.Focus()
            Exit Sub
        End If

        If txtAnswer.Text <> "" Then
            txtAnswer.AppendText(vbCrLf)
        End If

        txtAnswer.AppendText("Me: " & sQuestion & vbCrLf)
        txtQuestion.Text = ""

        Try
            Dim sAnswer As String = SendMsg(sQuestion)
            txtAnswer.AppendText("Chat GPT: " & Trim(Replace(sAnswer, vbLf, vbCrLf)))
            SpeechToText(sAnswer)
        Catch ex As Exception
            txtAnswer.AppendText("Error: " & ex.Message)
        End Try

    End Sub

    Sub SpeechToText(ByVal s As String)

        If chkMute.Checked Then
            Exit Sub
        End If

        If oSpeechSynthesizer Is Nothing Then
            oSpeechSynthesizer = New System.Speech.Synthesis.SpeechSynthesizer()
            oSpeechSynthesizer.SetOutputToDefaultAudioDevice()
        End If

        If cbVoice.Text <> "" Then
            oSpeechSynthesizer.SelectVoice(cbVoice.Text)
        End If

        oSpeechSynthesizer.Speak(s)

    End Sub

    Function SendMsg(ByVal sQuestion As String)

        System.Net.ServicePointManager.SecurityProtocol =
           System.Net.SecurityProtocolType.Ssl3 Or
           System.Net.SecurityProtocolType.Tls12 Or
           System.Net.SecurityProtocolType.Tls11 Or
           System.Net.SecurityProtocolType.Tls

        Dim sModel As String = cbModel.Text 'text-davinci-002, text-davinci-003
        Dim sUrl As String = "https://api.openai.com/v1/completions"

        If sModel.IndexOf("gpt-3.5-turbo") <> -1 Then
            'Chat GTP 4 https://openai.com/research/gpt-4
            sUrl = "https://api.openai.com/v1/chat/completions"
        End If

        Dim request As HttpWebRequest = WebRequest.Create(sUrl)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.Headers.Add("Authorization", "Bearer " & OPENAI_API_KEY)

        Dim iMaxTokens As Integer = txtMaxTokens.Text '2048

        Dim dTemperature As Double = txtTemperature.Text '0.5
        If dTemperature < 0 Or dTemperature > 1 Then
            MsgBox("Randomness has to be between 0 and 1 with higher values resulting in more random text")
            Return ""
        End If

        Dim sUserId As String = txtUserID.Text '1

        'https://beta.openai.com/docs/api-reference/completions/create
        Dim data As String = ""

        If sModel.IndexOf("gpt-3.5-turbo") <> -1 Then
            'Chat GTP 4
            data = "{"
            data += " ""model"":""" & sModel & ""","
            data += " ""messages"": [{""role"":""user"", ""content"": """ & PadQuotes(sQuestion) & """}]"
            data += "}"
        Else
            data = "{"
            data += " ""model"":""" & sModel & ""","
            data += " ""prompt"": """ & PadQuotes(sQuestion) & ""","
            data += " ""max_tokens"": " & iMaxTokens & ","
            data += " ""user"": """ & sUserId & """, "
            data += " ""temperature"": " & dTemperature & ", "
            data += " ""frequency_penalty"": 0.0" & ", " 'Number between -2.0 and 2.0  Positive value decrease the model's likelihood to repeat the same line verbatim.
            data += " ""presence_penalty"": 0.0" & ", " ' Number between -2.0 and 2.0. Positive values increase the model's likelihood to talk about new topics.
            data += " ""stop"": [""#"", "";""]" 'Up to 4 sequences where the API will stop generating further tokens. The returned text will not contain the stop sequence.
            data += "}"
        End If

        Using streamWriter As New StreamWriter(request.GetRequestStream())
            streamWriter.Write(data)
            streamWriter.Flush()
            streamWriter.Close()
        End Using

        Dim response As HttpWebResponse = request.GetResponse()
        Dim streamReader As New StreamReader(response.GetResponseStream())
        Dim sJson As String = streamReader.ReadToEnd()
        'Return sJson

        Dim oJavaScriptSerializer As New System.Web.Script.Serialization.JavaScriptSerializer
        Dim oJson As Hashtable = oJavaScriptSerializer.Deserialize(Of Hashtable)(sJson)
        Dim sResponse As String = ""

        If sModel.IndexOf("gpt-3.5-turbo") <> -1 Then
            'Chat GTP 4
            sResponse = oJson("choices")(0)("message")("content")
        Else
            sResponse = oJson("choices")(0)("text")
        End If

        Return sResponse
    End Function

    Private Sub SetModels()
        'https://beta.openai.com/docs/models/gpt-3

        System.Net.ServicePointManager.SecurityProtocol =
           System.Net.SecurityProtocolType.Ssl3 Or
           System.Net.SecurityProtocolType.Tls12 Or
           System.Net.SecurityProtocolType.Tls11 Or
           System.Net.SecurityProtocolType.Tls

        Dim apiEndpoint As String = "https://api.openai.com/v1/models"
        Dim request As HttpWebRequest = WebRequest.Create(apiEndpoint)
        request.Method = "GET"
        request.ContentType = "application/json"
        request.Headers.Add("Authorization", "Bearer " & OPENAI_API_KEY)

        Dim response As HttpWebResponse = request.GetResponse()
        Dim streamReader As New StreamReader(response.GetResponseStream())
        Dim sJson As String = streamReader.ReadToEnd()
        'Return sJson

        cbModel.Items.Clear()

        'Dim sIds As String = ""
        Dim oSortedList As SortedList = New SortedList()
        Dim oJavaScriptSerializer As New System.Web.Script.Serialization.JavaScriptSerializer
        Dim oJson As Hashtable = oJavaScriptSerializer.Deserialize(Of Hashtable)(sJson)
        Dim oList As Object() = oJson("data")
        For i As Integer = 0 To oList.Length - 1
            Dim sId As String = oList(i)("id")
            'Dim sCreated As String = oList(i)("created")
            'Dim sObject As String = oList(i)("object")
            'Dim sOwned_by As String = oList(i)("owned_by")
            'Dim oPermission As Hashtable = oList(i)("permission")(0)
            'If sIds <> "" Then sIds += vbCrLf
            'sIds += sCreated & vbTab & sId
            oSortedList.Add(sId, sId)
        Next

        For Each oItem As DictionaryEntry In oSortedList
            cbModel.Items.Add(oItem.Key)
        Next


    End Sub

    Private Function PadQuotes(ByVal s As String) As String

        If s.IndexOf("\") <> -1 Then
            s = Replace(s, "\", "\\")
        End If

        If s.IndexOf(vbCrLf) <> -1 Then
            s = Replace(s, vbCrLf, "\n")
        End If

        If s.IndexOf(vbCr) <> -1 Then
            s = Replace(s, vbCr, "\r")
        End If

        If s.IndexOf(vbLf) <> -1 Then
            s = Replace(s, vbLf, "\f")
        End If

        If s.IndexOf(vbTab) <> -1 Then
            s = Replace(s, vbTab, "\t")
        End If

        If s.IndexOf("""") = -1 Then
            Return s
        Else
            Return Replace(s, """", "\""")
        End If
    End Function

End Class
