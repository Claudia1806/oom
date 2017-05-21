using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static int Main(string[] args)
        {
            var d = new Dirndl("Marchegg Dirndl", 40, 49.90m);
            var e = new Abendkleid("Kleines Schwarzes", 42, 34.40m);
            d.Print();
            e.Print();

            var dresses = new IDress[]
            {
                new Dirndl("Dirndl Pink",36, 59.90m),
                new Dirndl("Tiroler Dirndl",38, 99.90m),
                new Dirndl("Salzburger Dirndl",34, 79.90m),
                new Abendkleid("Abendkleid",32, 40.00m)
            };

            foreach (var dress in dresses)
            {
                Console.WriteLine();
                dress.Print();
            }
            Serialization.Run(dresses);
            return 0;
        }

    }
}
