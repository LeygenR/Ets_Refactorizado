using System;
using INNUI.ETS_Edades;
using ICLUI.ETS_Edades;

namespace ETS_Edades
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.ShowMenu(Messages.LANGUAGES_CODE, Messages.LANGUAGES);
            Messages.LANGUAGE = Menu.SelectOption(Messages.LANGUAGES_CODE);
            if (!Messages.LANGUAGE.Equals(-1))
            {
               
            }
            int contadorMostrar = 1;//contador para ir pidiendo persona
            bool correcto = false;//booleano para el bucle de entrada de datos
                                  //crear las variables para cada persona para las funciones después de cristo
            DateTime FechaPersona1 = DateTime.Today;
            double diasPersona1 = 0;
            int aniosPersona1 = 0;

            DateTime FechaPersona2 = DateTime.Today;
            double diasPersona2 = 0;
            int aniosPersona2 = 0;

            //crear las variables para cada persona para las funciones antes de cristo
            string[] FechaAntesCristoPersona1 = new string[0];
            string[] FechaAntesCristoPersona2 = new string[0];

            int AnniosDiferencias1 = 0;
            int DiasDiferencias1 = 0;

            int AniosDiferencias2 = 0;
            int DiasDiferencias2 = 0;

            string beaf =  "";
            while (!correcto)//booleano para salir
            {
                if (contadorMostrar <= 2)
                {
                    beaf = Menu.TypeDCorAC();
                }

                if (beaf == "DC")//fecha despues de cristo introducida
                {
                    if (contadorMostrar == 1)
                    {
                        FechaPersona1 = TratarFechas.LeerFechaNacimientoDC(ref contadorMostrar);
                        diasPersona1 = FuncionesDespuesCristo.ObtenerDias(FechaPersona1);

                        if (diasPersona1 <= 0)//si los días son negativos es que aún no ha nacido, volver a pedir la fecha
                        {
                            Messages.ShowError(8);
                        }
                        else
                        {
                            aniosPersona1 = FuncionesDespuesCristo.ObtenerAnios(FechaPersona1);
                            Messages.ShowMessage(11);

                            contadorMostrar++;

                            Console.WriteLine("\n");
                            Messages.ShowMessage(12);//pasamos a la siguiente persona
                        }
                    }
                    else
                    {
                        if (contadorMostrar == 2)
                        {
                            FechaPersona2 = TratarFechas.LeerFechaNacimientoDC(ref contadorMostrar);
                            diasPersona2 = FuncionesDespuesCristo.ObtenerDias(FechaPersona2);
                            if (diasPersona2 <= 0)//si los días son negativos es que aún no ha nacido, volver a pedir la fecha
                            {
                                Console.WriteLine("Error, la persona aún no ha nacido\nDeberá introducir una nueva fecha correcta");
                            }
                            else
                            {
                                aniosPersona2 = FuncionesDespuesCristo.ObtenerAnios(FechaPersona2);
                                Console.WriteLine("La persona {0} tiene {1} dias y {2} años", contadorMostrar, diasPersona2, aniosPersona2);
                                contadorMostrar++;
                            }
                        }
                    }
                }
                else
                {
                    if (beaf == "AC")//fecha antes de cristo introducida
                    {
                        if (contadorMostrar == 1)
                        {
                            FechaAntesCristoPersona1 = TratarFechas.LeerFechaNacimientoAC(ref contadorMostrar);
                            AnniosDiferencias1 = FuncionesAntesDeCristo.ObtenerAniosAntesDeCristo(FechaAntesCristoPersona1);
                            DiasDiferencias1 = FuncionesAntesDeCristo.ObtenerDiasAntesDeCristo(AnniosDiferencias1, FechaAntesCristoPersona1);
                            Console.WriteLine("La persona {0} tiene {1} dias y {2} años", contadorMostrar, DiasDiferencias1, AnniosDiferencias1);
                        }

                        if (contadorMostrar == 2)
                        {
                            FechaAntesCristoPersona2 = TratarFechas.LeerFechaNacimientoAC(ref contadorMostrar);
                            AniosDiferencias2 = FuncionesAntesDeCristo.ObtenerAniosAntesDeCristo(FechaAntesCristoPersona2);
                            DiasDiferencias2 = FuncionesAntesDeCristo.ObtenerDiasAntesDeCristo(AniosDiferencias2, FechaAntesCristoPersona2);
                            Console.WriteLine("La persona {0} tiene {1} dias y {2} años", contadorMostrar, DiasDiferencias2, AniosDiferencias2);
                            Console.ReadKey();
                            Console.Clear();
                        }

                        contadorMostrar++;
                        if (contadorMostrar <= 2)
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("Escribe una tecla para continuar a la persona " + contadorMostrar);//siguiente persona
                            Console.ReadKey();
                            Console.Clear();
                        }

                    }
                }

                if (contadorMostrar > 2)
                {
                    if (FechaAntesCristoPersona1.Length != 0)//comprobar que la primera persona sus datos sean antes de cristo
                    {
                        if (FechaAntesCristoPersona2.Length != 0)//comprobar que la segunda persona sus datos sean antes de cristo
                        {
                            MostrarDiferenciaEdades(DiasDiferencias1, AnniosDiferencias1, DiasDiferencias2, AniosDiferencias2);//mostrar los datos despues de cristo
                            correcto = true;
                        }
                        else//los datos de la segunda persona son después de cristo
                        {
                            MostrarDiferenciaEdades(DiasDiferencias1, AnniosDiferencias1, diasPersona2, aniosPersona2);
                            correcto = true;
                        }

                    }
                    else
                    {
                        if (FechaAntesCristoPersona2.Length != 0)//los datos de la primera persona son despues de cristo y de la segunda también
                        {
                            MostrarDiferenciaEdades(diasPersona1, aniosPersona1, DiasDiferencias2, AniosDiferencias2);
                            correcto = true;
                        }
                        else//Ambos datos de las personas son después de cristo
                        {
                            MostrarDiferenciaEdades(diasPersona1, aniosPersona1, diasPersona2, aniosPersona2);
                            correcto = true;
                        }
                    }
                }
            }
            Console.WriteLine("\n");
            Console.WriteLine("Pulse cualquier tecla para finalizar el programa...");
            Console.ReadKey();
        }

        private static void MostrarDiferenciaEdades(double diasPersona1, int aniosPersona1, double diasPersona2, int aniosPersona2)
        {
            Console.Clear();
            double diasDiferencia = Math.Abs(diasPersona1 - diasPersona2);
            int aniosDiferencia = Math.Abs(aniosPersona1 - aniosPersona2);
            Console.WriteLine("La diferencia entre las dos personas es de {0} días y de {1} años", diasDiferencia, aniosDiferencia);
        }
    }
}
