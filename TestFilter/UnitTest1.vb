Imports NUnit.Framework
Imports LUVA_Extractor
Namespace TestFilter

    Public Class Tests
        Dim form1Test As Form1
        <SetUp>
        Public Sub Setup()
            form1Test = New Form1()
        End Sub

        <Test>
        Public Sub TestAdresse()
            Dim Text As String = "Martin-Luther-Stra�e 5 Altenburg"
            '  Dim val = form1Test.ifNothingFoundFilter(Text) 'Warum nicht Funktionieren?

        End Sub

    End Class

End Namespace