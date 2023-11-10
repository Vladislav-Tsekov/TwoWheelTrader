using VehEvalu8.Models.Interfaces;

namespace VehEvalu8.Models.Enduro
{
    public class Yamaha : IEnduro
    {
        public Yamaha(int cc, int year, double priceForeign, string link, int distance)
        {
            Make = "Yamaha";
            Model = "WR-F";
            CC = cc;
            Year = year;
            PriceForeign = priceForeign;
            Link = link;
            DistanceToPickUp = distance;
            FuelCost = (double)(DistanceToPickUp * 2 / 100.0) * (IMotorcycle.dieselPriceBGN * 11);
            PriceBGN = PriceForeign * IMotorcycle.exchangeRateSEK;
            TotalCost = FuelCost + PriceBGN + IMotorcycle.commission;

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

            Profit = MarketPrice - TotalCost;
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

