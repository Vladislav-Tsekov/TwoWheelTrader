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
    }
}

