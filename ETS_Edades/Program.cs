using System;

namespace ETS_Edades
{
    class Program
    {
        static void Main(string[] args)
        {

            int contadorMostrar = 1;
            bool correcto = false;
            DateTime FechaPersona1 = DateTime.Today;
            double diasPersona1 = 0;
            int aniosPersona1 = 0;
            DateTime FechaPersona2 = DateTime.Today;
            double diasPersona2 = 0;
            int aniosPersona2 = 0;
            while (!correcto)
            {
                FechaPersona1 = Funciones.LeerFechaNacimiento(contadorMostrar);
                diasPersona1 = Funciones.ObtenerDias(FechaPersona1);
                if(diasPersona1 <= 0)
                {
                    Console.WriteLine("Error, la persona aún no ha nacido\nDeberá introducir una nueva fecha correcta");
                }
                else
                {
                    aniosPersona1 = Funciones.ObtenerAnios(FechaPersona1);
                    Console.WriteLine("La persona {0} tiene {1} dias y {2} años", contadorMostrar, diasPersona1, aniosPersona1);
                    contadorMostrar++;
                    while (!correcto)
                    {
                        FechaPersona2 = Funciones.LeerFechaNacimiento(contadorMostrar);
                        diasPersona2 = Funciones.ObtenerDias(FechaPersona2);
                        if (diasPersona2 <= 0)
                        {
                            Console.WriteLine("Error, la persona aún no ha nacido\nDeberá introducir una nueva fecha correcta");
                        }
                        else
                        {
                            aniosPersona2 = Funciones.ObtenerAnios(FechaPersona2);
                            Console.WriteLine("La persona {0} tiene {1} dias y {2} años", contadorMostrar, diasPersona2, aniosPersona2);
                            correcto = true;
                        }
                    }
                }                
            }
            Console.Read();
        }
    }
}
