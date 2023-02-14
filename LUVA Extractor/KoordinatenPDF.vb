Public Class KoordinatenPDF
    Private koordinatenObereEcke(2) As Double
    Private koordinatenUntereEcke(2) As Double
    Sub koordinatenFuellenOEcke(xOecke As Double, yOEcke As Double)
        koordinatenObereEcke(0) = xOecke
        koordinatenObereEcke(1) = yOEcke
    End Sub
    Sub koordinatenFuellenUEcke(xUEcke As Double, yUEcke As Double)
        koordinatenUntereEcke(0) = xUEcke
        koordinatenUntereEcke(1) = yUEcke
    End Sub
    Function getOEckeKoordinaten()
        Return koordinatenObereEcke
    End Function
    Function getUEckeKoordinaten()
        Return koordinatenUntereEcke
    End Function

End Class
