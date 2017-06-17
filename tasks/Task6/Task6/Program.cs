using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Subjects;


namespace Task6
{
    class Program
    {
        private static IDress[] Dresses => new IDress[]
        {
            new Dirndl("Dirndl Pink",36, 59.90m),
            new Dirndl("Tiroler Dirndl",38, 99.90m),
            new Dirndl("Salzburger Dirndl",34, 79.90m),
            new Abendkleid("Abendkleid",32, 40.00m)
        };

        static int Main(string[] args)
        {
            RunTaskExample();
            RunRXExample();
            RunSerialization();
                        
            return 0;
        }

        #region Serialization
        private static void RunSerialization()
        {
            var d = new Dirndl("Marchegg Dirndl", 40, 49.90m);
            var e = new Abendkleid("Kleines Schwarzes", 42, 34.40m);
            d.Print();
            e.Print();

            foreach (var dress in Dresses)
            {
                Console.WriteLine();
                dress.Print();
            }

            Serialization.Run(Dresses);
        }
        #endregion

        private static void RunTaskExample()
        {
            TasksExample.Run();
        }

        private static void RunRXExample()
        {
            BackGroundwork.StartBackgroundWork();

            var subject = new Subject<IDress>();

            subject
                .Where(dress => dress.Size < 37)
                .Subscribe(filteredDirndl =>
                {
                    Thread.Sleep(1000);
                    filteredDirndl.Print();
                    Console.WriteLine();
                });

            foreach (var dress in Dresses)
            {
                subject.OnNext(dress);
            }

            subject.Dispose();

            //Next
            Console.WriteLine("Continue ...");
            Console.ReadKey();
        }

    }
}

