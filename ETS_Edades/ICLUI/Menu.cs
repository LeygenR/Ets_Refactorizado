using System;

namespace ICLUI.ETS_Edades
{
    class Menu
    {
        public static void ShowMenu(string[] languageCode, string[] language)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("              SELECT LANGUAGE          ");
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
            Messages.
            string beaf = "";

            if (beaf != "")
            {
                if (beaf == "DC")
                {
                    
                }
                else
                {
                    if (beaf == "AC")
                    {
                        
                    }
                }
            }
            else
            {
                Console.WriteLine("");
            }

        }
            
    }

}

