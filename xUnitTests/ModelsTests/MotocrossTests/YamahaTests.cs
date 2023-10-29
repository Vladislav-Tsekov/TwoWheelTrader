using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoWheelTrader.Models.Motocross;
using TwoWheelTrader.Models.Interfaces;
using Xunit;
using xUnitTests.ModelsTests.Interfaces;

namespace xUnitTests.ModelsTests.MotocrossTests
{
    public class YamahaTests : IModelsTests
    {
        [Fact]
        public void ModelsShouldInitializeCorrectly()
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
        public void GetExpectedMarketPrice()
        {
            for (int year = 2007; year < 2024; year++)
            {
                var testYamaha = new Yamaha("YZF", 250, year, 45000, "www.yamaha.com", 15);
                Assert.Equal(MarketPricesByYear(testYamaha.Year), testYamaha.MarketPrice);
            }
        }

        [Fact]
        public void ModelsPropertiesMustHaveCorrectValues()
        {
            // Arrange
            string model = "YZF";
            int cc = 250;
            int year = 2023;
            double priceForeign = 45000;
            string link = "www.yamaha.com";
            int distance = 25;

            // Act
            var testYamaha = new Yamaha(model, cc, year, priceForeign, link, distance);

            // Assert
            double expectedMarketPrice = MarketPricesByYear(year);
            Assert.Equal(expectedMarketPrice, testYamaha.MarketPrice);
            double expectedPriceBGN = priceForeign * IMotorcycle.exchangeRateSEK;
            double expectedFuelCost = (double)(distance * 2 / 100.0) * (IMotorcycle.dieselPriceBGN * 11);
            double expectedTotalCost = expectedPriceBGN + expectedFuelCost + IMotorcycle.commission;
            Assert.Equal(expectedPriceBGN, testYamaha.PriceBGN);
            Assert.Equal(expectedFuelCost, testYamaha.FuelCost);
            Assert.Equal(expectedTotalCost, testYamaha.TotalCost);
            double expectedProfit = expectedMarketPrice - expectedTotalCost;
            Assert.Equal(expectedProfit, testYamaha.Profit);
            double expectedROI = expectedProfit / expectedTotalCost * 100.0;
            Assert.Equal(expectedROI, testYamaha.ROI);
        }

        private static double MarketPricesByYear(int year)
        {
            switch (year)
            {
                case 2007: return 5000;
                case 2008: return 5100;
                case 2009: return 5200;
                case 2010: return 5300;
                case 2011: return 5600;
                case 2012: return 5900;
                case 2013: return 6200;
                case 2014: return 6600;
                case 2015: return 6800;
                case 2016: return 7300;
                case 2017: return 7800;
                case 2018: return 8400;
                case 2019: return 9100;
                case 2020: return 9800;
                case 2021: return 10500;
                case 2022: return 11000;
                case 2023: return 12000;
                default: return 0;
            }
        }
    }
}

