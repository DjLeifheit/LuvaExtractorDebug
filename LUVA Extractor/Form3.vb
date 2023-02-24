Public Class Form3
    Public Filter As String
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Filter = TextBox1.Text
    End Sub
    Public Function getFilter()
        Return Filter
    End Function
End Class