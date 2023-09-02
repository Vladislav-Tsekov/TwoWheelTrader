using TwoWheelTrader.Models.Interfaces;

namespace TwoWheelTrader.Models.Motocross
{
    public class GASGAS : IMotocross
    {
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
                    MarketPrice = 10000; break;
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

