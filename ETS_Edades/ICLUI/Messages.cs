using System;

namespace ICLUI.ETS_Edades
{
    /// <summary>
    /// Clase con los distintos mensajes que se pueden presentar en distintos idiomas.
    /// </summary>
    class Messages
    {
        public static string LANGUAGUE_TEXTS = "Idiomas fechas.csv"; //Fichero con los idiomas.

        public static string[] FILEDATA = Fichero.ReadingFile(LANGUAGUE_TEXTS); //Llamamos al método con el que guardamos el contenido del fichero.
        public static string[] LANGUAGES_CODE = FILEDATA[0].Split(','); //Códigos de idiomas
        public static string[] LANGUAGES = FILEDATA[1].Split(','); //Nombre de los Idiomas
        public static int LANGUAGE;
        /// <summary>
        /// Método con mensaje de solicitar fecha. (Varios Idiomas)
        /// </summary>
        /// <param name="person">Parámetro que indica por la persona que vamos en la pedida de fechas.</param>
        public static void ShowAskDate(int person)
        {
            string[] texts_language = FILEDATA[3].Split(',');
            string[] dateFormat = FILEDATA[2].Split(',');
            Console.WriteLine(texts_language[LANGUAGE] + " (" + dateFormat[LANGUAGE] + ")", person);
        }
        /// <summary>
        /// Solicitud de época, si desea antes o después de cristo.
        /// </summary>
        public static void ShowAskPeriod()
        {
            string[] texts_language = FILEDATA[5].Split(',');
            Console.WriteLine(texts_language[LANGUAGE]);
        }
        /// <summary>
        /// Muestra un error dependiendo de la situación o tipo de error.
        /// </summary>
        /// <param name="error">Número del error a mostrar (Errores incluidos en el array de lenguajes, con su respecto idioma)</param>
        public static void ShowError(int error)
        {
            string[] texts_language = FILEDATA[error].Split(',');
            Console.WriteLine(texts_language[LANGUAGE]);
            _ = Console.ReadKey(true);
        }
        /// <summary>
        /// Mostrado final con las fechas, diferencias de días y años.
        /// </summary>
        /// <param name="fecha1">Fecha persona 1.</param>
        /// <param name="fecha2">Fecha persona 2.</param>
        /// <param name="difAnhos">Diferencia de anhos entre las dos fechas y cada fecha con respecto a la actual.</param>
        /// <param name="difDias">Diferencia de días enre las dos fechas y cada fecha con respecto a la actual.</param>
        public static void ShowResult(string fecha1, string fecha2,int[]difAnhos,int[]difDias)
        {
            string[] text_result = FILEDATA[12].Split(',');       
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine(text_result[LANGUAGE],fecha1,fecha2,difAnhos[0],difDias[0]);
            Console.WriteLine("---------------------------------------------------------------");
            text_result = FILEDATA[11].Split(',');
            for(int count = 1; count <= 2;count++)
            {
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine(text_result[LANGUAGE],count,difDias[count], difAnhos[count]);
                Console.WriteLine("---------------------------------------------------------------");
            }
            _ = Console.ReadKey(true);
        }
    }
}
