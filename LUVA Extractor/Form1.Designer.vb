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
        Me.SuchkriteriumHinzufügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SuchkriteriumEntfernenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StandardPfadFestlegenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PfadZurDatenbankFestlegenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BasisPfadZumPDFOrdnerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeschreibungToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog2 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.ThumbnailEx1 = New GdPicture14.ThumbnailEx()
        Me.Date1 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ProgressBarLabel = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(533, 377)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(131, 56)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Ordner wählen"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 377)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(131, 56)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Beenden"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FilterHinzufügenToolStripMenuItem, Me.SetupToolStripMenuItem, Me.BeschreibungToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(676, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FilterHinzufügenToolStripMenuItem
        '
        Me.FilterHinzufügenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SuchkriteriumHinzufügenToolStripMenuItem, Me.SuchkriteriumEntfernenToolStripMenuItem})
        Me.FilterHinzufügenToolStripMenuItem.Name = "FilterHinzufügenToolStripMenuItem"
        Me.FilterHinzufügenToolStripMenuItem.Size = New System.Drawing.Size(147, 20)
        Me.FilterHinzufügenToolStripMenuItem.Text = "Suchkriterien bearbeiten"
        '
        'SuchkriteriumHinzufügenToolStripMenuItem
        '
        Me.SuchkriteriumHinzufügenToolStripMenuItem.Name = "SuchkriteriumHinzufügenToolStripMenuItem"
        Me.SuchkriteriumHinzufügenToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.SuchkriteriumHinzufügenToolStripMenuItem.Text = "Suchkriterium hinzufügen"
        '
        'SuchkriteriumEntfernenToolStripMenuItem
        '
        Me.SuchkriteriumEntfernenToolStripMenuItem.Name = "SuchkriteriumEntfernenToolStripMenuItem"
        Me.SuchkriteriumEntfernenToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.SuchkriteriumEntfernenToolStripMenuItem.Text = "Suchkriterium entfernen"
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
        'BasisPfadZumPDFOrdnerToolStripMenuItem
        '
        Me.BasisPfadZumPDFOrdnerToolStripMenuItem.Name = "BasisPfadZumPDFOrdnerToolStripMenuItem"
        Me.BasisPfadZumPDFOrdnerToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.BasisPfadZumPDFOrdnerToolStripMenuItem.Text = "Basis Pfad zum PDF Ordner"
        '
        'BeschreibungToolStripMenuItem
        '
        Me.BeschreibungToolStripMenuItem.Name = "BeschreibungToolStripMenuItem"
        Me.BeschreibungToolStripMenuItem.Size = New System.Drawing.Size(91, 20)
        Me.BeschreibungToolStripMenuItem.Text = "Beschreibung"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(384, 399)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Bitte PDF Ordner eingeben"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(115, 182)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(158, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Anzahl PDF Dateien "
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(115, 208)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Spezifität"
        Me.Label3.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(119, 234)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(398, 52)
        Me.TextBox1.TabIndex = 6
        Me.TextBox1.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(279, 182)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(238, 20)
        Me.TextBox2.TabIndex = 7
        Me.TextBox2.Visible = False
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(279, 208)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(238, 20)
        Me.TextBox3.TabIndex = 8
        Me.TextBox3.Visible = False
        '
        'ThumbnailEx1
        '
        Me.ThumbnailEx1.AllowDropFiles = False
        Me.ThumbnailEx1.AllowMoveItems = False
        Me.ThumbnailEx1.BackColor = System.Drawing.SystemColors.Control
        Me.ThumbnailEx1.CheckBoxes = False
        Me.ThumbnailEx1.CheckBoxesMarginLeft = 0
        Me.ThumbnailEx1.CheckBoxesMarginTop = 0
        Me.ThumbnailEx1.DefaultItemCheckState = False
        Me.ThumbnailEx1.DefaultItemTextPrefix = ""
        Me.ThumbnailEx1.DisplayAnnotations = True
        Me.ThumbnailEx1.EnableDropShadow = True
        Me.ThumbnailEx1.HorizontalTextAlignment = GdPicture14.TextAlignment.TextAlignmentCenter
        Me.ThumbnailEx1.HotTracking = False
        Me.ThumbnailEx1.Location = New System.Drawing.Point(474, 51)
        Me.ThumbnailEx1.LockGdViewerEvents = False
        Me.ThumbnailEx1.MultiSelect = False
        Me.ThumbnailEx1.Name = "ThumbnailEx1"
        Me.ThumbnailEx1.OwnDrop = False
        Me.ThumbnailEx1.PauseThumbsLoading = False
        Me.ThumbnailEx1.PdfIncreaseTextContrast = False
        Me.ThumbnailEx1.PreloadAllItems = True
        Me.ThumbnailEx1.RotateExif = True
        Me.ThumbnailEx1.SelectedThumbnailBackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.ThumbnailEx1.SelectedThumbnailBackColorAlpha = 100
        Me.ThumbnailEx1.ShowText = True
        Me.ThumbnailEx1.Size = New System.Drawing.Size(128, 128)
        Me.ThumbnailEx1.TabIndex = 0
        Me.ThumbnailEx1.TextMarginLeft = 0
        Me.ThumbnailEx1.TextMarginTop = 0
        Me.ThumbnailEx1.ThumbnailAlignment = GdPicture14.ThumbnailAlignment.ThumbnailAlignmentVertical
        Me.ThumbnailEx1.ThumbnailBackColor = System.Drawing.Color.Transparent
        Me.ThumbnailEx1.ThumbnailBorder = False
        Me.ThumbnailEx1.ThumbnailForeColor = System.Drawing.Color.Black
        Me.ThumbnailEx1.ThumbnailSize = New System.Drawing.Size(128, 128)
        Me.ThumbnailEx1.ThumbnailSpacing = New System.Drawing.Size(0, 0)
        Me.ThumbnailEx1.VerticalTextAlignment = GdPicture14.TextAlignment.TextAlignmentCenter
        '
        'Date1
        '
        Me.Date1.AutoSize = True
        Me.Date1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Date1.Location = New System.Drawing.Point(603, 9)
        Me.Date1.Name = "Date1"
        Me.Date1.Size = New System.Drawing.Size(61, 13)
        Me.Date1.TabIndex = 9
        Me.Date1.Text = "00.00.0000"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(171, 263)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(306, 23)
        Me.ProgressBar1.TabIndex = 10
        Me.ProgressBar1.Visible = False
        '
        'ProgressBarLabel
        '
        Me.ProgressBarLabel.AutoSize = True
        Me.ProgressBarLabel.Location = New System.Drawing.Point(308, 234)
        Me.ProgressBarLabel.Name = "ProgressBarLabel"
        Me.ProgressBarLabel.Size = New System.Drawing.Size(39, 13)
        Me.ProgressBarLabel.TabIndex = 11
        Me.ProgressBarLabel.Text = "Label4"
        Me.ProgressBarLabel.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(12, 51)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(273, 21)
        Me.ComboBox1.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Aktueller Mandant"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 445)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.ProgressBarLabel)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.ThumbnailEx1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "infoDOCS Core"
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
    Friend WithEvents BeschreibungToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents ThumbnailEx1 As GdPicture14.ThumbnailEx
    Friend WithEvents Date1 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ProgressBarLabel As Label
    Friend WithEvents SuchkriteriumHinzufügenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SuchkriteriumEntfernenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label4 As Label
End Class
