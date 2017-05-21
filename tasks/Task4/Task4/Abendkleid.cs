using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Abendkleid : IDress
    {
        private readonly decimal _vat = 1.2m;
        private decimal m_priceGross;
        private string _name;

        public decimal PriceGross => m_priceGross;

        public double Size { get; }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name darf nicht leer sein!", nameof(Name));
                }
                _name = value;
            }
        }

        public Abendkleid(string name, double size, decimal priceGross)
        {
            if (size <= 0) throw new ArgumentException("Die Groesse muss groesser Null sein!", nameof(size));
            if (priceGross < 0) throw new ArgumentException("Der Preis darf nicht negativ sein!", nameof(priceGross));

            Name = name;
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
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"BruttoPreis: {PriceGross,6:0.00} EUR");
            Console.WriteLine($"NettoPreis: {priceNet,6:0.00} EUR");
            Console.WriteLine($"Groesse: {Size,6}");
            Console.WriteLine($"Typ: {nameof(Abendkleid),6}");
        }
        #endregion
    }
}
