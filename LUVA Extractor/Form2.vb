Imports System.Runtime.CompilerServices

Public Class Form2
    Public stringTFeld() As String
    Public arrayRow() As DataRow

    Private Sub AdressenCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AdressenCombo.SelectedIndexChanged
        Dim ind As Int32 = AdressenCombo.SelectedIndex - 1
        AdresseTab.Text = stringTFeld(ind)
    End Sub
    Public Sub setArray(ByVal arrayRow() As DataRow)
        Me.arrayRow = arrayRow
        For Each Row As DataRow In arrayRow
            AdressenCombo.Items.Add(Row(1).ToString)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim name As String = arrayRow(AdressenCombo.SelectedIndex - 1)(6).ToString
    End Sub
End Class