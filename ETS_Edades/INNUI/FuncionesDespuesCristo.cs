using System;
using ICLUI.ETS_Edades;

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
            DateTime fechaNacimiento = new DateTime();//la inicializo con la fecha actual para que no de errores
            try
            {
                string[] texts_language = Messages.FILEDATA[2].Split(',');
                string format = texts_language[Messages.LANGUAGE];
                fechaNacimiento = DateTime.ParseExact(entrada.Trim(), format, null);//En caso de error en la conversión del parse sale la excepción del catch
                DateTime actual = DateTime.Now;//fecha actual para compararla a la introducida por teclado
                if (actual.Year < fechaNacimiento.Year)//comparamos si la fecha introducida no supera a la actual
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
            return fechaNacimiento;
        }
        /// <summary>
        /// Función para devolver días de diferencia con la fecha actual
        /// </summary>
        /// <param name="fechaNacimiento">fecha de la persona</param>
        /// <param name="diasExactos">Días que tiene</param>
        public static int ObtenerDias(DateTime fechaNacimiento)
        {
            DateTime fechaActual = DateTime.Today;
            TimeSpan resta = fechaActual - fechaNacimiento;
            int diasExactos = resta.Days;
            return diasExactos;
        }
        /// <summary>
        /// Función para obtener los años de la persona
        /// </summary>
        /// <param name="fechaNacimiento">Fecha respectiva de la persona</param>
        /// <returns>Edad en años</returns>
        public static int ObtenerAnios(DateTime fechaNacimiento)
        {
            int anios;
            DateTime fechaActual = DateTime.Today;
            anios = fechaActual.Year - fechaNacimiento.Year;
            if (fechaNacimiento > fechaActual.AddYears(-anios))//volver al año en que nació la persona en caso de bisiesto
            {
                anios--;
            }
            return anios;
        }
    }
}
