using ICLUI.ETS_Edades;
using INNUI.ETS_Edades;

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
                bool fecha1Despues_Cristo = true;
                bool fecha2Despues_Cristo = true;
                string[] fecha1 = new string[3];
                string[] fecha2 = new string[3];
                if (Controlador.PedirFechasControlador(ref fecha1, ref fecha2, ref fecha1Despues_Cristo, ref fecha2Despues_Cristo))
                {
                    int[] difAnhos = TratarFechas.CalcularAnhosDif(fecha1, fecha2, fecha1Despues_Cristo, fecha2Despues_Cristo);
                    int[] difDias = TratarFechas.CalcularDiasDif(fecha1, fecha2, fecha1Despues_Cristo, fecha2Despues_Cristo);
                    Controlador.MostrarResultadoControlador(fecha1, fecha2, difAnhos, difDias);
                }
            }
            else
            {
                //Error
            }
            
            /*
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
                aniosDiferencias1 = FuncionesAntesDeCristo.ObtenerAniosAntesDeCristo(fechaAntesCristoPersona1);
                diasDiferencias1 = FuncionesAntesDeCristo.ObtenerDiasAntesDeCristo(aniosDiferencias1, fechaAntesCristoPersona1);
                string msgShow2 = Messages.ShowMessageClient(msgShow2);
                Console.WriteLine(msgShow2, contadorMostrar, diasDiferencias1, aniosDiferencias1);

                aniosDiferencias2 = FuncionesAntesDeCristo.ObtenerAniosAntesDeCristo(fechaAntesCristoPersona2);
                diasDiferencias2 = FuncionesAntesDeCristo.ObtenerDiasAntesDeCristo(aniosDiferencias2, fechaAntesCristoPersona2);
                string msgShow2 = Messages.ShowMessageClient(msgShow2);
                Console.WriteLine(msgShow2, contadorMostrar, diasDiferencias2, aniosDiferencias2);
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("\n");
                Console.WriteLine("Escribe una tecla para continuar a la persona " + contadorMostrar);//siguiente persona
                Console.ReadKey();
                Console.Clear();

                Controlador.MostrarDiferenciaEdades(diasDiferencias1, aniosDiferencias1, diasDiferencias2, aniosDiferencias2);
                Controlador.MostrarDiferenciaEdades(diasDiferencias1, aniosDiferencias1, diasPersona2, aniosPersona2);
                Controlador.MostrarDiferenciaEdades(diasPersona1, aniosPersona1, diasDiferencias2, aniosDiferencias2);
                Controlador.MostrarDiferenciaEdades(diasPersona1, aniosPersona1, diasPersona2, aniosPersona2);
            */
        }
            
    }
}