using ICLUI.ETS_Edades;
using System;

namespace INNUI.ETS_Edades
{
    class Controlador
    {
        public static void MostrarDiferenciaEdades(double diasPersona1, int aniosPersona1, double diasPersona2, int aniosPersona2)
        {
            string msgshow = Messages.ShowMessageClient();

            Console.Clear();
            double diasDiferencia = Math.Abs(diasPersona1 - diasPersona2);
            int aniosDiferencia = Math.Abs(aniosPersona1 - aniosPersona2);
            Console.WriteLine(msgshow, diasDiferencia, aniosDiferencia);
        }

        public static bool MenuAC_DC(int language)
        {
            string[] texts_antesCristo = Messages.FILEDATA[20].Split(',');
            string[] texts_despuesCristo = Messages.FILEDATA[21].Split(',');
            string despuesCristo = texts_despuesCristo[language];
            string antesCristo = texts_antesCristo[language];

            bool isAfterChrist = false;
            if (TratarFechas.IsAfterChrist(antesCristo, despuesCristo))
            {
                isAfterChrist = true;
            }
            return isAfterChrist;
        }

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
                        if (int.TryParse(Dividir[2], out int Anio))
                        {
                            if (Anio < 0)
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
    }
}
