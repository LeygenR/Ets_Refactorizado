using System;

namespace ICLUI.ETS_Edades
{
    /// <summary>
    /// Clase con los métodos de mostrado y opciones de idiomas.
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Mostrado del menú de idiomas
        /// </summary>
        /// <param name="languageCode">Código referente para solicitar el idioma</param>
        /// <param name="language">Los idioma</param>
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
            _ = Console.ReadKey(true);
        }
        /// <summary>
        /// Método para buscar la posición del idioma en el array.
        /// </summary>
        /// <param name="languageCode">Código referente para solicitar el idioma</param>
        /// <returns>Posición del idioma en el array</returns>
        public static int SelectOption(string option, string[] languageCode)
        {
            int posIdioma;

            posIdioma = Array.IndexOf(languageCode, option);
            if (posIdioma.Equals(-1))
            {
                Console.WriteLine("This language is not supported.");
                _ = Console.ReadKey(true);
            }
            return (posIdioma);
        }
    }
}

