using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public interface IDress
    {
        void Print();
    }

    class Dirndl : IDress
    {
        private readonly decimal _vat = 1.2m;
        private decimal m_priceGross;
        private string m_type = "Dirndl";

        public decimal PriceGross => m_priceGross;

        public double Size { get; }

        public string Type => m_type;

        public Dirndl(string type, double size, decimal priceGross)
        {
            if (size <= 0) throw new ArgumentException("Die Groesse muss groesser Null sein!", nameof(size));
            if (priceGross < 0) throw new ArgumentException("Der Preis darf nicht negativ sein!", nameof(priceGross));

            Size = size;
            m_priceGross = priceGross;
        }

        public decimal CalculateNetPrice()
        {
            return m_priceGross / _vat;
        }

        #region IDress implementation
        public void Print()
        {
            var priceNet = CalculateNetPrice();
            Console.WriteLine($"BruttoPreis: {PriceGross,6:0.00} EUR");
            Console.WriteLine($"NettoPreis: {priceNet,6:0.00} EUR");
            Console.WriteLine($"Groesse: {Size,6}");
            Console.WriteLine($"Typ: {Type,6}");
        }
        #endregion

    }

    class Abendkleid : IDress
    {
        private readonly decimal _vat = 1.2m;
        private decimal m_priceGross;
        private string m_type = "Abendkleid";

        public decimal PriceGross => m_priceGross;

        public double Size { get; }

        public string Type => m_type;

        public Abendkleid (string type, double size, decimal priceGross)
        {
            if (size <= 0) throw new ArgumentException("Die Groesse muss groesser Null sein!", nameof(size));
            if (priceGross < 0) throw new ArgumentException("Der Preis darf nicht negativ sein!", nameof(priceGross));

            Size = size;
            m_priceGross = priceGross;
        }

        public decimal CalculateNetPrice()
        {
            return m_priceGross / _vat;
        }

        #region IDress implementation
        public void Print()
        {
            var priceNet = CalculateNetPrice();
            Console.WriteLine($"BruttoPreis: {PriceGross,6:0.00} EUR");
            Console.WriteLine($"NettoPreis: {priceNet,6:0.00} EUR");
            Console.WriteLine($"Groesse: {Size,6}");
            Console.WriteLine($"Typ: {Type,6}");
        }
        #endregion
    }
    class Program
    {
        static int Main(string[] args)
        {
            var d = new Dirndl("Dirndl", 40, 49.90m);
            var e = new Abendkleid("Abendkleid", 42, 34.40m);
            d.Print();
            e.Print();

            var dresses = new IDress[]
            {
                new Dirndl("Dirndl",36, 59.90m),
                new Dirndl("Dirndl",38, 99.90m),
                new Dirndl("Dirndl",34, 79.90m),
                new Abendkleid("Abendkleid",32, 40.00m)
            };

            foreach (var dress in dresses)
            {
                Console.WriteLine();
                dress.Print();
            }

            return 0;
        }

    }
}
