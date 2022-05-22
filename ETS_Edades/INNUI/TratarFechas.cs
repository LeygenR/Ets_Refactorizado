using ICLUI.ETS_Edades;
using System;

namespace INNUI.ETS_Edades
{
    class TratarFechas
    {
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
                        afterChrist = true;
                        valid = true;
                    }
                    else
                    {
                        if (beaf.Equals(siglasAntesCristo))
                        {
                            valid = true;
                            afterChrist = false;
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
        public static void PedirFechas(ref string[] fecha1, ref string[] fecha2,ref bool fecha1Despues_Cristo,ref bool fecha2Despues_Cristo,ref int codError)
        {
            int countPerson = 0;
            while (countPerson < 2)
            {
                if (Controlador.IsAfterChristController(Messages.LANGUAGE))
                {
                    if (countPerson.Equals(0))
                    {
                        fecha1 = FuncionesDespuesCristo.LeerFechaNacimientoDC(countPerson);
                    }
                    else
                    {
                        fecha2 = FuncionesDespuesCristo.LeerFechaNacimientoDC(countPerson);
                    }
                }
                else
                {
                    if (countPerson.Equals(0))
                    {
                        fecha1 = FuncionesAntesDeCristo.LeerFechaNacimientoAC(countPerson, ref codError);
                        fecha1Despues_Cristo = false;
                    }
                    else
                    {
                        fecha2 = FuncionesAntesDeCristo.LeerFechaNacimientoAC(countPerson, ref codError);
                        fecha2Despues_Cristo = false;
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
                    difFechasAnho[0] = Convert.ToInt32(fecha1[2]) - Convert.ToInt32(fecha2[2]);
                    difFechasAnho[1] = DateTime.Now.Year - Convert.ToInt32(fecha1[2]);
                    difFechasAnho[2] = DateTime.Now.Year - Convert.ToInt32(fecha2[2]);
                }
                else
                {
                    difFechasAnho[0] = (Convert.ToInt32(fecha2[2])) * 2 + (Convert.ToInt32(fecha1[2]) - Convert.ToInt32(fecha2[2]));
                    difFechasAnho[1] = DateTime.Now.Year - Convert.ToInt32(fecha1[2]);
                    difFechasAnho[2] = (Convert.ToInt32(fecha2[2])) * 2 + (DateTime.Now.Year - Convert.ToInt32(fecha2[2]));
                }
            }
            else
            {
                if (fecha2Despues_Cristo)
                {
                    difFechasAnho[0] = (Convert.ToInt32(fecha1[2])) * 2 + Convert.ToInt32(fecha1[2]) - Convert.ToInt32(fecha2[2]);
                    difFechasAnho[1] = DateTime.Now.Year - Convert.ToInt32(fecha1[2]);
                    difFechasAnho[2] = DateTime.Now.Year - Convert.ToInt32(fecha2[2]);
                }
                else
                {
                    difFechasAnho[0] = (Convert.ToInt32(fecha1[2]) - Convert.ToInt32(fecha2[2]));
                    difFechasAnho[1] = (DateTime.Now.Year - Convert.ToInt32(fecha1[2]));
                    difFechasAnho[2] = (DateTime.Now.Year - Convert.ToInt32(fecha2[2]));
                }
            }

            return difFechasAnho;
        }
        public static int [] CalcularDiasDif(string[] fecha1,string[] fecha2,bool fecha1Despues_Cristo, bool fecha2Despues_Cristo)
        {
            int[] difFechaDias = new int[3];
            string fecha1_formatoValido = TratarFechas.Put_Fecha_GoodFormat(fecha1);
            string fecha2_formatoValido = TratarFechas.Put_Fecha_GoodFormat(fecha2);
            TimeSpan dif2Fechas = Convert.ToDateTime(fecha1_formatoValido) - Convert.ToDateTime(fecha1_formatoValido);
            TimeSpan difFecha1ACT = DateTime.Now - Convert.ToDateTime(fecha2_formatoValido);
            TimeSpan dif2Fecha2ACT = DateTime.Now - Convert.ToDateTime(fecha2_formatoValido);
            DateTime fechaAnho1 = new DateTime(01/01/0001);
            if (fecha1Despues_Cristo)
            {
                if (fecha2Despues_Cristo)
                {
                    difFechaDias[0] = dif2Fechas.Days;
                    difFechaDias[1] = difFecha1ACT.Days;
                    difFechaDias[2] = dif2Fecha2ACT.Days;
                }
                else
                {
                     
                    difFechaDias[0] = dif2Fechas.Days + dif2Fecha2ACT.Days;
                    difFechaDias[1] = difFecha1ACT.Days;
                    difFechaDias[2] = dif2Fecha2ACT.Days;
                }
            }
            else
            {
                if (fecha2Despues_Cristo)
                {
                    difFechaDias[0] = dif2Fechas.Days + difFecha1ACT.Days;
                    difFechaDias[1] = difFecha1ACT.Days;
                    difFechaDias[2] = dif2Fecha2ACT.Days;
                }
                else
                {
                    difFechaDias[0] = dif2Fechas.Days;
                    difFechaDias[1] = difFecha1ACT.Days;
                    difFechaDias[2] = dif2Fecha2ACT.Days;
                }
            }
            return difFechaDias;
        }
        /// <summary>
        /// Se pasan las fechas al formato correcto
        /// </summary>
        /// <param name="fecha">Fechas pasadas</param>
        /// <returns>String con la fecha en el formato correcto.</returns>
        public static string Put_Fecha_GoodFormat(string[]fecha)
        {
            string fecha_GoodFormat = "";
            for(int count = 0; count < 3; count++)
            {
                fecha_GoodFormat += fecha[count];
                if(count <2)
                {
                    fecha_GoodFormat += "/";
                }
            }
            return fecha_GoodFormat;
        }
    }
}
