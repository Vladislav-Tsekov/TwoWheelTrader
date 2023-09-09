using TwoWheelTrader.Models.Interfaces;

namespace TwoWheelTrader.Models.Enduro
{
    public class Yamaha : IEnduro
    {
        private double priceBGN;
        private double roi;

        public Yamaha(string model, int cc, int year, int priceForeign, int priceBGN)
        {
            Make = "Yamaha";
            Model = model;
            CC = cc;
            Year = year;
            PriceForeign = priceForeign;
            PriceBGN = priceBGN;

            switch (Year)
            {
                case 2007:
                    MarketPrice = 6200; break;
                case 2008:
                    MarketPrice = 6400; break;
                case 2009:
                    MarketPrice = 6700; break;
                case 2010:
                    MarketPrice = 6900; break;
                case 2011:
                    MarketPrice = 7300; break;
                case 2012:
                    MarketPrice = 7600; break;
                case 2013:
                    MarketPrice = 7900; break;
                case 2014:
                    MarketPrice = 8400; break;
                case 2015:
                    MarketPrice = 8700; break;
                case 2016:
                    MarketPrice = 9000; break;
                case 2017:
                    MarketPrice = 9300; break;
                case 2018:
                    MarketPrice = 9600; break;
                case 2019:
                    MarketPrice = 10000; break;
                case 2020:
                    MarketPrice = 11000; break;
                case 2021:
                    MarketPrice = 12000; break;
                case 2022:
                    MarketPrice = 13000; break;
                case 2023:
                    MarketPrice = 14000; break;
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

