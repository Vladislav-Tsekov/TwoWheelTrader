using TwoWheelTrader.Models.Interfaces;

namespace TwoWheelTrader.Models.Enduro
{
    public class Husqvarna : IEnduro
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
            PriceBGN = priceBGN;

            switch (Year)
            {
                case 2015:
                    MarketPrice = 9500; break;
                case 2016:
                    MarketPrice = 10000; break;
                case 2017:
                    MarketPrice = 10500; break;
                case 2018:
                    MarketPrice = 11300; break;
                case 2019:
                    MarketPrice = 12000; break;
                case 2020:
                    MarketPrice = 13500; break;
                case 2021:
                    MarketPrice = 14500; break;
                case 2022:
                    MarketPrice = 15500; break;
                case 2023:
                    MarketPrice = 16500; break;
            }
        }
        public string Make { get; set; }

        public string Model { get; set; }

        public int CC { get; set; }

        public int Year { get; set; }

        public int PriceForeign { get; set; }

        public int PriceBGN { get; set; }

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

