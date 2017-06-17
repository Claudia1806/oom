using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using System.Windows.Forms;
using static System.Console;

namespace Task6
{
    public static class TasksExample
    {
        public static void Run()
        {
            var random = new Random(); //neue Instanz von random

            var xs = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var tasks = new List<Task<int>>(); //Task: wird in der Zukunft verfügbar sein

            foreach (var x in xs)
            {
                var task = Task.Run(() =>
                {
                    WriteLine($"computing result for {x}"); //listet int array auf
                    Task.Delay(TimeSpan.FromSeconds(5.0 + random.Next(10))).Wait(); //Berechnung dauert 5 Sekunden
                    WriteLine($"done computing result for {x}"); //Ausgabe für welches x die Berechnung durchgeführt wurde
                    return x * x; //Berechnung
                });

                tasks.Add(task); //Objekte werden an das Ende der Liste gehängt  
            }

            WriteLine("doing something else ...");

            var tasks2 = new List<Task<int>>();
            foreach (var task in tasks.ToArray())
            {
                tasks2.Add(
                    task.ContinueWith(t => { WriteLine($"result is {t.Result}"); return t.Result; }) //Ergebnis wird ausgegeben
                );
            }

            var cts = new CancellationTokenSource(); //neue Instanz
            var primeTask = ComputePrimes(cts.Token);

            ReadLine(); //Eingabe auf Keyboard
            cts.Cancel(); //ComputePrimes stoppt
            WriteLine("canceled ComputePrimes");

            ReadLine();
        }

        public static Task<bool> IsPrime(int x, CancellationToken ct)
        {
            return Task.Run(() => 
            {
                for (var i = 2; i < x - 1; i++) //Ermittlung Primzahlen
                {
                    ct.ThrowIfCancellationRequested(); //wenn ReadLine true liefert, wird die Operation gecancelled
                    if (x % i == 0) return false; //keine Primzahl
                }
                return true; //Primzahl
            }, ct);
        }

        public static async Task ComputePrimes(CancellationToken ct)
        {
            for (var i = 10000; i < int.MaxValue; i++)
            {
                ct.ThrowIfCancellationRequested(); //wenn ReadLine true liefert, wird die Operation gecancelled
                if (await IsPrime(i, ct)) WriteLine($"prime number: {i}");//await wie ContinueWith, keyword async notwendig; wartet auf eine Primzahl
            }
        }
    }
}
