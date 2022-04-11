using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ETS_Edades;
using static ETS_Edades.FuncionesDespuesCristo;
using static ETS_Edades.FuncionesAntesDeCristo;
namespace TestFunciones
{
    [TestClass]
    public class TestDespuesDeCristo
    {
        [TestMethod]
        public void TestFecha1()
        {
            bool error = false;
            string entrada = "23/11/2001";
            DateTime fechaNacimiento = ComprobarFecha(entrada,ref error);
            Assert.IsTrue(error);
        }

        [TestMethod]
        public void TestFecha2()//comprobar año bisiesto
        {
            bool error = false;
            string entrada = "29/02/1904";
            DateTime fechaNacimiento = ComprobarFecha(entrada, ref error);
            Assert.IsTrue(error);
        }

        [TestMethod]
        public void TestFecha3()
        {
            bool error = false;
            string entrada = "01/01/0001";//comprobar primer límite inferior
            DateTime fechaNacimiento = ComprobarFecha(entrada, ref error);
            Assert.IsTrue(error);
        }

        [TestMethod]
        public void TestDia1()
        {
            DateTime fechaNacimiento = DateTime.Parse("23/11/2001");
            double diasEsperados = 7440;
            double dias = ObtenerDias(fechaNacimiento);
            Assert.AreEqual(dias, diasEsperados);
        }

        [TestMethod]
        public void TestDia2()
        {
            DateTime fechaNacimiento = DateTime.Parse("23/11/1000");
            double diasEsperados = 373048;
            double dias = ObtenerDias(fechaNacimiento);
            Assert.AreEqual(dias, diasEsperados);
        }

        [TestMethod]
        public void TestDia3()
        {
            DateTime fechaNacimiento = DateTime.Parse("29/02/1904");
            double diasEsperados = 43137;
            double dias = ObtenerDias(fechaNacimiento);
            Assert.AreEqual(dias, diasEsperados);
        }

        [TestMethod]
        public void TestAnio1()
        {
            DateTime fechaNacimiento = DateTime.Parse("25/03/2003");
            int aniosEsperados = 19;
            int anios = ObtenerAnios(fechaNacimiento);
            Assert.AreEqual(anios, aniosEsperados);
        }

        [TestMethod]
        public void TestAnio2()
        {
            DateTime fechaNacimiento = DateTime.Parse("01/01/0001");
            int aniosEsperados = 2021;
            int anios = ObtenerAnios(fechaNacimiento);
            Assert.AreEqual(anios, aniosEsperados);
        }

        [TestMethod]
        public void TestAnio3()
        {
            DateTime fechaNacimiento = DateTime.Parse("29/02/1960");
            int aniosEsperados = 62;
            int anios = ObtenerAnios(fechaNacimiento);
            Assert.AreEqual(anios, aniosEsperados);
        }
    }
    [TestClass]
    public class TestAntesDecristo 
    {
        [TestMethod]
        public void TestFecha1()
        {
            bool error = false;
            string[] entrada = { "29", "02", "-1904" };
            error = AntesDeCristoComprobacion(entrada);
            Assert.IsTrue(error);
        }
        [TestMethod]
        public void TestFecha2()
        {
            bool error = false;
            string[] entrada = { "28", "02", "-1" };
            error = AntesDeCristoComprobacion(entrada);
            Assert.IsTrue(error);
        }
        [TestMethod]
        public void TestFecha3()
        {
            bool error = false;
            string[] entrada = { "23", "11", "-2001" };
            error = AntesDeCristoComprobacion(entrada);
            Assert.IsTrue(error);
        }
        /*
        [TestMethod]
        public void TestDia1()
        {
            string[] entrada = { "29", "02", "-1904" };//año bisiesto
            int aniosdiferencia = 3926;
            int diasEsperados = 1433969;
            int dias = ObtenerDiasAntesDeCristo(aniosdiferencia,entrada);
            Assert.AreEqual(dias,diasEsperados);
        }
        [TestMethod]
        public void TestDia2()
        {
            string[] entrada = { "28", "02", "-1905" };//año bisiesto
            int aniosdiferencia = 3926;
            int diasEsperados = 1434336;
            int dias = ObtenerDiasAntesDeCristo(aniosdiferencia, entrada);
            Assert.AreEqual(dias, diasEsperados);
        }*/

        [TestMethod]
        public void TestAnio1()
        {
            string[] entrada = { "29", "02", "-1904" };//año bisiesto
            int aniosEsperados = 3926;
            int anios = ObtenerAniosAntesDeCristo(entrada);
            Assert.AreEqual(anios, aniosEsperados);
        }

        [TestMethod]
        public void TestAnio2()
        {
            string[] entrada = { "01", "01", "-1" };//testear límite inferior
            int aniosEsperados = 2023;
            int anios = ObtenerAniosAntesDeCristo(entrada);
            Assert.AreEqual(anios, aniosEsperados);
        }

        [TestMethod]
        public void TestAnio3()
        {
            string[] entrada = { "01", "01", "-10001" };//testear límite superior
            int aniosEsperados = 12023;
            int anios = ObtenerAniosAntesDeCristo(entrada);
            Assert.AreEqual(anios, aniosEsperados);
        }
    }

}
