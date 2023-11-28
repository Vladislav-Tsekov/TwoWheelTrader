using VehEvalu8.Data;
using VehEvalu8.Models.Interfaces;
using VehEvalu8.Repositories.Interfaces;

namespace VehEvalu8.Repositories
{
    public class SportRepository : IRepository<IMotorcycle>
    {
        private readonly List<IMotorcycle> motorcycles;

        public SportRepository()
        {
            motorcycles = new List<IMotorcycle>();
        }

        public IReadOnlyCollection<IMotorcycle> Motorcycles => motorcycles;

        public void AddMotorcycle(IMotorcycle motorcycle, MotoContext context)
        {
            motorcycles.Add(motorcycle);
        }

        public IMotorcycle MotorcycleInfo(string link)
        {
            var findMotorcycleByLink = motorcycles.Where(m => m.Link == link).FirstOrDefault();
            return findMotorcycleByLink!;
        }

        public string RemoveMotorcycle(string link, MotoContext context)
        {
            throw new NotImplementedException();
        }

        public Task<string> RepositoryStatusAsync()
        {
            throw new NotImplementedException();
        }

        public Task TopFiveByProfitAsync()
        {
            throw new NotImplementedException();
        }
    }
}
