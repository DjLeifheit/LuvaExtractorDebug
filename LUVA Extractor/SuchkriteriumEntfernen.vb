Public Class SuchkriteriumEntfernen
    Dim delItems As New List(Of String)
    Private Sub SuchkriteriumEntfernen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        For i As Int32 = 0 To CheckedListBox1.Items.Count - 1
            If CheckedListBox1.GetItemChecked(i) = True Then
                delItems.Add(CheckedListBox1.Items(i).ToString)
            End If
            Me.Close()
        Next
    End Sub
    Public Function getDelList()
        Return delItems
    End Function

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox1.SelectedIndexChanged

    End Sub
End Class