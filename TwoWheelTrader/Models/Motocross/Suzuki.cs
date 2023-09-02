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
                    MarketPrice = ; break;
                case 2008:
                    MarketPrice = ; break;
                case 2009:
                    MarketPrice = ; break;
                case 2010:
                    MarketPrice = ; break;
                case 2011:
                    MarketPrice = ; break;
                case 2012:
                    MarketPrice = ; break;
                case 2013:
                    MarketPrice = ; break;
                case 2014:
                    MarketPrice = ; break;
                case 2015:
                    MarketPrice = ; break;
                case 2016:
                    MarketPrice = ; break;
                case 2017:
                    MarketPrice = ; break;
                case 2018:
                    MarketPrice = ; break;
                case 2019:
                    MarketPrice = ; break;
                case 2020:
                    MarketPrice = ; break;
                case 2021:
                    MarketPrice = ; break;
                case 2022:
                    MarketPrice = ; break;
                case 2023:
                    MarketPrice = ; break;
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
