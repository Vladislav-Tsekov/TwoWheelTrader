using Microsoft.EntityFrameworkCore;
using TwoWheelTrader.Core.Interfaces;
using VehEvalu8.Data;

namespace TwoWheelTrader.Core
{
    public class StartUp
    {
        static void Main()
        {
            var options = SetupDbContextOptions();

            using var context = new MotoDbContext(options);

            IController controller = new Controller();
            IEngine engine = new Engine(controller);
            engine.RunProgram();
        }

        static DbContextOptions<MotoDbContext> SetupDbContextOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MotoDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=YourDatabaseName;Trusted_Connection=True;");

            //TODO - CHECK CONNECTION STRING

            return optionsBuilder.Options;
        }
    }
}
