using ICLUI.ETS_Edades;
using System;

namespace INNUI.ETS_Edades
{
    /// <summary>
    /// Clase con los métodos para el tratamiento de fechas posteriores a Cristo.
    /// </summary>
    public class FuncionesDespuesCristo
    {
        /// <summary>
        /// Función que repite en bucle para obtener una fecha válida
        /// </summary>
        /// <param name="contadorMostrar">contador para tener secuencia del pedido de fechas por persona</param>
        /// <returns>Devuelve una fecha de nacimiento correcta(no supere los años actuales y contando los bisiestos cumpliendo el formato correcto)</returns>
        public static string[] LeerFechaNacimientoDC(int contadorMostrar) //
        {
            DateTime fechaDC = new DateTime();
            bool noerror = false;//booleano para salir solo cuando lea una fecha válida
            string[] fechaSeparada = new string[3];
            do
            {
                Messages.ShowAskDate(contadorMostrar);
                string entrada = Console.ReadLine();
                fechaDC = ComprobarFecha(entrada, ref noerror);
                fechaSeparada = fechaDC.ToShortDateString().Split('/');

            } while (!noerror);
            return fechaSeparada;
        }
        /// <summary>
        /// Función que comprueba la válidez de una fecha
        /// </summary>
        /// <param name="entrada">Entrada de fecha por teclado</param>
        /// <param name="noerror">Booleano de error y, en caso de fecha no válida, mostrarlo.</param>
        /// <returns>Retorna la conversión de la fecha</returns>
        public static DateTime ComprobarFecha(string entrada, ref bool noerror)
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
                    noerror = true;//fecha correcta salimos
                }
            }
            catch (Exception errorConversion)
            {
                Console.WriteLine(errorConversion.Message);
                _ = Console.ReadKey(true);
            }
            return fecha;
        }
    }
}

