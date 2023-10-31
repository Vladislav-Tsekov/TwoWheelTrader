using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TwoWheelTrader.Core.Interfaces;
using VehEvalu8.Data;

namespace TwoWheelTrader.Core
{
    public class StartUp
    {
        static void Main()
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=motoTEST;Trusted_Connection=True;";

            var services = new ServiceCollection()
                .AddDbContext<MotoDbContext>(options =>
                    options.UseSqlServer(connectionString)
                )
                .AddScoped<IController, Controller>()
                .AddScoped<IEngine, Engine>()
                .BuildServiceProvider();

            var engine = services.GetService<IEngine>();
            engine.RunProgram();
        }
    }
}
