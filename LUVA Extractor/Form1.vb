Imports System.IO
Imports GdPicture14
Imports Microsoft.Office.Interop.Excel

Public Class Form1
    Dim listSKriterien() As String
    Dim stringArrWEG(21) As String
    Dim dataSet As System.Data.DataSet
    Dim Excel As New Microsoft.Office.Interop.Excel.Application

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GDLicense()
        datatable()

        ' extractObject("O:\LUVA Verwaltungs GmbH\Testdaten_Produktion\2_DTFSD_01-13-2023_53.pdf")


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

            End If


        Next
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
        Dim MyConnection As System.Data.OleDb.OleDbConnection
        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
        Dim path As String = "O:\LUVA Verwaltungs GmbH\Testdaten\objektliste neu.xlsx"
        MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;")
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
            End If


        Next
    End Function

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class
