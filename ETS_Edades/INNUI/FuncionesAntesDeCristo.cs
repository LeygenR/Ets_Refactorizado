using System;
using ICLUI.ETS_Edades;

namespace INNUI.ETS_Edades
{
    /// <summary>
    /// Clase con los métodos para el tratamiento de fechas anteriores a Cristo.
    /// </summary>
    public class FuncionesAntesDeCristo
    {
        /// <summary>
        /// Valida que la fecha antes de Cristo sea correcta.
        /// </summary>
        /// <param name="dividir">Fecha dividida para comprobarla por partes.</param>
        /// <returns>Booleano para la gestión de errores y, que la fecha sea correcta o incorrecta.</returns>
        public static bool AntesDeCristoComprobacion(string[] dividir)
        {
            bool comprobacionFecha = false;
            if (Int32.TryParse(dividir[1], out int mes))
            {
                if ((mes >= 1) && (mes <= 12))
                {
                    if (Int32.TryParse(dividir[0], out int dia))
                    {
                        if (dia > 0)
                        {
                            if (Int32.TryParse(dividir[2], out int anio))
                            {
                                if ((mes % 2) == 0) // Si los meses son pares, significa que son todos 30 menos agosto, octubre y diciembre que son 31. 
                                {                // Tambien hemos tenido en cuenta a febrero, si el año es biciesto, febrero tiene 29 dias y si no lo es tiene 28.
                                    if (mes == 02)
                                    {
                                        if (((anio % 4 == 0) && (anio % 100 != 0)) || (anio % 400 == 0))  //Comprobar si el año es bisiesto para febrero
                                        {
                                            if (dia <= 29)
                                            {
                                                comprobacionFecha = true;
                                            }
                                        }
                                        else
                                        {
                                            if (dia <= 28)
                                            {
                                                comprobacionFecha = true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (dia <= 30)
                                        {
                                            comprobacionFecha = true;
                                        }
                                        else
                                        {
                                            if ((mes == 08) || (mes == 10) || (mes == 12)) // Meses pares que terminen en 31
                                            {
                                                if (dia <= 31)
                                                {
                                                    comprobacionFecha = true;
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (mes < 09)
                                    {
                                        if (dia <= 31)
                                        {
                                            comprobacionFecha = true;
                                        }
                                    }
                                    else
                                    {
                                        if (dia <= 30)
                                        {
                                            comprobacionFecha = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return comprobacionFecha;
        }
        /// <summary>
        /// Método para leer las fechas que sean antes de Cristo.
        /// </summary>
        /// <param name="contadorMostrar">Contador para determinar el número de la persona por la que vamos.</param>
        /// <param name="codError">Si hay algún error, devolvemos por referencia el error y lo mostramos.</param>
        /// <returns>Fecha de nacimiento antes de Cristo dividida.</returns>
        public static string[] LeerFechaNacimientoAC(int contadorMostrar, ref int codError)
        {
            bool leer = false;//booleano para salir solo cuando lea una fecha válida          
            string[] Dividir = new string[0];
            do
            {
                Console.Clear();
                Messages.ShowAskDate(contadorMostrar);
                string fechaAC = Console.ReadLine();
                try
                {
                    Dividir = fechaAC.Split('/');
                    if (Dividir.Length == 3)
                    {
                        if (int.TryParse(Dividir[2], out int Anio))
                        {
                            if (Anio > 0)
                            {
                                if (FuncionesAntesDeCristo.AntesDeCristoComprobacion(Dividir))
                                {
                                    leer = true;//fecha correcta salimos
                                }
                                else
                                {
                                    codError = 4;
                                }
                            }
                            else
                            {
                                codError = 6;
                            }
                        }
                        else
                        {
                            codError = 7;
                        }
                    }
                    else
                    {
                        codError = 7;
                    }
                }
                catch (Exception)
                {
                    codError = 7;
                }

            } while (!leer);
            return Dividir;
        }
    }
}
