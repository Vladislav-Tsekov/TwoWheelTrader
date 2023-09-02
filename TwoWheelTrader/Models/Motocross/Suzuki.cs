using TwoWheelTrader.Models.Interfaces;

namespace TwoWheelTrader.Models.Motocross
{
    public class Suzuki : IMotocross
    {
        public Suzuki(string model, int cc, int year, int priceForeign, int priceBGN)
        {
            Make = "Suzuki";
            Model = model;
            CC = cc;
            Year = year;
            PriceForeign = priceForeign;
            PriceBGN = priceBGN;

            switch (Year)
            {
                case 2007:
                    MarketPrice = 4400; break;
                case 2008:
                    MarketPrice = 4600; break;
                case 2009:
                    MarketPrice = 4800; break;
                case 2010:
                    MarketPrice = 5200; break;
                case 2011:
                    MarketPrice = 5600; break;
                case 2012:
                    MarketPrice = 6000; break;
                case 2013:
                    MarketPrice = 6300; break;
                case 2014:
                    MarketPrice = 6500; break;
                case 2015:
                    MarketPrice = 6700; break;
                case 2016:
                    MarketPrice = 7300; break;
                case 2017:
                    MarketPrice = 7700; break;
                case 2018:
                    MarketPrice = 8300; break;
                case 2019:
                    MarketPrice = 8900; break;
                case 2020:
                    MarketPrice = 9400; break;
                case 2021:
                    MarketPrice = 9800; break;
                case 2022:
                    MarketPrice = 10000; break;
                case 2023:
                    MarketPrice = 11000; break;
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

        public string Link { get; set; }
    }
}
