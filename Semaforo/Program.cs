using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Semaforo
{
    class Program
    {
      
        public static int s=0;
        public static SemaphoreSlim n = new SemaphoreSlim(0);
        static void Main(string[] args)
        {
            while (true)
            {
                s = 0;
                Thread t1 = new Thread(() => Somma());
                t1.Start();
                Thread t2 = new Thread(() => Numero_Random());
                t2.Start();
                while (t1.IsAlive) { }
                while (t2.IsAlive) { }
                Console.WriteLine(s);
             
                Console.ReadLine();
            }
        }
            public static void Somma()
            {
                 int a, b;
                Console.WriteLine("Inserisci un numero: ");
                 a = int.Parse(Console.ReadLine());
                Console.WriteLine("Inserisci il secondo numero: ");
                 b = int.Parse(Console.ReadLine());
                 s = a + b;
            Console.WriteLine($"a: {a} b: {b}, s:{s}");
                n.Release();
            }
        public static void Numero_Random()
        {
            int c;
            Random  r = new Random();
              c= r.Next(10, 99);
            n.Wait();
            Console.WriteLine($"c: {c}");

            s = s + c;
            Console.WriteLine($"s: {s}");
       

        }
    }
}
