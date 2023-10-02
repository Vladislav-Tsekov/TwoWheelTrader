using TwoWheelTrader.Models.Interfaces;

namespace TwoWheelTrader.Models.Motocross
{
    public class Husqvarna : IMotocross
    {
        public Husqvarna(string model, int cc, int year, int priceForeign, string link, int distance)
        {
            Make = "Husqvarna";
            Model = model;
            CC = cc;
            Year = year;
            PriceForeign = priceForeign;
            Link = link;
            DistanceToPickUp = distance;
            FuelCost = (double)(DistanceToPickUp * 2 / 100.0) * (IMotorcycle.dieselPriceBGN * 11);
            PriceBGN = PriceForeign * IMotorcycle.exchangeRateSEK;
            TotalCost = FuelCost + PriceBGN;

            switch (Year)
            {
                case 2014:
                    MarketPrice = 7200; break;
                case 2015:
                    MarketPrice = 7500; break;
                case 2016:
                    MarketPrice = 7900; break;
                case 2017:
                    MarketPrice = 8100; break;
                case 2018:
                    MarketPrice = 8500; break;
                case 2019:
                    MarketPrice = 9200; break;
                case 2020:
                    MarketPrice = 9800; break;
                case 2021:
                    MarketPrice = 10500; break;
                case 2022:
                    MarketPrice = 11000; break;
                case 2023:
                    MarketPrice = 11500; break;
            }

            Profit = MarketPrice - PriceBGN;
            ROI = (this.Profit / this.TotalCost) * 100.0;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int CC { get; set; }

        public int Year { get; set; }

        public double PriceForeign { get; set; }

        public double PriceBGN { get; set; }

        public double MarketPrice { get; set; }

        public int DistanceToPickUp { get; set; }

        public double FuelCost { get; set; }

        public double TotalCost { get; set; }

        public double Profit { get; set; }

        public double ROI { get; set; }

        public string Link { get; set; }
    }
}

