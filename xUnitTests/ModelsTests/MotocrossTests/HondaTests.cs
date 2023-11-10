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
    public class HondaTests : IModelsTests
    {
        [Fact]
        public void ModelsShouldInitializeCorrectly()
        {
            string model = "CRF";
            int cc = 250;
            int year = 2023;
            double priceForeign = 45000;
            string link = "www.honda.com";
            int distance = 25;

            var testHonda = new Honda(cc, year, priceForeign, link, distance);

            Assert.Equal("Honda", testHonda.Make);
            Assert.Equal(model, testHonda.Model);
            Assert.Equal(cc, testHonda.CC);
            Assert.Equal(year, testHonda.Year);
            Assert.Equal(priceForeign, testHonda.PriceForeign);
            Assert.Equal(link, testHonda.Link);
            Assert.Equal(distance, testHonda.DistanceToPickUp);
        }

        [Fact]
        public void GetExpectedMarketPrice()
        {
            for (int year = 2007; year < 2024; year++)
            {
                var testHonda = new Honda(250, year, 45000, "www.honda.com", 15);
                Assert.Equal(MarketPricesByYear(testHonda.Year), testHonda.MarketPrice);
            }
        }

        [Fact]
        public void ModelsPropertiesMustHaveCorrectValues()
        {
            // Arrange
            string model = "CRF";
            int cc = 250;
            int year = 2023;
            double priceForeign = 45000;
            string link = "www.honda.com";
            int distance = 25;

            // Act
            var testHonda = new Honda(cc, year, priceForeign, link, distance);

            // Assert
            double expectedMarketPrice = MarketPricesByYear(year);
            Assert.Equal(expectedMarketPrice, testHonda.MarketPrice);
            double expectedPriceBGN = priceForeign * IMotorcycle.exchangeRateSEK;
            double expectedFuelCost = (double)(distance * 2 / 100.0) * (IMotorcycle.dieselPriceBGN * 11);
            double expectedTotalCost = expectedPriceBGN + expectedFuelCost + IMotorcycle.commission;
            Assert.Equal(expectedPriceBGN, testHonda.PriceBGN);
            Assert.Equal(expectedFuelCost, testHonda.FuelCost);
            Assert.Equal(expectedTotalCost, testHonda.TotalCost);
            double expectedProfit = expectedMarketPrice - expectedTotalCost;
            Assert.Equal(expectedProfit, testHonda.Profit);
            double expectedROI = expectedProfit / expectedTotalCost * 100.0;
            Assert.Equal(expectedROI, testHonda.ROI);
        }

        private static double MarketPricesByYear(int year)
        {
            switch (year)
            {
                case 2007: return 4500;
                case 2008: return 4700;
                case 2009: return 5100;
                case 2010: return 5400;
                case 2011: return 5900;
                case 2012: return 6300;
                case 2013: return 6500;
                case 2014: return 6600;
                case 2015: return 6800;
                case 2016: return 7500;
                case 2017: return 8200;
                case 2018: return 8650;
                case 2019: return 9500;
                case 2020: return 10000;
                case 2021: return 10500;
                case 2022: return 11000;
                case 2023: return 12000;
                default: return 0;
            }
        }
    }
}

