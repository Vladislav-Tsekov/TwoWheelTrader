using TwoWheelTrader.Models.Interfaces;

namespace TwoWheelTrader.Models.Motocross
{
    public class GASGAS : IMotocross
    {
        private double priceBGN;
        private double roi;

        public GASGAS(string model, int cc, int year, int priceForeign, int priceBGN)
        {
            Make = "GASGAS";
            Model = model;
            CC = cc;
            Year = year;
            PriceForeign = priceForeign;
            PriceBGN = priceBGN;

            switch (Year)
            {
                case 2021:
                    MarketPrice = 10500; break;
                case 2022:
                    MarketPrice = 11250; break;
                case 2023:
                    MarketPrice = 12300; break;
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

