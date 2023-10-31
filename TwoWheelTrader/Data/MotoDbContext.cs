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

        public MotoDbContext(DbContextOptions<MotoDbContext> options)
            : base(options)
        {
        }
    }
}
