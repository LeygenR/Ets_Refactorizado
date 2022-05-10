using ICLUI.ETS_Edades;
using System;

namespace INNUI.ETS_Edades
{
    class TratarFechas
    {
        public static string[] LeerFechaNacimientoAC(int contadorMostrar)
        {
            //DateTime fechaNacimiento = DateTime.Now;//la inicializo con la fecha actual para que no de errores
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
                        if (int.TryParse(Dividir[2], out int Anioo))
                        {
                            if (Anio < 0)
                            {
                                if (int.TryParse())
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
        public static string[] LeerFechaNacimientoDC(int contadorMostrar) //
        {
            DateTime fechaDC = new DateTime();
            bool leer = false;//booleano para salir solo cuando lea una fecha válida
            string[] fechaSeparada = new string[3];
            do
            {
                Messages.ShowAskDate(contadorMostrar);
                string entrada = Console.ReadLine();
                fechaDC = FuncionesDespuesCristo.ComprobarFecha(entrada, ref leer);
                fechaSeparada = fechaDC.ToShortDateString().Split('/');

            } while (!leer);
            return fechaSeparada;
        }
        public static bool IsAfterChrist(string siglasAntesCristo, string siglasDespuesCristo)
        {
            Messages.ShowAskPeriod();
            string beaf;
            bool valid = false;
            bool afterChrist = true;
            do
            {
                beaf = Console.ReadLine().Trim().ToUpper();
                if (!beaf.Equals(""))
                {
                    if (beaf.Equals(siglasDespuesCristo))
                    {
                        afterChrist = false;
                        valid = true;
                    }
                    else
                    {
                        if (beaf.Equals(siglasAntesCristo))
                        {
                            valid = true;
                        }
                    }
                }
                else
                {
                    Messages.ShowError(9);
                }
            }
            while (!valid);
            return afterChrist;
        }
    }
}
