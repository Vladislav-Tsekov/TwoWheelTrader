using VehEvalu8.Models.Motocross;
using VehEvalu8.Models.Interfaces;
using Xunit;
using xUnitTests.ModelsTests.Interfaces;

namespace xUnitTests.ModelsTests.MotocrossTests
{
    public class GASGASTests : IModelsTests
    {
        [Fact]
        public void ModelsShouldInitializeCorrectly()
        {
            string model = "MC-F";
            int cc = 250;
            int year = 2023;
            double priceForeign = 45000;
            string link = "www.gasgas.com";
            int distance = 25;

            var testGasgas = new GASGAS(cc, year, priceForeign, link, distance);

            Assert.Equal("GASGAS", testGasgas.Make);
            Assert.Equal(model, testGasgas.Model);
            Assert.Equal(cc, testGasgas.CC);
            Assert.Equal(year, testGasgas.Year);
            Assert.Equal(priceForeign, testGasgas.PriceForeign);
            Assert.Equal(link, testGasgas.Link);
            Assert.Equal(distance, testGasgas.DistanceToPickUp);
        }

        [Fact]
        public void GetExpectedMarketPrice()
        {
            for (int year = 2007; year < 2024; year++)
            {
                var testGasgas = new GASGAS(250, year, 45000, "www.gasgas.com", 15);
                Assert.Equal(MarketPricesByYear(testGasgas.Year), testGasgas.MarketPrice);
            }
        }

        [Fact]
        public void ModelsPropertiesMustHaveCorrectValues()
        {
            // Arrange
            string model = "MC-F";
            int cc = 250;
            int year = 2023;
            double priceForeign = 45000;
            string link = "www.gasgas.com";
            int distance = 25;

            // Act
            var testGasgas = new GASGAS(cc, year, priceForeign, link, distance);

            // Assert
            double expectedMarketPrice = MarketPricesByYear(year);
            Assert.Equal(expectedMarketPrice, testGasgas.MarketPrice);
            double expectedPriceBGN = priceForeign * IMotorcycle.exchangeRateSEK;
            double expectedFuelCost = (double)(distance * 2 / 100.0) * (IMotorcycle.dieselPriceBGN * 11);
            double expectedTotalCost = expectedPriceBGN + expectedFuelCost + IMotorcycle.commission;
            Assert.Equal(expectedPriceBGN, testGasgas.PriceBGN);
            Assert.Equal(expectedFuelCost, testGasgas.FuelCost);
            Assert.Equal(expectedTotalCost, testGasgas.TotalCost);
            double expectedProfit = expectedMarketPrice - expectedTotalCost;
            Assert.Equal(expectedProfit, testGasgas.Profit);
            double expectedROI = expectedProfit / expectedTotalCost * 100.0;
            Assert.Equal(expectedROI, testGasgas.ROI);
        }

        private static double MarketPricesByYear(int year)
        {
            switch (year)
            {
                case 2021: return 10500;
                case 2022: return 11250;
                case 2023: return 12300;
                default: return 0;
            }
        }
    }
}

