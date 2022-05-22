using ICLUI.ETS_Edades;
using System;

namespace INNUI.ETS_Edades
{
    /// <summary>
    /// Clase que contiene métodos intermedios para la gestión de errores y, el paso a las siguientes funciones.
    /// </summary>
    class Controlador
    {
        /// <summary>
        /// Método intermedio para, cuando vayamos a solicitar las fechas, que la persona introduzca de que época es dicha fecha.
        /// </summary>
        /// <param name="language">Idioma usado</param>
        /// <returns>Boleano de control. Gestionar la época de la fecha y sus posibles errores</returns>
        public static bool IsAfterChristController(int language)
        {
            string[] texts_antesCristo = Messages.FILEDATA[14].Split(',');
            string[] texts_despuesCristo = Messages.FILEDATA[13].Split(',');
            string despuesCristo = texts_despuesCristo[language];
            string antesCristo = texts_antesCristo[language];

            bool isAfterChrist = true;
            if (!TratarFechas.IsAfterChrist(antesCristo, despuesCristo))
            {
                isAfterChrist = false;
            }
            return isAfterChrist;
        }
        /// <summary>
        /// Método intermedio para pedir fechas y gestionar los respectivos errores.
        /// </summary>
        /// <param name="fecha1">Parámetro donde guardaremos la fecha de la primera persona.</param>
        /// <param name="fecha2">Parámetro donde guardaremos la fecha de la segunda persona.</param>
        /// <param name="fecha1Despues_Cristo">Booleano de control para saber si la fecha de la primera persona es de antes o después de Cristo.</param>
        /// <param name="fecha2Despues_Cristo">Booleano de control para saber si la fecha de la segunda persona es de antes o después de Cristo.</param>
        /// <returns></returns>
        public static bool PedirFechasControlador(ref string[] fecha1, ref string[] fecha2, ref bool fecha1Despues_Cristo, ref bool fecha2Despues_Cristo)
        {
            bool noerror = true;
            int codError = -1;
            TratarFechas.PedirFechas(ref fecha1, ref fecha2, ref fecha1Despues_Cristo, ref fecha2Despues_Cristo, ref codError);
            if(!codError.Equals(-1))
            {
                noerror = false;
                Messages.ShowError(codError);
            }
            return noerror;
        }
        /// <summary>
        /// Método intermedio en el cual las fechas pasan a un formato correcto y, realizamos el mostrado.
        /// </summary>
        /// <param name="fecha1">Fecha persona 1.</param>
        /// <param name="fecha2">Fecha persona 2</param>
        /// <param name="difAnhos">Diferencia de anhos entre las dos fechas y, cada fecha, con respecto a la actual.</param>
        /// <param name="difDias">Diferencia de días entre las dos fechas y, cada fecha, con respecto a la actual.</param>
        public static void MostrarResultadoControlador(string []fecha1, string[] fecha2, int[] difAnhos, int[] difDias)
        {
            string fecha1_GoodFormat = TratarFechas.Put_Fecha_GoodFormat(fecha1);
            string fecha2_GoodFormat = TratarFechas.Put_Fecha_GoodFormat(fecha2);

            Messages.ShowResult(fecha1_GoodFormat, fecha2_GoodFormat, difAnhos, difDias);
        }
    }
}
