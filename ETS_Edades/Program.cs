using System;

namespace ETS_Edades
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime FechaPersona1 = Funciones.LeerFechaNacimiento();
            double dias = 0;
            double anios = 0;
            Funciones.ObtenerDiasYAnios(FechaPersona1,ref dias,ref anios);
            Console.WriteLine("La fecha {0} tiene {1} dias y {2} años",FechaPersona1,Math.Floor(dias),anios);
            Console.Read();
        }
    }
}
