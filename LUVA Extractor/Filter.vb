Public Class Filter
    Dim filters As ArrayList = New ArrayList()
    Sub addFilter(ByVal element As String)
        filters.Add(element)
    End Sub
    Function getFilter()
        Return filters
    End Function
End Class
