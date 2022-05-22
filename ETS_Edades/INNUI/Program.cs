using ICLUI.ETS_Edades;
using INNUI.ETS_Edades;

using System;

namespace ETS_Edades
{
    /// <summary>
    /// Programa que, según el idioma, pide la época en la que quieres añadir una fecha.
    /// Posteriormente muestra la diferencia de días y anhos entre las dos fechas introducidas y, cada fecha, con respecto a la actual.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Menu.ShowMenu(Messages.LANGUAGES_CODE, Messages.LANGUAGES); //Mostrado menú idiomas.
            string option = Console.ReadLine();
            Messages.LANGUAGE = Menu.SelectOption(option, Messages.LANGUAGES_CODE); //Elegir opción idioma.
            if (!Messages.LANGUAGE.Equals(-1))
            {
                bool fecha1Despues_Cristo = true;
                bool fecha2Despues_Cristo = true;
                string[] fecha1 = new string[3];
                string[] fecha2 = new string[3];
                if (Controlador.PedirFechasControlador(ref fecha1, ref fecha2, ref fecha1Despues_Cristo, ref fecha2Despues_Cristo))
                {
                    int[] difAnhos = TratarFechas.CalcularAnhosDif(fecha1, fecha2, fecha1Despues_Cristo, fecha2Despues_Cristo); //Cálculo anhos diferencia.
                    int[] difDias = TratarFechas.CalcularDiasDif(fecha1, fecha2, fecha1Despues_Cristo, fecha2Despues_Cristo);   //Cálculo días diferencia.
                    Controlador.MostrarResultadoControlador(fecha1, fecha2, difAnhos, difDias); //Mostrado final.
                }
            }
        }   
    }
}