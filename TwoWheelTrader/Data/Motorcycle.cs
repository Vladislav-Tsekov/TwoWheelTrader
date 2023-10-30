using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehEvalu8.Data
{
    public class Motorcycle
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int CC { get; set; }
        public int Year { get; set; }
        public double PriceForeign { get; set; }
        public double PriceBGN { get; set; }
        public string Link { get; set; }
        public int DistanceToPickUp { get; set; }
    }
}
