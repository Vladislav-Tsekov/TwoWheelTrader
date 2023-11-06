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
            string connectionString = @"Server=(localDB)\MSSQLLocalDB;Database=VehEvalu8;Integrated Security=True;";

            try
            {
                var serviceProvider = new ServiceCollection()
                .AddDbContext<VehEvalu8Context>(options => options.UseSqlServer(connectionString))
                .AddScoped<IController, Controller>()
                .AddScoped<IEngine, Engine>()
                .BuildServiceProvider();

                IEngine? engine = serviceProvider.GetService<IEngine>();
                engine?.RunProgram();
            }
            catch (Exception exception)
            {
                throw new Exception (exception.Message);
            }
        }
    }
}
