using VehEvalu8.Models.Interfaces;

namespace VehEvalu8.Models.Motocross
{
    public class GASGAS : IMotocross
    {
        public GASGAS(int cc, int year, double priceForeign, string link, int distance)
        {
            Make = "GASGAS";
            Model = "MC-F";
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
                case 2021:
                    MarketPrice = 10500; break;
                case 2022:
                    MarketPrice = 11250; break;
                case 2023:
                    MarketPrice = 12300; break;
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

