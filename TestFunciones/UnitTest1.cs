using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ETS_Edades;
using static ETS_Edades.Funciones;
namespace TestFunciones
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Funciones funcion = new Funciones();
            DateTime fechaNacimiento = DateTime.Parse("23/11/2001");
            double diasEsperados = 7428;
            double dias = ObtenerDias(fechaNacimiento);
            Assert.AreEqual(dias, diasEsperados);
        }
    }
}
