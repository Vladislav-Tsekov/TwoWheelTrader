using TwoWheelTrader.Models.Interfaces;

namespace TwoWheelTrader.Models.Enduro
{
    public class Husqvarna : IEnduro
    {
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
                case 2007:
                    MarketPrice = 5800; break;
                case 2008:
                    MarketPrice = 6200; break;
                case 2009:
                    MarketPrice = 6500; break;
                case 2010:
                    MarketPrice = 6800; break;
                case 2011:
                    MarketPrice = 7200; break;
                case 2012:
                    MarketPrice = 7500; break;
                case 2013:
                    MarketPrice = 8000; break;
                case 2014:
                    MarketPrice = 8400; break;
                case 2015:
                    MarketPrice = 9000; break;
                case 2016:
                    MarketPrice = 9800; break;
                case 2017:
                    MarketPrice = 10500; break;
                case 2018:
                    MarketPrice = 11000; break;
                case 2019:
                    MarketPrice = 12000; break;
                case 2020:
                    MarketPrice = 13000; break;
                case 2021:
                    MarketPrice = 14500; break;
                case 2022:
                    MarketPrice = 15500; break;
                case 2023:
                    MarketPrice = 17000; break;
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

