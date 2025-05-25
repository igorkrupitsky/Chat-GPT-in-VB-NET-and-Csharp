<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGPTChat
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.txtQuestion = New System.Windows.Forms.TextBox()
        Me.txtAnswer = New System.Windows.Forms.TextBox()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTemperature = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMaxTokens = New System.Windows.Forms.TextBox()
        Me.cbModel = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbVoice = New System.Windows.Forms.ComboBox()
        Me.lblVoice = New System.Windows.Forms.Label()
        Me.chkListen = New System.Windows.Forms.CheckBox()
        Me.chkMute = New System.Windows.Forms.CheckBox()
        Me.lblSpeech = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnSend
        '
        Me.btnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSend.Location = New System.Drawing.Point(3, 410)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(123, 55)
        Me.btnSend.TabIndex = 0
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'txtQuestion
        '
        Me.txtQuestion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQuestion.Location = New System.Drawing.Point(3, 511)
        Me.txtQuestion.Multiline = True
        Me.txtQuestion.Name = "txtQuestion"
        Me.txtQuestion.Size = New System.Drawing.Size(1177, 130)
        Me.txtQuestion.TabIndex = 1
        '
        'txtAnswer
        '
        Me.txtAnswer.AcceptsReturn = True
        Me.txtAnswer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAnswer.Location = New System.Drawing.Point(3, 12)
        Me.txtAnswer.Multiline = True
        Me.txtAnswer.Name = "txtAnswer"
        Me.txtAnswer.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtAnswer.Size = New System.Drawing.Size(1177, 392)
        Me.txtAnswer.TabIndex = 2
        '
        'txtUserID
        '
        Me.txtUserID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtUserID.Location = New System.Drawing.Point(229, 430)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(100, 26)
        Me.txtUserID.TabIndex = 3
        Me.txtUserID.Text = "1"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(159, 433)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "User ID"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(359, 433)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Randomness"
        '
        'txtTemperature
        '
        Me.txtTemperature.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTemperature.Location = New System.Drawing.Point(469, 430)
        Me.txtTemperature.Name = "txtTemperature"
        Me.txtTemperature.Size = New System.Drawing.Size(100, 26)
        Me.txtTemperature.TabIndex = 5
        Me.txtTemperature.Text = "0.5"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(601, 433)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 20)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Max tokens"
        '
        'txtMaxTokens
        '
        Me.txtMaxTokens.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMaxTokens.Location = New System.Drawing.Point(697, 430)
        Me.txtMaxTokens.Name = "txtMaxTokens"
        Me.txtMaxTokens.Size = New System.Drawing.Size(100, 26)
        Me.txtMaxTokens.TabIndex = 7
        Me.txtMaxTokens.Text = "2048"
        '
        'cbModel
        '
        Me.cbModel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbModel.FormattingEnabled = True
        Me.cbModel.Items.AddRange(New Object() {"text-davinci-003", "text-davinci-002", "code-davinci-002", "gpt-3.5-turbo", "gpt-3.5-turbo-0301"})
        Me.cbModel.Location = New System.Drawing.Point(890, 425)
        Me.cbModel.Name = "cbModel"
        Me.cbModel.Size = New System.Drawing.Size(291, 28)
        Me.cbModel.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(832, 430)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Model"
        '
        'cbVoice
        '
        Me.cbVoice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbVoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVoice.FormattingEnabled = True
        Me.cbVoice.Location = New System.Drawing.Point(890, 468)
        Me.cbVoice.Name = "cbVoice"
        Me.cbVoice.Size = New System.Drawing.Size(291, 28)
        Me.cbVoice.TabIndex = 11
        '
        'lblVoice
        '
        Me.lblVoice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblVoice.AutoSize = True
        Me.lblVoice.Location = New System.Drawing.Point(832, 471)
        Me.lblVoice.Name = "lblVoice"
        Me.lblVoice.Size = New System.Drawing.Size(49, 20)
        Me.lblVoice.TabIndex = 12
        Me.lblVoice.Text = "Voice"
        '
        'chkListen
        '
        Me.chkListen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkListen.AutoSize = True
        Me.chkListen.Location = New System.Drawing.Point(469, 472)
        Me.chkListen.Name = "chkListen"
        Me.chkListen.Size = New System.Drawing.Size(78, 24)
        Me.chkListen.TabIndex = 13
        Me.chkListen.Text = "Listen"
        Me.chkListen.UseVisualStyleBackColor = True
        '
        'chkMute
        '
        Me.chkMute.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkMute.AutoSize = True
        Me.chkMute.Location = New System.Drawing.Point(697, 471)
        Me.chkMute.Name = "chkMute"
        Me.chkMute.Size = New System.Drawing.Size(71, 24)
        Me.chkMute.TabIndex = 14
        Me.chkMute.Text = "Mute"
        Me.chkMute.UseVisualStyleBackColor = True
        '
        'lblSpeech
        '
        Me.lblSpeech.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSpeech.AutoSize = True
        Me.lblSpeech.Location = New System.Drawing.Point(12, 478)
        Me.lblSpeech.Name = "lblSpeech"
        Me.lblSpeech.Size = New System.Drawing.Size(73, 20)
        Me.lblSpeech.TabIndex = 15
        Me.lblSpeech.Text = "speech..."
        Me.lblSpeech.Visible = False
        '
        'frmGPTChat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1192, 653)
        Me.Controls.Add(Me.lblSpeech)
        Me.Controls.Add(Me.chkMute)
        Me.Controls.Add(Me.chkListen)
        Me.Controls.Add(Me.lblVoice)
        Me.Controls.Add(Me.cbVoice)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbModel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMaxTokens)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTemperature)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUserID)
        Me.Controls.Add(Me.txtAnswer)
        Me.Controls.Add(Me.txtQuestion)
        Me.Controls.Add(Me.btnSend)
        Me.Name = "frmGPTChat"
        Me.Text = "GPT Chat"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSend As Button
    Friend WithEvents txtQuestion As TextBox
    Friend WithEvents txtAnswer As TextBox
    Friend WithEvents txtUserID As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTemperature As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtMaxTokens As TextBox
    Friend WithEvents cbModel As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cbVoice As ComboBox
    Friend WithEvents lblVoice As Label
    Friend WithEvents chkListen As CheckBox
    Friend WithEvents chkMute As CheckBox
    Friend WithEvents lblSpeech As Label
End Class
