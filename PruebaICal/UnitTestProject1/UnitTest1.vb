Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UnitTest1
    Dim pb As New PruebaICal.Form1()
    Dim ClasePrivada As New PrivateObject(pb)
    <TestMethod()> Public Sub TestMethod1()
        Dim resultado = pb.PruebaDePruebas(2)
        Assert.AreEqual(4, resultado)
    End Sub

    <TestMethod()> Public Sub prueba2()

    End Sub

End Class