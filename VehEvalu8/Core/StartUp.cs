using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VehEvalu8.Core.Interfaces;
using VehEvalu8.Data;
using static System.Formats.Asn1.AsnWriter;

namespace VehEvalu8.Core
{
    public class StartUp
    {
        static void Main()
        {
            string connectionString = @"Server=(localDB)\MSSQLLocalDB;Database=VehEvalu8;Integrated Security=True;";

            try
            {
                var serviceProvider = new ServiceCollection()
                .AddDbContext<DbContext>(options => options.UseSqlServer(connectionString))
                .AddScoped<IController, Controller>()
                .AddScoped<IEngine, Engine>()
                .BuildServiceProvider();

                MotoContext context = serviceProvider.GetRequiredService<MotoContext>();
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
