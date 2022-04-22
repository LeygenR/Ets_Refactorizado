using System;

namespace INNUI.ETS_Edades
{
    public class FuncionesAntesDeCristo
    {
        public static string[] LeerFechaNacimiento(int contadorMostrar)
        {
            //DateTime fechaNacimiento = DateTime.Now;//la inicializo con la fecha actual para que no de errores
            bool leer = false;//booleano para salir solo cuando lea una fecha válida          
            string[] Dividir = new string[0];
            do
            {
                Console.WriteLine("Introduzca la fecha de la persona {0} en el formato correcto(dd/MM/yyyy, por ejemplo 01/01/-523)", contadorMostrar);
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
                                if (AntesDeCristoComprobacion(Dividir))
                                {
                                    leer = true;//fecha correcta salimos
                                }
                                else
                                {
                                    Console.WriteLine("La fecha introducida es incorrecta.. vueve a introducirla...");
                                }
                            }
                            else
                            {
                                Console.WriteLine("El año debe ser negativo");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ha introducido la fecha en el formato incorrecto... Vuelve a introducirlo");
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }

            } while (!leer);
            return Dividir;
        }

        public static bool AntesDeCristoComprobacion(string[] Dividir)
        {
            int Dia = 0;
            int Año = 0;
            bool ComprobacionFecha = false;
            if (Int32.TryParse(Dividir[1], out int Mes))
            {
                if (Mes >= 1)
                {
                    if (Mes <= 12)
                    {
                        if (Int32.TryParse(Dividir[0], out Dia))
                        {
                            if (Dia > 0)
                            {
                                if ((Mes % 2) == 0) //Si los meses son pares, significa que son todos 30 menos agosto, octubre y diciembre que son 31. 
                                {                   //Tambien hemos tenido en cuenta a febrero, si el año es biciesto, febrero tiene 29 dias y si no lo es tiene 28.
                                    if (Int32.TryParse(Dividir[0], out Dia))
                                    {
                                        if (Mes == 02)
                                        {
                                            if (Int32.TryParse(Dividir[2], out Año))
                                            {
                                                if (Año % 4 == 0 && Año % 100 != 0 || Año % 400 == 0)  //Comprobar si el año es bisiesto para febrero
                                                {
                                                    if (Dia <= 29)
                                                    {
                                                        ComprobacionFecha = true;
                                                    }
                                                }
                                                else
                                                {

                                                    if (Dia <= 28)
                                                    {
                                                        ComprobacionFecha = true;
                                                    }

                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (Dia <= 30)
                                            {
                                                ComprobacionFecha = true;
                                            }
                                            else
                                            {
                                                if ((Mes == 08) || (Mes == 10) || (Mes == 12)) //Meses pares que terminen en 31
                                                {
                                                    if (Dia <= 31)
                                                    {
                                                        ComprobacionFecha = true;
                                                    }

                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (Int32.TryParse(Dividir[0], out Dia))
                                    {

                                        if (Mes < 09)
                                        {
                                            if (Dia <= 31)
                                            {
                                                ComprobacionFecha = true;
                                            }
                                        }
                                        else
                                        {
                                            if (Dia <= 30)
                                            {
                                                ComprobacionFecha = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            return ComprobacionFecha;
        }

        public static int ObtenerAniosAntesDeCristo(string[] FechaAntesCristoPersona)
        {
            char[] Separador = { '/', ' ' };
            DateTime fechaActual = DateTime.Now;
            string[] AñoActualDividido = new string[0];
            int AñosDiferencias = 0;
            try
            {
                int ConvertirAñoPersonas = Int32.Parse(FechaAntesCristoPersona[2]);
                string Fecha = fechaActual.ToString();
                AñoActualDividido = Fecha.Split(Separador);
                int ObtenerAñoActual = Int32.Parse(AñoActualDividido[2]);

                AñosDiferencias = ObtenerAñoActual - ConvertirAñoPersonas;

            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

            return AñosDiferencias;
        }

        public static int ObtenerDiasAntesDeCristo(int AñosDiferencias, string[] FechaAntesCristoPersona)
        {
            char[] Separador = { '/', ' ' };
            DateTime fechaActual = DateTime.Now;
            string[] AñoActualDividido = new string[0];
            string Fecha = fechaActual.ToString();
            AñoActualDividido = Fecha.Split(Separador);
            int ObtenerAñoActual = Int32.Parse(AñoActualDividido[2]);
            int ObtenerMesActual = Int32.Parse(AñoActualDividido[1]);
            int ConvertirAñoPersonas = Int32.Parse(FechaAntesCristoPersona[2]);
            int ConvertirMesPersonas = Int32.Parse(FechaAntesCristoPersona[1]);

            int SumaDias = 0;

            for (int ContadorDias = ConvertirAñoPersonas; ContadorDias < ObtenerAñoActual; ContadorDias++)
            {
                SumaDias = SumaDias + 365;

                if ((ContadorDias % 4 == 0 && ContadorDias % 100 != 0 || ContadorDias % 400 == 0))
                {
                    SumaDias = SumaDias + 1;
                }

            }

            return SumaDias;
        }
    }
}
