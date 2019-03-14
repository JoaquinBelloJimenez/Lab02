using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PROGRAMACIÓN INICIANDOSE");

            Tareas tareas = new Tareas();
            //Crear objeto tareas                  

            Random rnd = new Random();
            for (var i = 0; i < 500; i++)
            {
                //TODO Calcula un número aleatorio entre 1 y 3                
                if (rnd.Next(1, 4) == 1){ Metodos.FindPrimeNumber(1000); }
                else if (rnd.Next(1, 4) == 2){ Metodos.Slow(); }
                else if (rnd.Next(1, 4) == 3){ Metodos.CpuIntensive(); }                
                //TODO Si el número aleatorio es 1, añade al objeto tareas la tarea retornada por el método FindPrimeNumber
                //TODO Si el número aleatorio es 2, añade al objeto tareas la tarea retornada por el método Slow
                //TODO Si el número aleatorio es 3, añade al objeto tareas la tarea retornada por el método CpuIntensive

            }

            Console.WriteLine("PROGRAMACIÓN FINALIZADA");

            //Comprueba las estadísticas del gestor de tareas. 
            //Refresca los resultado pulsado cualquier teclas, F12 para finalizar.
            while (Console.ReadKey().Key != ConsoleKey.F12)
            {
                Console.Clear();
                Console.WriteLine("Creadas".PadRight(20) + tareas.Creadas.ToString().PadLeft(6));
                Console.WriteLine("Corriendo".PadRight(20) + tareas.Corriendo.ToString().PadLeft(6));
                Console.WriteLine("Es Espera".PadRight(20) + tareas.EnEspera.ToString().PadLeft(6));
                Console.WriteLine("Canceladas".PadRight(20) + tareas.Canceladas.ToString().PadLeft(6));
                Console.WriteLine("Finalizadas".PadRight(20) + tareas.Finalizadas.ToString().PadLeft(6));
            }
        }
    }

    //TODO Crea una clase instanciable llamada Tareas que herede de una Lista de Tareas

    //TODO Añade una propiedad de solo lectura que retorna un entero y se llama Creadas
    //     Retorna del propio objeto el número de tareas con el Status igual Create utilizando LINQ

    //TODO Añade una propiedad de solo lectura que retorna un entero y se llama Corriendo
    //     Retorna del propio objeto el número de tareas con el Status igual Running utilizando LINQ

    //TODO Añade una propiedad de solo lectura que retorna un entero y se llama Canceladas
    //     Retorna del propio objeto el número de tareas con el Status igual Canceled utilizando LINQ

    //TODO Añade una propiedad de solo lectura que retorna un entero y se llama Finalizadas
    //     Retorna del propio objeto el número de tareas con el Status igual RanToCompletion utilizando LINQ

    //TODO Añade una propiedad de solo lectura que retorna un entero y se llama EnEspera
    //     Retorna del propio objeto el número de tareas con el Status igual WaitingForActivation o WaitingForChildrenToComplete o WaitingToRun utilizando LINQ




    //TODO Convierte los métodos para que retornen una tareas iniciadas
    public static class Metodos
    {
        public static long FindPrimeNumber(int n)
        {
            int count = 0;
            long a = 2;
            while (count < n)
            {
                long b = 2;
                int prime = 1;
                while (b * b <= a)
                {
                    if (a % b == 0)
                    {
                        prime = 0;
                        break;
                    }
                    b++;
                }
                if (prime > 0)
                {
                    count++;
                }
                a++;
            }
            return (--a);
        }

        public static Task Slow()
        {                        
            Task slow = Task.Run(() => {
                var end = DateTime.Now + TimeSpan.FromSeconds(10);
                while (DateTime.Now < end) ;
            });

            return slow;


        }
        public static Task CpuIntensive()
        {
            Task cpuIntensive = Task.Run(() =>
            {
                var startDt = DateTime.Now;

                while (true)
                {
                    if ((DateTime.Now - startDt).TotalSeconds >= 10)
                        break;
                }
            });

            return cpuIntensive;
            
        }
    }

    public class ListaTareas
    {
        int Creadas { get; }        
        int Corriendo { get; }        
        int Canceladas { get; }        
        int Finalizadas { get; }        
        int EnEspera { get; }        
    }

    public class Tareas : ListaTareas
    {
        public int Creadas {get {; }}
        public int Corriendo {get {; }}
        public int Canceladas { get {; } }
        public int Finalizadas { get {; } }
        public int EnEspera { get {; } }
    }
}
