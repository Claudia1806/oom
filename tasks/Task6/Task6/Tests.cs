using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task6
{
    [TestFixture]
    class Tests
    {
        [Test]
        public void CanCreateDress()
        {
            var x = new Abendkleid("Abendkleid", 37, 78.95m);

            Assert.IsTrue(x.Name == "Abendkleid");
            Assert.IsTrue(x.Size == 37);
            Assert.IsTrue(x.PriceGross == 78.95m);
        }

        [Test]
        public void CannotCreateDressWhereNameIsEmpty()
        {
            Assert.Catch(() =>
            {
                var x = new Dirndl("", 37, 50.90m);
            });
        }

        [Test]
        public void CannotCreateDressWhereNameIsNull()
        {
            Assert.Catch(() =>
            {
                var x = new Dirndl(null, 37, 50.90m);
            });
        }

        [Test]
        public void CannotCreateDressWhereSizeLessThan32()
        {
            Assert.Catch(() =>
            {
                var x = new Dirndl("Tiroler Dirndl", 31, 99.90m);
            });
        }

        [Test]
        public void CannotCreateDressWherePriceIsNegative()
        {
            Assert.Catch(() =>
            {
                var x = new Dirndl("Tiroler Dirndl", 34, -1m);
            });
        }

        [Test]
        public void CannotCreateDressWhereSizeBiggerThan48()
        {
            Assert.Catch(() =>
            {
                var x = new Dirndl("Tiroler Dirndl", 50, 99.90m);
            });
        }

        [Test]
        public void CanCalculateNetPrice()
        {
            var x = new Abendkleid("rotes Abendkleid", 36, 114.90m);
            x.CalculateNetPrice();

            Assert.IsTrue(x.PriceGross / 1.2m == 95.75m);
        }

        [Test]
        public void CannotCalculateNetPriceWithNegativePrice()
        {
            Assert.Catch(() =>
            {
                var x = new Abendkleid("blaues Abendkleid", 36, -114.90m);
                x.CalculateNetPrice();
            });
        }
    }
}
