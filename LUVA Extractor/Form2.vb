Imports System.Runtime.CompilerServices

Public Class Form2
    Public stringTFeld() As String
    Public arrayRow() As DataRow

    Private Sub AdressenCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AdressenCombo.SelectedIndexChanged
        Dim ind As Int32 = AdressenCombo.SelectedIndex
        AdresseTab.Text = stringTFeld(ind)
    End Sub
    Public Sub setArray(ByVal arrayRow() As DataRow)
        Me.arrayRow = arrayRow
        For Each Row As DataRow In arrayRow
            AdressenCombo.Items.Add(Row(1).ToString)
        Next
    End Sub
End Class