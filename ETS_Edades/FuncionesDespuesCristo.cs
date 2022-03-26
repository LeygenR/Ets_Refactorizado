using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS_Edades
{
    public class FuncionesDespuesCristo
    {
        /// <summary>
        /// Función que repite en bucle para obtener una fecha válida
        /// </summary>
        /// <param name="contadorMostrar">contador para tener secuencia del pedido de fechas por persona</param>
        /// <returns>Devuelve una fecha de nacimiento correcta(no supere los años actuales y contando los bisiestos cumpliendo el formato correcto)</returns>
        public static DateTime LeerFechaNacimiento(int contadorMostrar)
        {
            DateTime fechaNacimiento = DateTime.Now;//la inicializo con la fecha actual para que no de errores
            bool leer = false;//booleano para salir solo cuando lea una fecha válida
            do
            {
                Console.WriteLine("Introduzca la fecha de la persona {0} en el formato correcto(dd/MM/yyyy, por ejemplo 01/01/2001)",contadorMostrar);
                string entrada = Console.ReadLine();
                fechaNacimiento= ComprobarFecha(entrada,ref leer);

            } while (!leer);
            return fechaNacimiento;
        }
        /// <summary>
        /// Función que comprueba la válidez de una fecha
        /// </summary>
        /// <param name="entrada">Entrada de fecha por teclado</param>
        /// <param name="error">Booleano de error en caso de fecha nó valida mostrarlo</param>
        /// <returns>Retorna la conversión de la fecha</returns>
        public static DateTime ComprobarFecha(string entrada, ref bool error)
        {
            DateTime fechaNacimiento = DateTime.Now;//la inicializo con la fecha actual para que no de errores
            try
            {
                fechaNacimiento = DateTime.ParseExact(entrada.Trim(), "dd/MM/yyyy", null);//En caso de error en la conversión del parse sale la excepción del catch
                DateTime actual = DateTime.Now;//fecha actual para compararla a la introducida por teclado
                if (actual.Year < fechaNacimiento.Year)//comparamos si la fecha introducida no supera a la actual
                {
                    Console.WriteLine("Error, la fecha introducida de la persona no es válida, aún no ha nacido");
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
        /// Función para devolver por referencia los años y días de la fecha
        /// </summary>
        /// <param name="fechaNacimiento">fecha de la persona</param>
        /// <param name="dias">Días que tiene</param>
        /// <param name="anios">Edad actual</param>
        public static double ObtenerDias(DateTime fechaNacimiento)
        {
            double dias;
            DateTime fechaActual = DateTime.Now;
            TimeSpan resta = fechaActual - fechaNacimiento;//Creo un Timespan que calcula un periodo de tiempo en nanosegundos(100)
            double diasExactos = resta.TotalDays;//uso la función que devulve los nanosegundos en días totales(como son exactos debe ser double la variable dias y luego hacer un Math.Floor al valor)
            //anios = Math.Floor(dias / 365);aquí lo divido entre la cantidas de dias que tiene un año
            dias = Math.Floor(diasExactos);
            return dias;
        }
        /// <summary>
        /// Función para obtener los años de la persona
        /// </summary>
        /// <param name="fechaNacimiento">Fecha respectiva de la persona</param>
        /// <returns>Edad en años</returns>
        public static int ObtenerAnios(DateTime fechaNacimiento)
        {
            int anios;
            DateTime fechaActual = DateTime.Now;
            anios = fechaActual.Year - fechaNacimiento.Year;
            if (fechaNacimiento > fechaActual.AddYears(-anios))//volver al año en que nació la persona en caso de bisiesto
            {
                anios--;
            }
            return anios;
        }

        public static void MostrarDiferenciaEdades(double diasPersona1,int aniosPersona1, double diasPersona2, int aniosPersona2)
        {
            Console.Clear();
            double diasDiferencia = Math.Abs(diasPersona1 - diasPersona2);
            int aniosDiferencia = Math.Abs(aniosPersona1 - aniosPersona2);
            Console.WriteLine("La diferencia entre las dos personas es de {0} días y de {1} años",diasDiferencia,aniosDiferencia);
        }

    }
}
