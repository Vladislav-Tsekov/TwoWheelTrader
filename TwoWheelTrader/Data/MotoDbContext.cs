using Microsoft.EntityFrameworkCore;

namespace VehEvalu8.Data
{
    public class MotoDbContext : DbContext
    {
        public DbSet<Motorcycle> Motorcycles { get; set; }

        public MotoDbContext(DbContextOptions<MotoDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=motoTEST;Integrated Security=True;");
        }
    }
}
