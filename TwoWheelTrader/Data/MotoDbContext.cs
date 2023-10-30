using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehEvalu8.Data
{
    public class MotoDbContext : DbContext
    {
        public DbSet<Motorcycle> Motorcycles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(/*TODO - ADD CONNECTION STRING*/);
        }

        public MotoDbContext(DbContextOptions<MotoDbContext> options)
            : base(options)
        {
        }
    }
}
