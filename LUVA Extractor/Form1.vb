Imports System.IO
Imports System.Runtime.Remoting
Imports System.Text.RegularExpressions
Imports System.Xml.XPath
Imports GdPicture14
Imports Microsoft.Office.Interop.Excel

Public Class Form1
    Dim listSKriterien() As String
    Dim stringArrWEG(21) As String
    Dim dataSetFiltered As System.Data.DataSet
    Dim MyConnection As System.Data.OleDb.OleDbConnection
    Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
    Dim path As String = "O:\LUVA Verwaltungs GmbH\Testdaten\objektliste neu.xlsx"
    Dim dataSet As System.Data.DataSet
    Dim table As System.Data.DataTable
    Dim Excel As New Microsoft.Office.Interop.Excel.Application

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
    Private Function checkAdresse(text As String)
        For Each Row As DataRow In dataSet.Tables(0).Rows
            Dim valStr As String = Row(1).ToString()
            Dim valOrt As String = Row(3).ToString()
            If text.Contains(valStr) And text.Contains(valOrt) Then
                Return Row(6).ToString
            Else
                Dim msg As MessageBox
                'msg.
                'Return 0
            End If

        Next
    End Function

    Function ifNothingFound(text As String)
        Dim splitText As String()

        text = text.Replace("str\.|Str\.", "straße")
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
        For Each s As String In splitText
            Dim sqlConcat As String = "Select dm From [Tabelle1$] Where Objekt LIKE " + s
        Next
    End Function

    Function dataBaseConnection()
        Dim MyConnection As System.Data.OleDb.OleDbConnection
        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
        Dim path As String = "O:\LUVA Verwaltungs GmbH\Testdaten\objektliste neu.xlsx"
        MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;")
        MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Tabelle1$]", MyConnection)
        Return MyConnection
    End Function

    Sub dataSetAnpassen()
        Dim anzahlRows As Int32 = dataSet.Tables(0).Rows.Count()
        VorherTB.Text = anzahlRows
        For Each Row As DataRow In dataSet.Tables(0).Rows
            Dim valStr As String = Row(1).ToString()
            valStr = Regex.Replace(valStr, "str\.|Str\.", "straße")
            valStr = Regex.Replace(valStr, "[0-9][a-z]\-", "00")
            valStr = Regex.Replace(valStr, "\,|\+", "00")
            valStr = Regex.Replace(valStr, "\-[0-9]", "00")
            valStr = Regex.Replace(valStr, "\/[0-9]", "00")
            valStr = Regex.Replace(valStr, "\d", "  ")
            valStr = Regex.Replace(valStr, "\s[a-z]\s", " ")
            valStr = Regex.Replace(valStr, "\s\s[a-z]", " ")
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
            Else Row(1) = valStr
                Dim Rowst As DataRow = dataSetFiltered.Tables(0).NewRow()
                For Each Coll As DataColumn In dataSetFiltered.Tables(0).Columns
                    Rowst(Coll.ColumnName) = Row(Coll.ColumnName)
                Next
                dataSetFiltered.Tables(0).Rows.Add(Rowst)
            End If

        Next
        Dim writer As TextWriter = New StreamWriter("C:\Users\vincent.rieker\source\repos\Luva Extractor\objektlisteTest.csv")
        For Each Row As DataRow In dataSetFiltered.Tables(0).Rows
            For Each Coll As DataColumn In dataSetFiltered.Tables(0).Columns
                writer.Write(Row(Coll.ColumnName).ToString + ",")
            Next
            writer.WriteLine()
        Next
        writer.Close()
        NachherTB.Text = ComboBox1.Items.Count
    End Sub


End Class
