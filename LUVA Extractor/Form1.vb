Imports System.IO
Imports System.Runtime.Remoting
Imports System.Text.RegularExpressions
Imports System.Xml.XPath
Imports GdPicture14
Imports Microsoft.Office.Interop.Excel

Public Class Form1
    Dim stadtFilterHSet As HashSet(Of String) = New HashSet(Of String)
    Dim listSKriterien() As String
    Dim stringArrWEG(21) As String
    Dim dataSetFiltered As System.Data.DataSet
    Dim MyConnection As System.Data.OleDb.OleDbConnection
    Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
    Dim path As String = "O:\LUVA Verwaltungs GmbH\Testdaten\objektliste neu.xlsx"
    Dim dataSet As System.Data.DataSet
    Dim table As System.Data.DataTable
    Dim dataSetErgebnisSQLLike As System.Data.DataSet
    Dim Excel As New Microsoft.Office.Interop.Excel.Application
    Dim dataSetAfterF As System.Data.DataSet

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        table = New System.Data.DataTable
        table.Columns.Add("Nr#")
        table.Columns.Add("Objekt")
        table.Columns.Add("plz")
        table.Columns.Add("ort")
        table.Columns.Add("etv")
        table.Columns.Add("ob")
        table.Columns.Add("bh")
        table.Columns.Add("iban")
        table.Columns.Add("bic")
        dataSetFiltered = New System.Data.DataSet
        dataSetErgebnisSQLLike = New System.Data.DataSet
        dataSetAfterF = New System.Data.DataSet
        'GDLicense()
        dataSetFiltered.Tables.Add(table)
        MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;")
        ' extractObject("O:\LUVA Verwaltungs GmbH\Testdaten_Produktion\2_DTFSD_01-13-2023_53.pdf")
        datatable()
        dataSetAnpassen()

    End Sub

    Private Sub extractObject(Pfad_PDF As String)
        Dim TextWithCoords As String
        Dim OCRdata As New List(Of OCRDataStruct)
        Dim writer As TextWriter = New StreamWriter("C:\Users\vincent.rieker\source\repos\Luva Extractor\TextWithCoordsText.txt")
        Using oGdPDF As New GdPicturePDF
            With oGdPDF
                Dim status As GdPictureStatus
                ' Lade PDF
                status = .LoadFromFile(Pfad_PDF)

                ' https://www.gdpicture.com/guides/gdpicture/GdPicture.NET.14~GdPicture14.GdPicturePDF~GetPageTextWithCoords(String).html
                TextWithCoords = .GetPageTextWithCoords("~")


                'writer.Write(TextWithCoords)

                .CloseDocument()
            End With
        End Using

        ' Trenne TextWithCoords nach newline
        ' Trenne Infos pro Line nach separator "~"
        ' Iteriere durch Infos und überführe diese in ein Objekt vom Typ OCRDataStruct
        'For Each
        Dim konkat As String = ""
        Dim koorXWord As Double
        Dim koorYWord As Double
        Dim yAchseVorgaenger As Double = 0
        Dim xAchse As Double = 0
        Dim yAchse As Double = 0
        Dim words() As String = TextWithCoords.Split(Environment.NewLine) 'vbcrlf
        Dim contSKrit As Boolean = False
        Dim count As Int32 = 0
        For Each word In words
            Dim zeileWort() As String = Split(word, "~")
            koorXWord = Double.Parse(zeileWort(0).Replace(".", ","))
            koorYWord = Double.Parse(zeileWort(1).Replace(".", ","))
            If zeileWort(8).Contains("WEG") Then
                Dim koordinatenPDF As New KoordinatenPDF()

                xAchse = koorXWord - 1
                yAchse = koorYWord - 3
                yAchseVorgaenger = yAchse - 1
                koordinatenPDF.koordinatenFuellenOEcke(xAchse, yAchse)
                koordinatenPDF.koordinatenFuellenUEcke(xAchse + 150, yAchse + 50)
                contSKrit = True
                'riter.WriteLine(zeileWort(8))

                'writer.Write(word)
            End If
            'If contSKrit = True Then
            '    count = count + 1
            '    writer.WriteLine(word)
            '    If count = 50 Then
            '        contSKrit = False
            '    End If

            'End If
            'Hardcode

            If koorXWord >= xAchse And koorXWord <= xAchse + 152 And koorYWord >= yAchse And koorYWord <= yAchse + 55 Then

                If koorYWord > yAchseVorgaenger + 5 Then
                    writer.WriteLine("")
                End If
                writer.Write(zeileWort(8) + " ")
                yAchseVorgaenger = koorYWord
                konkat += zeileWort(8).Replace("(", "").Replace(")", "") + " "
            End If

        Next
        writer.WriteLine("")
        writer.WriteLine(konkat)
        Dim Ergebnis As String = checkAdresse(konkat)
        writer.WriteLine(Ergebnis)
        writer.Close()

        'Dim _tempOCRDataStruct As OCRDataStruct
        'With _tempOCRDataStruct
        '    .Coord = New Rectangle()
        '    .Text = ""
        '    .Confidence = 0
        'End With
        'OCRdata.Add(_tempOCRDataStruct)
        ' Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.InitialDirectory = "O:\LUVA Verwaltungs GmbH\Testdaten_Produktion\"
        OpenFileDialog1.Filter = "PDF (*.pdf)|*.pdf"
        OpenFileDialog1.ShowDialog()
        extractObject(OpenFileDialog1.FileName)
    End Sub
    Private Sub excelAuslesen(ByVal path As String)
        Dim ExcelT As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
        ExcelT.Workbooks.Open("O:\LUVA Verwaltungs GmbH\Testdaten\objektliste neu.xlsx")

    End Sub
    Private Sub erstellenStadtFilter()
        For Each Row As DataRow In dataSet.Tables(0).Rows
            stadtFilterHSet.Add(Row(3))
        Next
    End Sub
    'lädt die Excel datenbamk in ein lokales DataSet 
    Private Sub datatable()
        MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Tabelle1$]", MyConnection)
        dataSet = New System.Data.DataSet
        MyCommand.Fill(dataSet)
        'For Each Row As DataRow In dataSet.Tables(0).Rows
        '    Dim konkat As String = ""
        '    For Each Coll As DataColumn In dataSet.Tables(0).Columns
        '        konkat += Row(Coll.ColumnName).ToString
        '    Next
        '    ComboBox1.Items.Add(konkat)
        'Next
    End Sub

    'Checkt ob die Adresse (Straße und Wohnort) in dieser Kombination in der Datenbank vorhanden ist
    'Funktion: Reverse Check prüft ob in der Adresse der Pdf straße und und Ort die in der Datenbank hinterlegt sind in dieser Konstelation vorhanden sind
    'wenn das nicht der Fall ist wird die gefilterte Variante geprüft 
    Public Function checkAdresse(text As String)
        For Each Row As DataRow In dataSet.Tables(0).Rows
            Dim valStr As String = Row(1).ToString()
            Dim valOrt As String = Row(3).ToString()
            If text.Contains(valStr) And text.Contains(valOrt) Then
                Return Row(6).ToString
            End If

        Next
        ifNothingFoundSQL(text)
        Return 0
    End Function


    'Variante 1 wenn keine Straße gefunden wurde zu der Adresse aus der PDF dann wird das ganze nochmal geprüft
    'nur dass über die Daten aus der Pdf als auch der Daten der Tabelle ein Filter gelegt wird sodass auch ähnlichkeiten schon zu einem Treffer führen
    'wenn mehrere Treffer gefunden wurden muss der User selbst wählen welcher Eintrag der richtige ist
    Public Function ifNothingFoundFilter(Text As String)
        Dim dataTableAfterF As System.Data.DataTable
        dataTableAfterF = New System.Data.DataTable
        dataTableAfterF.Columns.Add("Nr#")
        dataTableAfterF.Columns.Add("Objekt")
        dataTableAfterF.Columns.Add("plz")
        dataTableAfterF.Columns.Add("ort")
        dataTableAfterF.Columns.Add("etv")
        dataTableAfterF.Columns.Add("ob")
        dataTableAfterF.Columns.Add("bh")
        dataTableAfterF.Columns.Add("iban")
        dataTableAfterF.Columns.Add("bic")
        dataSetAfterF.Tables.Add(dataTableAfterF)
        Text = Text.Replace("str\.|Str\.", "straße")
        Text = Regex.Replace(Text, "\d", "")
        For Each Row As DataRow In dataSetFiltered.Tables(0).Rows
            Dim hilfsstringStrasse As String = Row(1).ToString.Trim()
            Dim hilfsstringOrt As String = Row(3).ToString.Trim()
            If Text.Contains(hilfsstringStrasse) And Text.Contains(hilfsstringOrt) Then
                Dim RowNew As DataRow = dataSetAfterF.Tables(0).NewRow
                For Each Coll As DataColumn In dataSetFiltered.Tables(0).Columns
                    RowNew(Coll.ColumnName) = Row(Coll.ColumnName)
                Next
            End If
        Next
        If dataSetAfterF.Tables(0).Rows.Count > 1 Then
            Dim arrayValD(dataSetAfterF.Tables(0).Rows.Count - 1) As String
            Dim arrayRow(dataSetAfterF.Tables(0).Rows.Count - 1) As DataRow
            Dim formCheck As Form2 = New Form2
            Dim counter As Int32 = 0
            formCheck.AdressePDF.Text = Text
            'Für jede Reihe im gefilterten set wird die passende Reihe in der ungefilterten datenbamk gesucht per ID (Nr.)
            'Wenn die Nummer gefunden wird wird die Reihe zu einem String konvertiert und die Straße in der Combobox hinzugefügt 
            For Each Row As DataRow In dataSetAfterF.Tables(0).Rows
                Dim id As String = Row(0).ToString
                For Each RowO As DataRow In dataSet.Tables(0).Rows
                    If (RowO(0).ToString.Equals(id)) Then
                        'formCheck.AdressenCombo.Items.Add(RowO(1).ToString)
                        Dim Conc As String = ""
                        arrayRow(counter) = RowO
                        For i As Int32 = 0 To dataSet.Tables(0).Columns.Count
                            Select Case i
                                Case 0
                                    Conc += "Nr." & vbTab & vbTab & RowO(0) & Environment.NewLine()
                                Case 1
                                    Conc += "Straße" & vbTab & vbTab & RowO(1) & Environment.NewLine()
                                Case 2
                                    Conc += "Plz" & vbTab & vbTab & RowO(2) & Environment.NewLine()
                                Case 3
                                    Conc += "Ort" & vbTab & vbTab & RowO(3) & Environment.NewLine()
                                Case 4
                                    Conc += "etv" & vbTab & vbTab & RowO(4) & Environment.NewLine()
                                Case 5
                                    Conc += "ob" & vbTab & vbTab & RowO(5) & Environment.NewLine()
                                Case 6
                                    Conc += "bh" & vbTab & vbTab & RowO(6) & Environment.NewLine()
                                Case 7
                                    Conc += "iban" & vbTab & vbTab & RowO(7) & Environment.NewLine()
                                Case 8
                                    Conc += "bic" & vbTab & vbTab & RowO(8) & Environment.NewLine()
                            End Select
                        Next
                        arrayValD(counter) = Conc
                        counter = counter + 1
                    End If
                Next
            Next
            formCheck.stringTFeld = arrayValD
            formCheck.arrayRow = arrayRow
        End If
    End Function
    Public Function ifNothingFoundSQL(text As String)
        Dim Filterused As String = ""

        For Each Filter As String In stadtFilterHSet
            If (text.Contains(Filter)) Then
                Filterused = Filter
            End If
        Next
        Dim splitText As String()
        text = Regex.Replace(text, "\.", "")
        text = Regex.Replace(text, "straße", "str")
        text = Regex.Replace(text, "\d", "")
        'Dim sb As New System.Text.StringBuilder
        'For Each c As Char In text
        '    If Not Char.IsDigit(c) Then sb.Append(c)
        'Next
        splitText = text.Split(" ")
        For s As Integer = 0 To splitText.Length - 1
            If splitText(s) <= 3 Then
                splitText(s) = ""
            End If
        Next

        '@todo Prüfen ob in der Datenbank etwas gefunden wurde wenn ja dann DataSet Füllen 
        For Each s As String In splitText

            Try
                Dim sqlConcat As String = "Select dm From [Tabelle1$] Where Objekt LIKE '%" & s & "%' AND ort = " & Filterused
                MyCommand = New System.Data.OleDb.OleDbDataAdapter(sqlConcat, MyConnection)
                MyCommand.Fill(dataSetErgebnisSQLLike)
            Catch ex As Exception

            End Try
            If dataSet.Tables(0).Rows.Count > 1 Then

            End If
        Next
    End Function

    'Function dataBaseConnection()
    '    Dim MyConnection As System.Data.OleDb.OleDbConnection
    '    Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
    '    Dim path As String = "O:\LUVA Verwaltungs GmbH\Testdaten\objektliste neu.xlsx"
    '    MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;")
    '    MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Tabelle1$]", MyConnection)
    '    Return MyConnection
    'End Function

    'Die Objekte von der Exceltabelle die in dem DataSet gespeichert worden sind werden modifiziert
    '   Hausnummern werden heraus gelöscht 
    '   Hausnummern mit Buchstaben werden heraus gelöscht (Bsp. 3a)
    '   Bindestriche und Plus zwischen Zahlen werden gelöscht
    '   Str. und str. wird zu straße
    '   Wenn 2 Straßen in einer Zeile vorhanden sind (Bsp Berliner Straße 109/Gugenmusweg 1 (Nr.143) oder Wieslocher Straße 3, Schulstraße 18 (Nr.209))
    '   wird gesplittet und die 2 Straße in eine neue Zeile geschrieben alle anderen Daten werden übernommen
    Public Sub dataSetAnpassen()
        Dim anzahlRows As Int32 = dataSet.Tables(0).Rows.Count()
        VorherTB.Text = anzahlRows
        For Each Row As DataRow In dataSet.Tables(0).Rows
            Dim valStr As String = Row(1).ToString()
            valStr = Regex.Replace(valStr, "str\.|Str\.", "straße")
            valStr = Regex.Replace(valStr, "[0-9][A-z]\-|[0-9]\s[A-z]\-", "00")
            valStr = Regex.Replace(valStr, "\,\s[0-9]|\+", "00")
            valStr = Regex.Replace(valStr, "\-[0-9]", "00")
            valStr = Regex.Replace(valStr, "\/[0-9]", "00")
            valStr = Regex.Replace(valStr, "\d", "  ")
            valStr = Regex.Replace(valStr, "\s[a-z]\s", " ")
            valStr = valStr.Split("  ")(0)
            If valStr.Contains("/") Then
                Dim strasseSplit = valStr.Split("/")
                Dim RowAdd As DataRow = dataSetFiltered.Tables(0).NewRow()
                For Each Coll As DataColumn In dataSetFiltered.Tables(0).Columns
                    RowAdd(Coll.ColumnName) = Row(Coll.ColumnName)
                Next
                RowAdd(1) = strasseSplit(1)
                Row(1) = strasseSplit(0)
                Dim Rowst As DataRow = dataSetFiltered.Tables(0).NewRow()
                For Each Coll As DataColumn In dataSetFiltered.Tables(0).Columns
                    Rowst(Coll.ColumnName) = Row(Coll.ColumnName)
                Next
                dataSetFiltered.Tables(0).Rows.Add(Rowst)
                dataSetFiltered.Tables(0).Rows.Add(RowAdd)
            ElseIf (valStr.Contains(",")) Then
                Dim strasseSplit = valStr.Split(",")
                Dim RowAdd As DataRow = dataSetFiltered.Tables(0).NewRow()
                For Each Coll As DataColumn In dataSetFiltered.Tables(0).Columns
                    RowAdd(Coll.ColumnName) = Row(Coll.ColumnName)
                Next
                RowAdd(1) = strasseSplit(1)
                Row(1) = strasseSplit(0)
                Dim Rowst As DataRow = dataSetFiltered.Tables(0).NewRow()
                For Each Coll As DataColumn In dataSetFiltered.Tables(0).Columns
                    Rowst(Coll.ColumnName) = Row(Coll.ColumnName)
                Next
                dataSetFiltered.Tables(0).Rows.Add(Rowst)
                dataSetFiltered.Tables(0).Rows.Add(RowAdd)
            Else Row(1) = valStr
                Dim Rowst As DataRow = dataSetFiltered.Tables(0).NewRow()
                For Each Coll As DataColumn In dataSetFiltered.Tables(0).Columns
                    Rowst(Coll.ColumnName) = Row(Coll.ColumnName)
                Next
                dataSetFiltered.Tables(0).Rows.Add(Rowst)
            End If

        Next
        '  Dim writer As TextWriter = New StreamWriter("C:\Users\vincent.rieker\source\repos\Luva Extractor\objektlisteTest.csv")

        Dim ShowTable As String
        For Each Row As DataRow In dataSetFiltered.Tables(0).Rows
            Dim hilfsstring As String = ""
            For Each Coll As DataColumn In dataSetFiltered.Tables(0).Columns
                hilfsstring += Row(Coll.ColumnName).ToString & vbTab
            Next
            ShowTable += hilfsstring + Environment.NewLine

        Next
        TextBox2.Text = ShowTable
    End Sub


End Class
