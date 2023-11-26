using System.Text;
using VehEvalu8.Models.Interfaces;
using VehEvalu8.Repositories.Interfaces;

namespace VehEvalu8.Repositories
{
    public class NakedRepository : IRepository<IMotorcycle>
    {
        private readonly List<IMotorcycle> motorcycles;

        public NakedRepository()
        {
            motorcycles = new List<IMotorcycle>();
        }

        public IReadOnlyCollection<IMotorcycle> Motorcycles => motorcycles;

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            motorcycles.Add(motorcycle);
        }

        public IMotorcycle MotorcycleInfo(string link)
        {
            var findMotorcycleByLink = motorcycles.Where(m => m.Link == link).FirstOrDefault();
            return findMotorcycleByLink!;
        }

        public string RemoveMotorcycle(string link)
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
