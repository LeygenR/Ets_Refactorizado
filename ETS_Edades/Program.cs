using System;

namespace ETS_Edades
{
    class Program
    {
        static void Main(string[] args)
        {

            int contadorMostrar = 1;//contador para ir pidiendo persona
            bool correcto = false;//booleano para el bucle de entrada de datos
            //crear las variables para cada persona
            DateTime FechaPersona1 = DateTime.Today;
            double diasPersona1 = 0;
            int aniosPersona1 = 0;
            DateTime FechaPersona2 = DateTime.Today;
            double diasPersona2 = 0;
            int aniosPersona2 = 0;
            while (!correcto)
            {
                FechaPersona1 = FuncionesDespuesCristo.LeerFechaNacimiento(contadorMostrar);
                diasPersona1 = FuncionesDespuesCristo.ObtenerDias(FechaPersona1);
                if(diasPersona1 <= 0)//si los días son negativos es que aún no ha nacido, volver a pedir la fecha
                {
                    Console.WriteLine("Error, la persona aún no ha nacido\nDeberá introducir una nueva fecha correcta");
                }
                else
                {
                    aniosPersona1 = FuncionesDespuesCristo.ObtenerAnios(FechaPersona1);
                    Console.WriteLine("La persona {0} tiene {1} dias y {2} años", contadorMostrar, diasPersona1, aniosPersona1);
                    contadorMostrar++;//pasamos a la siguiente persona
                    Console.WriteLine("Escribe una tecla para continuar a la persona "+ contadorMostrar);//siguiente persona
                    Console.ReadKey();
                    Console.Clear();
                    while (!correcto)
                    {
                        FechaPersona2 = FuncionesDespuesCristo.LeerFechaNacimiento(contadorMostrar);
                        diasPersona2 = FuncionesDespuesCristo.ObtenerDias(FechaPersona2);
                        if (diasPersona2 <= 0)//si los días son negativos es que aún no ha nacido, volver a pedir la fecha
                        {
                            Console.WriteLine("Error, la persona aún no ha nacido\nDeberá introducir una nueva fecha correcta");
                        }
                        else
                        {
                            aniosPersona2 = FuncionesDespuesCristo.ObtenerAnios(FechaPersona2);
                            Console.WriteLine("La persona {0} tiene {1} dias y {2} años", contadorMostrar, diasPersona2, aniosPersona2);
                            correcto = true;//informacion de las dos personas correctas, salimos del bucle
                            Console.WriteLine("Escribe una tecla para continuar a la diferencia de edades");//pedimos avanzar para mostrar la siguiente información y borrar la presentada
                            Console.ReadKey();
                        }
                    }
                }                
            }
            FuncionesDespuesCristo.MostrarDiferenciaEdades(diasPersona1, aniosPersona1, diasPersona2, aniosPersona2);
            Console.ReadKey();
        }
    }
}
