using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehEvalu8.Models.Motocross;
using VehEvalu8.Models.Interfaces;
using Xunit;
using xUnitTests.ModelsTests.Interfaces;

namespace xUnitTests.ModelsTests.MotocrossTests
{
    public class KawasakiTests : IModelsTests
    {
        [Fact]
        public void ModelsShouldInitializeCorrectly()
        {
            string model = "KXF";
            int cc = 250;
            int year = 2023;
            double priceForeign = 45000;
            string link = "www.kawasaki.com";
            int distance = 25;

            var testKawa = new Kawasaki(cc, year, priceForeign, link, distance);

            Assert.Equal("Kawasaki", testKawa.Make);
            Assert.Equal(model, testKawa.Model);
            Assert.Equal(cc, testKawa.CC);
            Assert.Equal(year, testKawa.Year);
            Assert.Equal(priceForeign, testKawa.PriceForeign);
            Assert.Equal(link, testKawa.Link);
            Assert.Equal(distance, testKawa.DistanceToPickUp);
        }

        [Fact]
        public void GetExpectedMarketPrice()
        {
            for (int year = 2007; year < 2024; year++)
            {
                var testKawa = new Kawasaki(250, year, 45000, "www.kawasaki.com", 15);
                Assert.Equal(MarketPricesByYear(testKawa.Year), testKawa.MarketPrice);
            }
        }

        [Fact]
        public void ModelsPropertiesMustHaveCorrectValues()
        {
            // Arrange
            string model = "KXF";
            int cc = 250;
            int year = 2023;
            double priceForeign = 45000;
            string link = "www.kawasaki.com";
            int distance = 25;

            // Act
            var testKawa = new Honda(cc, year, priceForeign, link, distance);

            // Assert
            double expectedMarketPrice = MarketPricesByYear(year);
            Assert.Equal(expectedMarketPrice, testKawa.MarketPrice);
            double expectedPriceBGN = priceForeign * IMotorcycle.exchangeRateSEK;
            double expectedFuelCost = (double)(distance * 2 / 100.0) * (IMotorcycle.dieselPriceBGN * 11);
            double expectedTotalCost = expectedPriceBGN + expectedFuelCost + IMotorcycle.commission;
            Assert.Equal(expectedPriceBGN, testKawa.PriceBGN);
            Assert.Equal(expectedFuelCost, testKawa.FuelCost);
            Assert.Equal(expectedTotalCost, testKawa.TotalCost);
            double expectedProfit = expectedMarketPrice - expectedTotalCost;
            Assert.Equal(expectedProfit, testKawa.Profit);
            double expectedROI = expectedProfit / expectedTotalCost * 100.0;
            Assert.Equal(expectedROI, testKawa.ROI);
        }

        private static double MarketPricesByYear(int year)
        {
            switch (year)
            {
                case 2007: return 4800;
                case 2008: return 5100;
                case 2009: return 5200;
                case 2010: return 5300;
                case 2011: return 5600;
                case 2012: return 5900;
                case 2013: return 6200;
                case 2014: return 6600;
                case 2015: return 6800;
                case 2016: return 7300;
                case 2017: return 7700;
                case 2018: return 8500;
                case 2019: return 9200;
                case 2020: return 9700;
                case 2021: return 10500;
                case 2022: return 10750;
                case 2023: return 12000;
                default: return 0;
            }
        }
    }
}

