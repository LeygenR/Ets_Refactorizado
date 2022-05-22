using ICLUI.ETS_Edades;
using INNUI.ETS_Edades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestFunciones
{
    [TestClass]
    public class TestAplicacionIdiomas
    {
        [TestMethod]
        public void TestEspañol()
        {
            string option = "ES";
            int expectedResult = 0;

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
            string entrada = "21/01/1993";
            bool noerror = false;

            FuncionesDespuesCristo.ComprobarFecha(entrada, ref noerror);
            Assert.IsTrue(noerror);
        }
        [TestMethod]
        public void TestDiaDC()
        {

            string[] fecha1 = { "20", "01", "1993" };
            string[] fecha2 = { "21", "01", "1993" };
            bool fecha1Despues_Cristo = true;
            bool fecha2Despues_Cristo = true;

            int[] difFechaDias = TratarFechas.CalcularDiasDif(fecha1, fecha2, fecha1Despues_Cristo, fecha2Despues_Cristo);
            int[] diasEsperados = { 0, 10713, 10713 };
            Assert.AreEqual(diasEsperados, difFechaDias);
        }

        [TestMethod]
        public void TestAnioDC()
        {
            string[] fecha1 = { "10", "01", "0010" };
            string[] fecha2 = { "15", "01", "0010" };
            bool fecha1Despues_Cristo = true;
            bool fecha2Despues_Cristo = true;

            int[] difFechasAnho = TratarFechas.CalcularAnhosDif(fecha1, fecha2, fecha1Despues_Cristo, fecha2Despues_Cristo);
            int[] anhosEsperados = { 0, 2012, 2012 };
            Assert.AreEqual(anhosEsperados, difFechasAnho);
        }
    }

    [TestClass]
    public class TestAntesDeCristo
    {
        [TestMethod]
        public void TestFechaAC()
        {
            string entrada = "21/01/1993";
            bool noerror = false;

            FuncionesDespuesCristo.ComprobarFecha(entrada, ref noerror);
            Assert.IsTrue(noerror);
        }

        [TestMethod]
        public void TestDiaAC()
        {

            string[] fecha1 = { "20", "01", "1993" };
            string[] fecha2 = { "21", "01", "1993" };
            bool fecha1Despues_Cristo = false;
            bool fecha2Despues_Cristo = false;

            int[] difFechaDias = TratarFechas.CalcularDiasDif(fecha1, fecha2, fecha1Despues_Cristo, fecha2Despues_Cristo);
            int[] diasEsperados = { 0, 10713, 10713 };
            Assert.AreEqual(diasEsperados, difFechaDias);
        }

        [TestMethod]
        public void TestAnioAC()
        {
            string[] fecha1 = { "10", "01", "0010" };
            string[] fecha2 = { "15", "01", "0010" };
            bool fecha1Despues_Cristo = false;
            bool fecha2Despues_Cristo = false;

            int[] difFechasAnho = TratarFechas.CalcularAnhosDif(fecha1, fecha2, fecha1Despues_Cristo, fecha2Despues_Cristo);
            int[] anhosEsperados = { 0, 2012, 2012 };
            Assert.AreEqual(anhosEsperados, difFechasAnho);
        }
    }
}
