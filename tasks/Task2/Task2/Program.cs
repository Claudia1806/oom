using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
        class Dress
        {
            private string label; /*private Fields*/
            private int size;
            private double price;
            private double VAT = 1.2;

            public double myPrice /*public Property*/
            {
                get;
                set;
            }

            public int mySize /*public Property*/
            {
                get;
                set;
            }

            public Dress(int newSize, double newPrice)/*Constructor*/
            {
                {
                    if (newSize < 30) throw new ArgumentException("Groesse nicht vorhanden");
                    if (newPrice < 0) throw new ArgumentException("Preis darf nicht negativ sein");

                    {
                        mySize = newSize;
                        myPrice = newPrice;
                    }
                }
            }

            public void CalculateVAT(double newPrice) /*public method*/
            {
            myPrice = newPrice * VAT;
            }
        }

        class Program
        {
            static int Main(string[] args)
            {
            var a = new Dress(36, 95);
            Console.WriteLine("Groesse: " + a.mySize + " Preis: " + a.myPrice);
            a.CalculateVAT(a.myPrice);
            Console.WriteLine("Preis inkl USt: " + a.myPrice);
            return 0;
            }
        }
}
