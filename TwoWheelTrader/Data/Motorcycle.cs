using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Key]
        public string Link { get; set; }

        [Required]
        [MaxLength(25)] 
        public string Make { get; set; }

        [Required]
        [MaxLength(15)]
        public string Model { get; set; }

        [Required]
        [Range(1990, 2050)] 
        public int Year { get; set; }

        [Required]
        [Column(TypeName = "INT")] 
        public double PriceForeign { get; set; }
    }
}
