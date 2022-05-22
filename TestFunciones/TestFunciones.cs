using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using INNUI.ETS_Edades;
using ICLUI.ETS_Edades;

namespace TestFunciones
{
    [TestClass]
    public class TestAplicacionIdiomas
    {
        [TestMethod]
        public void TestEspañol()
        {
            string option = "ES";
            int expectedResult = 1;

            int result = Menu.SelectOption(option, Messages.LANGUAGES_CODE);
            Assert.AreEqual(expectedResult, result);
        }
    }
    [TestClass]
    public class TestDespuesDeCristo
    {
        [TestMethod]
        public void TestFechaDC()
        {
            bool error = false;
            string entrada = "23/11/2001";
            DateTime fechaNacimiento = ComprobarFecha(entrada, ref error);
            Assert.IsTrue(error);
        }

        [TestMethod]
        public void TestDiaDC()
        {
            DateTime fechaNacimiento = DateTime.Parse("23/11/2001");
            double diasEsperados = 7440;
            double dias = ObtenerDias(fechaNacimiento);
            Assert.AreEqual(dias, diasEsperados);
        }
        [TestMethod]
        public void TestAnioDC()
        {
            DateTime fechaNacimiento = DateTime.Parse("25/03/2003");
            int aniosEsperados = 19;
            int anios = ObtenerAnios(fechaNacimiento);
            Assert.AreEqual(anios, aniosEsperados);
        }
    }
    [TestClass]
    public class TestAntesDeCristo
    {
        [TestMethod]
        public void TestFechaAC()
        {
            bool error = false;
            string[] entrada = { "29", "02", "-1904" };
            error = AntesDeCristoComprobacion(entrada);
            Assert.IsTrue(error);
        }
        [TestMethod]
        public void TestDiaAC()
        {
            string[] entrada = { "29", "02", "-1904" };//año bisiesto
            int aniosdiferencia = 3926;
            int diasEsperados = 1433969;
            int dias = ObtenerDiasAntesDeCristo(aniosdiferencia,entrada);
            Assert.AreEqual(dias,diasEsperados);
        }
      
        [TestMethod]
        public void TestAnioAC()
        {
            string[] entrada = { "29", "02", "-1904" };//año bisiesto
            int aniosEsperados = 3926;
            int anios = ObtenerAniosAntesDeCristo(entrada);
            Assert.AreEqual(anios, aniosEsperados);
        }
    }
}
