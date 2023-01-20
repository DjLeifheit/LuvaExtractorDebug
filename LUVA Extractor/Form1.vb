Imports GdPicture14

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GDLicense()

        extractObject("O:\LUVA Verwaltungs GmbH\Testdaten\217 2021-09-21 avr abfallgebührenbescheid.pdf")


    End Sub

    Private Sub extractObject(Pfad_PDF As String)
        Dim TextWithCoords As String
        Dim OCRdata As New List(Of OCRDataStruct)

        Using oGdPDF As New GdPicturePDF
            With oGdPDF
                ' Lade PDF
                .LoadFromFile(Pfad_PDF)

                ' https://www.gdpicture.com/guides/gdpicture/GdPicture.NET.14~GdPicture14.GdPicturePDF~GetPageTextWithCoords(String).html
                TextWithCoords = .GetPageTextWithCoords("~")

                .CloseDocument()
            End With
        End Using

        ' Trenne TextWithCoords nach newline
        ' Trenne Infos pro Line nach separator "~"
        ' Iteriere durch Infos und überführe diese in ein Objekt vom Typ OCRDataStruct
        'For Each 

        Dim _tempOCRDataStruct As OCRDataStruct
        With _tempOCRDataStruct
            .Coord = New Rectangle()
            .Text = ""
            .Confidence = 0
        End With

        OCRdata.Add(_tempOCRDataStruct)
        'next
    End Sub
End Class
