using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ETS_Edades;
using static ETS_Edades.FuncionesDespuesCristo;
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
        public void TestFecha2()
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
            string entrada = "01/01/0001";
            DateTime fechaNacimiento = ComprobarFecha(entrada, ref error);
            Assert.IsTrue(error);
        }

        [TestMethod]
        public void TestDia1()
        {
            DateTime fechaNacimiento = DateTime.Parse("23/11/2001");
            double diasEsperados = 7428;
            double dias = ObtenerDias(fechaNacimiento);
            Assert.AreEqual(dias, diasEsperados);
        }

        [TestMethod]
        public void TestDia2()
        {
            DateTime fechaNacimiento = DateTime.Parse("23/11/1000");
            double diasEsperados = 373036;
            double dias = ObtenerDias(fechaNacimiento);
            Assert.AreEqual(dias, diasEsperados);
        }

        [TestMethod]
        public void TestDia3()
        {
            DateTime fechaNacimiento = DateTime.Parse("29/2/1904");
            double diasEsperados = 43125;
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
}
