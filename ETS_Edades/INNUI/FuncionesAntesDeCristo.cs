using System;

namespace INNUI.ETS_Edades
{
    public class FuncionesAntesDeCristo
    {
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
                                if ((mes % 2) == 0) //Si los meses son pares, significa que son todos 30 menos agosto, octubre y diciembre que son 31. 
                                {                //Tambien hemos tenido en cuenta a febrero, si el año es biciesto, febrero tiene 29 dias y si no lo es tiene 28.
                                    if (mes == 02)
                                    {
                                        if ( ((anio % 4 == 0) && (anio % 100 != 0)) || (anio % 400 == 0) )  //Comprobar si el año es bisiesto para febrero
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
                                            if ((mes == 08) || (mes == 10) || (mes == 12)) //Meses pares que terminen en 31
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
                return comprobacionFecha;
            }
        }

        public static int ObtenerAniosAntesDeCristo(string[] fechaAntesCristoPersona)
        {
            char[] separador = { '/', ' ' };
            DateTime fechaActual = DateTime.Now;
            string[] anioActualDividido = new string[0];
            int aniosDiferencias = 0;
            try
            {
                int convertirAnioPersonas = Int32.Parse(fechaAntesCristoPersona[2]);
                string fecha = fechaActual.ToString();
                anioActualDividido = fecha.Split(separador);
                int obtenerAnioActual = Int32.Parse(anioActualDividido[2]);

                aniosDiferencias = obtenerAnioActual - convertirAnioPersonas;

            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

            return aniosDiferencias;
        }

        public static int ObtenerDiasAntesDeCristo(int aniosDiferencias, string[] fechaAntesCristoPersona)
        {
            char[] Separador = { '/', ' ' };
            DateTime fechaActual = DateTime.Now;
            string[] anioActualDividido = new string[0];
            string fecha = fechaActual.ToString();
            anioActualDividido = fecha.Split(Separador);
            int obtenerAnioActual = Int32.Parse(anioActualDividido[2]);
            int obtenerMesActual = Int32.Parse(anioActualDividido[1]);
            int convertirAnioPersonas = Int32.Parse(fechaAntesCristoPersona[2]);
            int convertirMesPersonas = Int32.Parse(fechaAntesCristoPersona[1]);

            int sumaDias = 0;

            for (int contadorDias = convertirAnioPersonas; contadorDias < obtenerAnioActual; contadorDias++)
            {
                sumaDias = sumaDias + 365;

                if ((contadorDias % 4 == 0 && contadorDias % 100 != 0 || contadorDias % 400 == 0))
                {
                    sumaDias = sumaDias + 1;
                }

            }

            return sumaDias;
        }
    }
}
