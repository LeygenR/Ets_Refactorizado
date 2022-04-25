using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICLUI.ETS_Edades;

namespace INNUI.ETS_Edades
{
    class TratarFechas
    {
        public static string[] LeerFechaNacimientoAC(ref int contadorMostrar)
        {
            //DateTime fechaNacimiento = DateTime.Now;//la inicializo con la fecha actual para que no de errores
            bool leer = false;//booleano para salir solo cuando lea una fecha válida          
            string[] Dividir = new string[0];
            do
            {
                Console.Clear();
                Messages.ShowAskDate(contadorMostrar);
                string Fecha = Console.ReadLine();
                try
                {
                    Dividir = Fecha.Split('/');
                    if (Dividir.Length == 3)
                    {
                        if (int.TryParse(Dividir[2], out int Año))
                        {
                            if (Año < 0)
                            {
                                if (FuncionesAntesDeCristo.AntesDeCristoComprobacion(Dividir))
                                {
                                    leer = true;//fecha correcta salimos
                                }
                                else
                                {
                                    Messages.ShowError(4);
                                }
                            }
                            else
                            {
                                Messages.ShowError(6);
                            }
                        }
                        else
                        {
                            Messages.ShowError(7);
                        }
                    }
                    else
                    {
                        Messages.ShowError(7);
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }

            } while (!leer);
            return Dividir;
        }
        /// <summary>
        /// Función que repite en bucle para obtener una fecha válida
        /// </summary>
        /// <param name="contadorMostrar">contador para tener secuencia del pedido de fechas por persona</param>
        /// <returns>Devuelve una fecha de nacimiento correcta(no supere los años actuales y contando los bisiestos cumpliendo el formato correcto)</returns>
        public static DateTime LeerFechaNacimientoDC(ref int contadorMostrar)
        {
            DateTime fechaNacimiento = DateTime.Now;//la inicializo con la fecha actual para que no de errores
            bool leer = false;//booleano para salir solo cuando lea una fecha válida
            do
            {
                Messages.ShowAskDate(contadorMostrar);
                string entrada = Console.ReadLine();
                fechaNacimiento = FuncionesDespuesCristo.ComprobarFecha(entrada, ref leer);

            } while (!leer);
            return fechaNacimiento;
        }
    }
}
