using ICLUI.ETS_Edades;
using System;

namespace INNUI.ETS_Edades
{
    class FuncionesDespuesCristo
    {
        /// <summary>
        /// Función que comprueba la válidez de una fecha
        /// </summary>
        /// <param name="entrada">Entrada de fecha por teclado</param>
        /// <param name="error">Booleano de error en caso de fecha nó valida mostrarlo</param>
        /// <returns>Retorna la conversión de la fecha</returns>
        public static DateTime ComprobarFecha(string entrada, ref bool error)
        {
            DateTime fecha = new DateTime();
            try
            {
                string[] texts_language = Messages.FILEDATA[2].Split(',');
                string format = texts_language[Messages.LANGUAGE];
                fecha = DateTime.ParseExact(entrada.Trim(), format, null);
                if (DateTime.Now.Year < fecha.Year)//comparamos si la fecha introducida no supera a la actual
                {
                    Messages.ShowError(8);
                }
                else
                {
                    error = true;//fecha correcta salimos
                }
            }
            catch (Exception errorConversion)
            {
                Console.WriteLine(errorConversion.Message);
            }
            return fecha;
        }
        }
    }
}
