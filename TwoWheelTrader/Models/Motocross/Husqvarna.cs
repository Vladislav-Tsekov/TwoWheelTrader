using TwoWheelTrader.Models.Interfaces;

namespace TwoWheelTrader.Models.Motocross
{
    public class Husqvarna : IMotocross
    {
        private double priceBGN;
        private double roi;

        public Husqvarna(string model, int cc, int year, int priceForeign, int priceBGN)
        {
            Make = "Husqvarna";
            Model = model;
            CC = cc;
            Year = year;
            PriceForeign = priceForeign;

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
        }
        public string Make { get; set; }

        public string Model { get; set; }

        public int CC { get; set; }

        public int Year { get; set; }

        public int PriceForeign { get; set; }

        public double PriceBGN
        {
            get => priceBGN; private set
            {
                priceBGN = PriceForeign * 0.1642;
            }
        }

        public int MarketPrice { get; set; }

        public int DistanceToPickUp { get; set; }

        public int FuelCost { get; set; }

        public int TotalCost { get; set; }

        public int Profit { get; set; }

        public double ROI
        {
            get => roi; set
            {
                roi = (this.Profit / this.TotalCost) * 100;
            }
        }

        public string Link { get; set; }
    }
}

