using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICLUI.ETS_Edades
{
    class Messages
    {
        public static void ShowAskDate(string[]fileData,int language)
        {
            string[] texts_language = fileData[3].Split(',');
            string[] dateFormat = fileData[2].Split(',');
            Console.WriteLine(texts_language[language] + " (" + dateFormat[language] + ")", "1");
        }
        public static void ShowAskPeriod(string []fileData,int language)
        {
            string[] texts_language = fileData[5].Split(',');
            Console.WriteLine(texts_language[language]);
        }
    }
}
