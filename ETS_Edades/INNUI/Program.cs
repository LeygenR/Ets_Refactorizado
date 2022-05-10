using ICLUI.ETS_Edades;
using INNUI.ETS_Edades;
using System;

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
                int countPerson = 0;
                string[] fecha1 = new string[3];
                string[] fecha2 = new string[3];

                while (countPerson < 2)
                {
                    if (Controlador.MenuAC_DC(Messages.LANGUAGE))
                    {
                        if(countPerson.Equals(0))
                        {
                            fecha1 = TratarFechas.LeerFechaNacimientoDC(countPerson);
                        }
                        else
                        {
                            fecha2 = TratarFechas.LeerFechaNacimientoDC(countPerson);
                        }
                    }
                    else
                    {
                        if (countPerson.Equals(0))
                        {
                            fecha1 = TratarFechas.LeerFechaNacimientoAC(countPerson);
                        }
                        else
                        {
                            fecha2 = TratarFechas.LeerFechaNacimientoAC(countPerson);
                        }
                    }
                    countPerson++;
                }
            }
          

            int aniosDiferencias1 = 0;
            int diasDiferencias1 = 0;

            int aniosDiferencias2 = 0;
            int diasDiferencias2 = 0;

            string beaf = "";
            bool correcto = false;//booleano para el bucle de entrada de datos
            /*
            while (!correcto)//booleano para salir
            { 
                if (beaf == "DC")//fecha despues de cristo introducida
                {
                    if (contadorMostrar == 1)
                    {
                        diasPersona1 = FuncionesDespuesCristo.ObtenerDias(fechaPersona1);

                        if (diasPersona1 <= 0)
                        {
                            Messages.ShowError(8);
                        }
                        else
                        {
                            aniosPersona1 = FuncionesDespuesCristo.ObtenerAnios(fechaPersona1);
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
                            fechaPersona2 = TratarFechas.LeerFechaNacimientoDC(ref contadorMostrar);
                            diasPersona2 = FuncionesDespuesCristo.ObtenerDias(fechaPersona2);
                            if (diasPersona2 <= 0)//si los días son negativos es que aún no ha nacido, volver a pedir la fecha
                            {
                                Console.WriteLine("Error, la persona aún no ha nacido.\nDeberá introducir una nueva fecha correcta");
                            }
                            else
                            {
                                aniosPersona2 = FuncionesDespuesCristo.ObtenerAnios(fechaPersona2);
                                string msgShow2 = Messages.ShowMessageClient(msgShow2);
                                Console.WriteLine(msgShow2, contadorMostrar, diasPersona2, aniosPersona2);
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
                            fechaAntesCristoPersona1 = TratarFechas.LeerFechaNacimientoAC(ref contadorMostrar);
                            aniosDiferencias1 = FuncionesAntesDeCristo.ObtenerAniosAntesDeCristo(fechaAntesCristoPersona1);
                            diasDiferencias1 = FuncionesAntesDeCristo.ObtenerDiasAntesDeCristo(aniosDiferencias1, fechaAntesCristoPersona1);
                            string msgShow2 = Messages.ShowMessageClient(msgShow2);
                            Console.WriteLine(msgShow2, contadorMostrar, diasDiferencias1, aniosDiferencias1);
                        }

                        if (contadorMostrar == 2)
                        {
                            fechaAntesCristoPersona2 = TratarFechas.LeerFechaNacimientoAC(ref contadorMostrar);
                            aniosDiferencias2 = FuncionesAntesDeCristo.ObtenerAniosAntesDeCristo(fechaAntesCristoPersona2);
                            diasDiferencias2 = FuncionesAntesDeCristo.ObtenerDiasAntesDeCristo(aniosDiferencias2, fechaAntesCristoPersona2);
                            string msgShow2 = Messages.ShowMessageClient(msgShow2);
                            Console.WriteLine(msgShow2, contadorMostrar, diasDiferencias2, aniosDiferencias2);
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
                    if (fechaAntesCristoPersona1.Length != 0)//comprobar que la primera persona sus datos sean antes de cristo
                    {
                        if (fechaAntesCristoPersona2.Length != 0)//comprobar que la segunda persona sus datos sean antes de cristo
                        {
                            Controlador.MostrarDiferenciaEdades(diasDiferencias1, aniosDiferencias1, diasDiferencias2, aniosDiferencias2);//mostrar los datos antes de cristo
                            correcto = true;
                        }
                        else//los datos de la segunda persona son después de cristo
                        {
                            Controlador.MostrarDiferenciaEdades(diasDiferencias1, aniosDiferencias1, diasPersona2, aniosPersona2);
                            correcto = true;
                        }

                    }
                    else
                    {
                        if (fechaAntesCristoPersona2.Length != 0)//los datos de la primera persona son despues de cristo y de la segunda también
                        {
                            Controlador.MostrarDiferenciaEdades(diasPersona1, aniosPersona1, diasDiferencias2, aniosDiferencias2);
                            correcto = true;
                        }
                        else//Ambos datos de las personas son después de cristo
                        {
                            Controlador.MostrarDiferenciaEdades(diasPersona1, aniosPersona1, diasPersona2, aniosPersona2);
                            correcto = true;
                        }
                    }
                }
            }
            */
            Console.WriteLine("\n");
            Console.WriteLine("Pulse cualquier tecla para finalizar el programa...");
            Console.ReadKey();
        }
    }
}
