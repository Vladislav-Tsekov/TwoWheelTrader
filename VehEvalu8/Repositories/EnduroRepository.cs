using Microsoft.EntityFrameworkCore;
using System.Text;
using VehEvalu8.Data;
using VehEvalu8.Data.DBModels;
using VehEvalu8.Models.Interfaces;
using VehEvalu8.Repositories.Interfaces;

namespace VehEvalu8.Repositories
{
    public class EnduroRepository : IRepository<IMotorcycle>
    {
        public void AddMotorcycle(IMotorcycle motorcycle, MotoContext context)
        {
            try
            {
                var moto = new Enduro
                {
                    FuelCost = (decimal)motorcycle.FuelCost,
                    PriceBgn = (decimal)motorcycle.PriceBGN,
                    Distance = motorcycle.DistanceToPickUp,
                    PriceForeign = (decimal)motorcycle.PriceForeign,
                    Profit = (decimal)motorcycle.Profit,
                    Roi = (decimal)motorcycle.ROI,
                    TotalCost = (decimal)motorcycle.TotalCost,
                    Link = motorcycle.Link
                };

                Make? make = context.Makes.FirstOrDefault(m => m.MakeName == motorcycle.Make);
                Model? model = context.Models.FirstOrDefault(m => m.ModelName == motorcycle.Model);
                Year? year = context.Years.FirstOrDefault(y => y.Year1 == motorcycle.Year);
                Cc? cc = context.Ccs.FirstOrDefault(c => c.EngineSize == motorcycle.CC);

                moto.Make = make;
                moto.Model = model;
                moto.Year = year;
                moto.Cc = cc;

                context.Enduroes.Add(moto);
                context.SaveChanges();

                Console.WriteLine($"{moto.GetType().Name} motorcycle added successfully to database.");

                context.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Enduro> MotorcycleInfoAsync(string link, MotoContext context)
        {
            Enduro? motoInfo = await context.Enduroes.FirstOrDefault(m => m.Link == link);
            return motoInfo!;
        }

        public string RemoveMotorcycle(string link, MotoContext context)
        {
            Enduro? motoInfo = context.Enduroes.FirstOrDefault(m => m.Link == link);

            string output = string.Empty;

            if (motoInfo is not null)
            {
                output = $"{motoInfo.Make} {motoInfo.Model} ({motoInfo.Year}) with Profit of ({motoInfo.Profit}) will be removed from the Database.";
                context.Remove(motoInfo);
                context.SaveChanges();
            }
            else
            {
                output = $"No such link exists in the {this.GetType().Name}";
            }

            context.Dispose();

            return output;
        }

        public async Task<string> RepositoryStatusAsync()
        {
            using var context = new MotoContext();

            if (await context.Enduroes.AnyAsync())
            {
                var motoTable = await context.Enduroes
                    .Include(m => m.Make).Include(m => m.Model)
                    .Include(m => m.Cc).Include(m => m.Year)
                    .AsNoTracking()
                    .Select(m => new
                    {
                        m.Make.MakeName,
                        m.Model.ModelName,
                        m.Cc.EngineSize,
                        m.Year.Year1,
                        m.TotalCost,
                        m.Profit,
                        m.Roi,
                    })
                    .ToListAsync();

                StringBuilder repoBuilder = new();

                repoBuilder.AppendLine($"{Environment.NewLine}{GetType().Name} has the following motorcycles.");

                foreach (var m in motoTable)
                {
                    repoBuilder.AppendLine($"{m.MakeName} {m.ModelName} {m.EngineSize} ({m.Year1}). Cost: {m.TotalCost}, Profit: {m.Profit}, ROI: {m.Roi}.");
                }

                return repoBuilder.ToString().TrimEnd();
            }
            else
            {
                return $"{GetType().Name} is empty!";
            }
        }

        public async Task TopFiveByProfitAsync()
        {
            using var context = new MotoContext();

            if (!await context.Enduroes.AnyAsync())
            {
                Console.WriteLine($"The {GetType().Name} is empty!");
                return;
            }

            var topFiveByProfit = await context.Enduroes
                .AsNoTracking()
                .OrderByDescending(m => m.Profit)
                .Take(5)
                .Select(m => new
                {
                    m.Make.MakeName,
                    m.Model.ModelName,
                    m.Cc.EngineSize,
                    m.Year.Year1,
                    m.Profit,
                    m.Roi
                })
                .ToListAsync();

            var top5Builder = new StringBuilder();

            foreach (var m in topFiveByProfit)
            {
                top5Builder.AppendLine($"{m.MakeName} {m.ModelName} {m.EngineSize} ({m.Year1}) - Profit: {m.Profit} / ROI: {m.Roi}.");
            }

            Console.WriteLine(top5Builder.ToString().TrimEnd());
        }
    }
}
