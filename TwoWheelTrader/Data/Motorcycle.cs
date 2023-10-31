using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehEvalu8.Data
{
    public class Motorcycle
    {
        public Motorcycle(string make, string model, int year, double priceForeign, string link)
        {
            Make = make;
            Model = model;
            Year = year;
            PriceForeign = priceForeign;
            Link = link;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double PriceForeign { get; set; }

        [Key]
        public string Link { get; set; }
    }
}
