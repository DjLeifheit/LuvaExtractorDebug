Imports System.Data.Common
Imports System.IO

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FilterHinzufügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StandardPfadFestlegenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PfadZurDatenbankFestlegenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog2 = New System.Windows.Forms.FolderBrowserDialog()
        Me.BasisPfadZumPDFOrdnerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(349, 190)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(131, 56)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Ordner wählen"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 305)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(131, 56)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FilterHinzufügenToolStripMenuItem, Me.SetupToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(676, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FilterHinzufügenToolStripMenuItem
        '
        Me.FilterHinzufügenToolStripMenuItem.Name = "FilterHinzufügenToolStripMenuItem"
        Me.FilterHinzufügenToolStripMenuItem.Size = New System.Drawing.Size(108, 20)
        Me.FilterHinzufügenToolStripMenuItem.Text = "Filter hinzufügen"
        '
        'SetupToolStripMenuItem
        '
        Me.SetupToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StandardPfadFestlegenToolStripMenuItem, Me.PfadZurDatenbankFestlegenToolStripMenuItem, Me.BasisPfadZumPDFOrdnerToolStripMenuItem})
        Me.SetupToolStripMenuItem.Name = "SetupToolStripMenuItem"
        Me.SetupToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.SetupToolStripMenuItem.Text = "Setup "
        '
        'StandardPfadFestlegenToolStripMenuItem
        '
        Me.StandardPfadFestlegenToolStripMenuItem.Name = "StandardPfadFestlegenToolStripMenuItem"
        Me.StandardPfadFestlegenToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.StandardPfadFestlegenToolStripMenuItem.Text = "Speicher Pfad Festlegen"
        '
        'PfadZurDatenbankFestlegenToolStripMenuItem
        '
        Me.PfadZurDatenbankFestlegenToolStripMenuItem.Name = "PfadZurDatenbankFestlegenToolStripMenuItem"
        Me.PfadZurDatenbankFestlegenToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.PfadZurDatenbankFestlegenToolStripMenuItem.Text = "Pfad zur Datenbank Festlegen"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(199, 212)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Bitte PDF Ordner eingeben"
        '
        'BasisPfadZumPDFOrdnerToolStripMenuItem
        '
        Me.BasisPfadZumPDFOrdnerToolStripMenuItem.Name = "BasisPfadZumPDFOrdnerToolStripMenuItem"
        Me.BasisPfadZumPDFOrdnerToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.BasisPfadZumPDFOrdnerToolStripMenuItem.Text = "Basis Pfad zum PDF Ordner"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 445)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FilterHinzufügenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StandardPfadFestlegenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PfadZurDatenbankFestlegenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents FolderBrowserDialog2 As FolderBrowserDialog
    Friend WithEvents BasisPfadZumPDFOrdnerToolStripMenuItem As ToolStripMenuItem
End Class
