<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.AdressePDF = New System.Windows.Forms.TextBox()
        Me.AdressenCombo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.AdresseTab = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'AdressePDF
        '
        Me.AdressePDF.Location = New System.Drawing.Point(23, 98)
        Me.AdressePDF.Multiline = True
        Me.AdressePDF.Name = "AdressePDF"
        Me.AdressePDF.ReadOnly = True
        Me.AdressePDF.Size = New System.Drawing.Size(281, 294)
        Me.AdressePDF.TabIndex = 0
        '
        'AdressenCombo
        '
        Me.AdressenCombo.FormattingEnabled = True
        Me.AdressenCombo.Location = New System.Drawing.Point(376, 111)
        Me.AdressenCombo.Name = "AdressenCombo"
        Me.AdressenCombo.Size = New System.Drawing.Size(270, 21)
        Me.AdressenCombo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(373, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(166, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Wähle den Richtigen Eintrag aus "
        '
        'AdresseTab
        '
        Me.AdresseTab.Location = New System.Drawing.Point(376, 173)
        Me.AdresseTab.Multiline = True
        Me.AdresseTab.Name = "AdresseTab"
        Me.AdresseTab.ReadOnly = True
        Me.AdresseTab.Size = New System.Drawing.Size(270, 219)
        Me.AdresseTab.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Adresse der PDF"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(376, 138)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(270, 29)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Auswählen"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.AdresseTab)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.AdressenCombo)
        Me.Controls.Add(Me.AdressePDF)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AdressePDF As TextBox
    Friend WithEvents AdressenCombo As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents AdresseTab As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
End Class
