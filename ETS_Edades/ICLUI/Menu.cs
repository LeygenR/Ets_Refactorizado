using System;

namespace ICLUI.ETS_Edades
{
    class Menu
    {
        public static void ShowMenu(string[] languageCode, string[] language)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("            SELECT LANGUAGE            ");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("---------------------------------------");
            for (int count = 0; count < languageCode.Length; count++)
            {
                Console.WriteLine("{0}-{1}", languageCode[count], language[count]);
            }
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("---------------------------------------");
        }

        public static int SelectOption(string[] languageCode)
        {
            int posIdioma;

            string option = Console.ReadLine();
            posIdioma = Array.IndexOf(languageCode, option);
            if (posIdioma.Equals(-1))
            {
                Console.WriteLine("This language is not supported.");
                _ = Console.ReadKey(true);
            }
            return (posIdioma);
        }

        public static string TypeDCorAC()
        {
            Messages.ShowAskPeriod();
            string beaf;
            bool valid = false;
            do
            {
                beaf = Console.ReadLine();
                if (!beaf.Equals(""))
                {
                    if (beaf.Equals("DC") || beaf.Equals("AC"))
                    {
                        valid = true;
                    }
                }
                else
                {
                    Messages.ShowError(9);
                }
            }
            while (!valid);

            return beaf;
        }
            
    }

}

