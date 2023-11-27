using VehEvalu8.Models.Interfaces;
using VehEvalu8.Models.Motocross;
using Xunit;
using xUnitTests.ModelsTests.Interfaces;

namespace xUnitTests.ModelsTests.MotocrossTests
{
    public class KTMTests : IModelsTests
    {
        [Fact]
        public void ModelsShouldInitializeCorrectly()
        {
            string model = "SX-F";
            int cc = 250;
            int year = 2023;
            double priceForeign = 45000;
            string link = "www.ktm.com";
            int distance = 25;

            var testKTM = new KTM(cc, year, priceForeign, link, distance);

            Assert.Equal("KTM", testKTM.Make);
            Assert.Equal(model, testKTM.Model);
            Assert.Equal(cc, testKTM.CC);
            Assert.Equal(year, testKTM.Year);
            Assert.Equal(priceForeign, testKTM.PriceForeign);
            Assert.Equal(link, testKTM.Link);
            Assert.Equal(distance, testKTM.DistanceToPickUp);
        }

        [Fact]
        public void GetExpectedMarketPrice()
        {
            for (int year = 2007; year < 2024; year++)
            {
                var testKTM = new KTM(250, year, 45000, "www.ktm.com", 15);
                Assert.Equal(MarketPricesByYear(testKTM.Year), testKTM.MarketPrice);
            }
        }

        [Fact]
        public void ModelsPropertiesMustHaveCorrectValues()
        {
            // Arrange
            int cc = 250;
            int year = 2023;
            double priceForeign = 45000;
            string link = "www.ktm.com";
            int distance = 25;

            // Act
            var testKTM = new KTM(cc, year, priceForeign, link, distance);

            // Assert
            double expectedMarketPrice = MarketPricesByYear(year);
            Assert.Equal(expectedMarketPrice, testKTM.MarketPrice);
            double expectedPriceBGN = priceForeign * IMotorcycle.exchangeRateSEK;
            double expectedFuelCost = (double)(distance * 2 / 100.0) * (IMotorcycle.dieselPriceBGN * 11);
            double expectedTotalCost = expectedPriceBGN + expectedFuelCost + IMotorcycle.commission;
            Assert.Equal(expectedPriceBGN, testKTM.PriceBGN);
            Assert.Equal(expectedFuelCost, testKTM.FuelCost);
            Assert.Equal(expectedTotalCost, testKTM.TotalCost);
            double expectedProfit = expectedMarketPrice - expectedTotalCost;
            Assert.Equal(expectedProfit, testKTM.Profit);
            double expectedROI = expectedProfit / expectedTotalCost * 100.0;
            Assert.Equal(expectedROI, testKTM.ROI);
        }

        private static double MarketPricesByYear(int year)
        {
            switch (year)
            {
                case 2007: return 4800;
                case 2008: return 5300;
                case 2009: return 5400;
                case 2010: return 5700;
                case 2011: return 6100;
                case 2012: return 6400;
                case 2013: return 6700;
                case 2014: return 7200;
                case 2015: return 7500;
                case 2016: return 7800;
                case 2017: return 8300;
                case 2018: return 9200;
                case 2019: return 9600;
                case 2020: return 10300;
                case 2021: return 11000;
                case 2022: return 11500;
                case 2023: return 12500;
                default: return 0;
            }
        }
    }
}

