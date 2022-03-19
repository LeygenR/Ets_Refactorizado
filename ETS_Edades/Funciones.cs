using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS_Edades
{
    class Funciones
    {
        /// <summary>
        /// Función para obetenr una fecha de nacimiento válida(Después de cristo)
        /// </summary>
        /// <returns>Devuelve una fecha válida introducida por teclado</returns>
        public static DateTime LeerFechaNacimiento()
        {
            DateTime fechaNacimiento = DateTime.Now;//la inicializo con la fecha actual para que no de errores
            bool leer = false;//booleano para salir solo cuando lea una fecha válida
            do
            {
                Console.WriteLine("Introduzca la fecha de la persona en el formato correcto(dd/MM/yyyy, por ejemplo 01/01/2001)");
                try
                {
                    fechaNacimiento = DateTime.ParseExact(Console.ReadLine().Trim(), "dd/MM/yyyy", null);//En caso de error en la conversión del parse sale la excepción del catch
                    DateTime actual = DateTime.Now;//fecha actual para compararla a la introducida por teclado
                    if(actual.Year < fechaNacimiento.Year)//comparamos si la fecha introducida no supera a la actual
                    {
                        Console.WriteLine("Error, la fecha introducida de la persona no es válida, aun no ha nacido");
                    }
                    else
                    {
                        leer = true;//fecha correcta salimos
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }

            } while (!leer);
            return fechaNacimiento;
        }
        /// <summary>
        /// Función para devolver por referencia los años y días de la fecha
        /// </summary>
        /// <param name="fechaNacimiento">fecha de la persona</param>
        /// <param name="dias">Días que tiene</param>
        /// <param name="anios">Edad actual</param>
        public static void ObtenerDiasYAnios(DateTime fechaNacimiento,ref double dias,ref double anios)
        {
            DateTime fechaActual = DateTime.Now;
            TimeSpan resta = fechaActual - fechaNacimiento;//Creo un Timespan que calcula un periodo de tiempo en nanosegundos(100)
            dias = resta.TotalDays;//uso la función que devulve los nanosegundos en días totales(como son exactos debe ser double la variable dias y luego hacer un Math.Floor al valor)
            anios = Math.Floor(dias / 365);//aquí lo divido entre la cantidas de dias que tiene un año 
        }


    }
}
