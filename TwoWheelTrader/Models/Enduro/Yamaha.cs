using TwoWheelTrader.Models.Interfaces;

namespace TwoWheelTrader.Models.Enduro
{
    public class Yamaha : IEnduro
    {
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
                    MarketPrice = 5000; break;
                case 2008:
                    MarketPrice = 5100; break;
                case 2009:
                    MarketPrice = 5200; break;
                case 2010:
                    MarketPrice = 5300; break;
                case 2011:
                    MarketPrice = 5600; break;
                case 2012:
                    MarketPrice = 5900; break;
                case 2013:
                    MarketPrice = 6200; break;
                case 2014:
                    MarketPrice = 6600; break;
                case 2015:
                    MarketPrice = 6800; break;
                case 2016:
                    MarketPrice = 7300; break;
                case 2017:
                    MarketPrice = 7900; break;
                case 2018:
                    MarketPrice = 8500; break;
                case 2019:
                    MarketPrice = 9200; break;
                case 2020:
                    MarketPrice = 10000; break;
                case 2021:
                    MarketPrice = 10500; break;
                case 2022:
                    MarketPrice = 11000; break;
                case 2023:
                    MarketPrice = 12000; break;
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
}
