using System;
using System.IO;
using System.Text;

namespace ICLUI.ETS_Edades
{
    class Fichero
    {
        public static string[] ReadingFile(string fichero)
        {
            string[] textFile = new string[0];
            try
            {
                StreamReader SRead = new StreamReader(fichero, Encoding.Default);
                while (!SRead.EndOfStream)
                {
                    Array.Resize(ref textFile, textFile.Length + 1);
                    textFile[textFile.Length - 1] = SRead.ReadLine();
                }
                SRead.Close();
            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.Message);
                Console.ReadKey(true);
                textFile = null;
            }

            return textFile;
        }
    }
}
