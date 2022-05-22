using ICLUI.ETS_Edades;
using System;

namespace INNUI.ETS_Edades
{
    class TratarFechas
    {
        /// <summary>
        /// Función que repite en bucle para obtener una fecha válida
        /// </summary>
        /// <param name="contadorMostrar">contador para tener secuencia del pedido de fechas por persona</param>
        /// <returns>Devuelve una fecha de nacimiento correcta(no supere los años actuales y contando los bisiestos cumpliendo el formato correcto)</returns>
        public static string[] LeerFechaNacimiento(int contadorMostrar) //
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
        public static void PedirFechas(ref string[] fecha1, ref string[] fecha2,ref bool fecha1Despues_Cristo,ref bool fecha2Despues_Cristo)
        {
            int countPerson = 0;
            while (countPerson < 2)
            {
                if (Controlador.MenuAC_DC(Messages.LANGUAGE))
                {
                    if (countPerson.Equals(0))
                    {
                        fecha1 = TratarFechas.LeerFechaNacimiento(countPerson);
                    }
                    else
                    {
                        fecha2 = TratarFechas.LeerFechaNacimiento(countPerson);
                    }
                }
                else
                {
                    if (countPerson.Equals(0))
                    {
                        fecha1 = TratarFechas.LeerFechaNacimiento(countPerson);
                    }
                    else
                    {
                        fecha2 = TratarFechas.LeerFechaNacimiento(countPerson);
                    }
                }
                countPerson++;
            }
        }
        public static int[] CalcularAnhosDif(string[] fecha1, string[] fecha2,bool fecha1Despues_Cristo,bool fecha2Despues_Cristo)
        {
            int [] difFechasAnho = new int[3];
            if (fecha1Despues_Cristo)
            {
                if(fecha2Despues_Cristo)
                {
                    difFechasAnho[0] = Convert.ToInt32(fecha1[3]) - Convert.ToInt32(fecha2[3]);
                    difFechasAnho[1] = DateTime.Now.Year - Convert.ToInt32(fecha1[3]);
                    difFechasAnho[2] =  DateTime.Now.Year - Convert.ToInt32(fecha2[3]);
                }
                else
                {
                    difFechasAnho[0] = 2 * (Convert.ToInt32(fecha1[3]) - Convert.ToInt32(fecha2[3]));
                    difFechasAnho[2] = 2* (DateTime.Now.Year - Convert.ToInt32(fecha2[3]));
                }
            }
            else
            {
                difFechasAnho[0] = 2 * (Convert.ToInt32(fecha1[3]) - Convert.ToInt32(fecha2[3]));
                difFechasAnho[1] = 2 * (DateTime.Now.Year - Convert.ToInt32(fecha1[3]));
            }

            return difFechasAnho;
        }
        public static int [] CalcularDiasDif(string fecha1,string fecha2,bool fecha1Despues_Cristo, bool fecha2Despues_Cristo)
        {
            int[] difFechasAnho = new int[3];
            TimeSpan difFechas = Convert.ToDateTime(fecha1) - Convert.ToDateTime(fecha2);
            if (fecha1Despues_Cristo)
            {
                if (fecha2Despues_Cristo)
                {
                    difFechasAnho[0] = Convert.ToInt32(fecha1[3]) - Convert.ToInt32(fecha2[3]);
                    difFechasAnho[1] = DateTime.Now.Year - Convert.ToInt32(fecha1[3]);
                    difFechasAnho[2] = DateTime.Now.Year - Convert.ToInt32(fecha2[3]);
                }
                else
                {
                    difFechasAnho[0] = 2 * (Convert.ToInt32(fecha1[3]) - Convert.ToInt32(fecha2[3]));
                    difFechasAnho[2] = 2 * (DateTime.Now.Year - Convert.ToInt32(fecha2[3]));
                }
            }
            else
            {
                difFechasAnho[0] = 2 * (Convert.ToInt32(fecha1[3]) - Convert.ToInt32(fecha2[3]));
                difFechasAnho[1] = 2 * (DateTime.Now.Year - Convert.ToInt32(fecha1[3]));
            }

            return difFechasAnho;
        }
    }
}
