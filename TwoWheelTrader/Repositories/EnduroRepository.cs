using System.Text;
using TwoWheelTrader.Models.Interfaces;
using TwoWheelTrader.Repositories.Interfaces;
using VehEvalu8.Data.DBModels;
using VehEvalu8.Data;
using Microsoft.EntityFrameworkCore;

namespace TwoWheelTrader.Repositories
{
    public class EnduroRepository : IRepository<IMotorcycle>
    {
        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            using var context = new MotoContext();

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

        public Enduro MotorcycleInfo(string link)
        {
            var context = new MotoContext();
            Enduro? motoInfo = context.Enduroes.FirstOrDefault(m => m.Link == link);
            return motoInfo;
        }

        public string RepositoryStatus()
        {
            MotoContext? context = new();

            if (context.Enduroes.Any())
            {
                var motoTable = context.Enduroes
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
                    .ToList();

                StringBuilder dbRepoBuilder = new();

                dbRepoBuilder.AppendLine($"{Environment.NewLine}{this.GetType().Name} has the following motorcycles.");

                foreach (var m in motoTable)
                {
                    dbRepoBuilder.AppendLine($"{m.MakeName} {m.ModelName} {m.EngineSize} ({m.Year1}). Cost: {m.TotalCost}, Profit: {m.Profit}, ROI: {m.Roi}.");
                }

                return dbRepoBuilder.ToString().TrimEnd();
            }
            else
            {
                return $"{this.GetType().Name} is empty!";
            }
        }

        public void TopFiveByProfit(IRepository<IMotorcycle> motorcycles)
        {

        }

        public void TopFiveROI(IRepository<IMotorcycle> motorcycles)
        {

        }
    }
}
