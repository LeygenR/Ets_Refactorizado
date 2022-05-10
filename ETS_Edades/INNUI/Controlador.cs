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
            if(TratarFechas.IsAfterChrist(antesCristo,despuesCristo))
            {
                isAfterChrist = true;
            }
            return isAfterChrist;
        }

    }
}
