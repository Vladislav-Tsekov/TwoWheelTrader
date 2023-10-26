using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoWheelTrader.Models.Motocross;
using TwoWheelTrader.Models.Interfaces;
using Xunit;

namespace xUnitTests.ModelsTests
{
    public class MotocrossTests
    {
        [Fact]
        public void MotocrossModelShouldInitializeCorrectly()
        {
            string model = "YZF";
            int cc = 250;
            int year = 2023;
            double priceForeign = 45000;
            string link = "www.yamaha.com";
            int distance = 25;

            var testYamaha = new Yamaha(model, cc, year, priceForeign, link, distance);

            Assert.Equal("Yamaha", testYamaha.Make);
            Assert.Equal(model, testYamaha.Model);
            Assert.Equal(cc, testYamaha.CC);
            Assert.Equal(year, testYamaha.Year);
            Assert.Equal(priceForeign, testYamaha.PriceForeign);
            Assert.Equal(link, testYamaha.Link);
            Assert.Equal(distance, testYamaha.DistanceToPickUp);
        }

        [Fact]
        public void GetExpectedMotocrossMarketPrice()
        {
            var testYamaha0 = new Yamaha("YZF", 250, 2023, 45000, "www.yamaha.com", 25);
            var testYamaha1 = new Yamaha("YZF", 250, 2016, 45000, "www.yamaha.com", 25);
            var testYamaha2 = new Yamaha("YZF", 250, 2011, 45000, "www.yamaha.com", 25);

            Assert.Equal(12000, testYamaha0.MarketPrice);
            Assert.Equal(7300, testYamaha1.MarketPrice);
            Assert.Equal(5600, testYamaha2.MarketPrice);
        }
    }
}

