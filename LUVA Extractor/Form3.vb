Public Class Form3
    Public Filter As String = ""
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not IsNothing(TextBox1.Text) OrElse Not TextBox1.Text.Equals("") Then
            Filter = TextBox1.Text
            MsgBox("das eingegebene Suchkriterium wurde erfolgreich hinzugefügt")
        End If
        Me.Close()
    End Sub
    Public Function getFilter()
        Return Filter
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Filter = ""
        Me.Close()
    End Sub
End Class