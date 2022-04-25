using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICLUI.ETS_Edades
{

    class Messages
    {
        public static string LANGUAGUE_TEXTS = "Idiomas fechas.csv";

        public static string[] FILEDATA = Fichero.ReadingFile(LANGUAGUE_TEXTS);
        public static string[] LANGUAGES_CODE = FILEDATA[0].Split(',');
        public static string[] LANGUAGES = FILEDATA[1].Split(',');
        public static int LANGUAGE;

        public static void ShowAskDate(int person)
        {
            string[] texts_language = FILEDATA[3].Split(',');
            string[] dateFormat = FILEDATA[2].Split(',');
            Console.WriteLine(texts_language[LANGUAGE] + " (" + dateFormat[LANGUAGE] + ")", person);
        }
        public static void ShowAskPeriod()
        {
            string[] texts_language = FILEDATA[5].Split(',');
            Console.WriteLine(texts_language[LANGUAGE]);
        }
        public static void ShowError(int error)
        {
            string[] texts_language = FILEDATA[error].Split(',');
            Console.WriteLine(texts_language[LANGUAGE]);
            _ = Console.ReadKey(true);
        }
        public static void ShowMessage(int numMessage)
        {
            string[] texts_language = FILEDATA[numMessage].Split(',');
            Console.WriteLine(texts_language[LANGUAGE]);
            _=Console.ReadKey(true);
        }
    }
}
