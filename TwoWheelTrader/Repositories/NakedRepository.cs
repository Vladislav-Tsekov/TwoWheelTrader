﻿using TwoWheelTrader.Models.Interfaces;
using TwoWheelTrader.Repositories.Interfaces;

namespace TwoWheelTrader.Repositories
{
    public class NakedRepository : IRepository<INaked>
    {
        private readonly List<INaked> motorcycles;

        public NakedRepository()
        {
            motorcycles = new List<INaked>();
        }

        public IReadOnlyCollection<INaked> Motorcycles => motorcycles;

        public void AddMotorcycle(INaked motorcycle)
        {
            motorcycles.Add(motorcycle);
        }

        public void TopFiveByProfit(IRepository<IEnduro> motorcycles)
        {
            var sortedMoto = motorcycles.Motorcycles.OrderByDescending(m => m.Profit).Take(3);
        }

        public void TopFiveROI(IRepository<IEnduro> motorcycles)
        {
            var sortedMoto = motorcycles.Motorcycles.OrderByDescending(m => m.ROI).Take(5);
        }
    }
}
