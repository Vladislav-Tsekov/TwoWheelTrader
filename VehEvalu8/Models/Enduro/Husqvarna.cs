using VehEvalu8.Models.Interfaces;

namespace VehEvalu8.Models.Enduro
{
    public class Husqvarna : IEnduro
    {
        public Husqvarna(int cc, int year, double priceForeign, string link, int distance)
        {
            Make = "Husqvarna";
            Model = "FE";
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

