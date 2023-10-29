using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoWheelTrader.Core;
using TwoWheelTrader.Models.Interfaces;
using TwoWheelTrader.Repositories;
using TwoWheelTrader.Repositories.Interfaces;
using Xunit;

namespace xUnitTests
{
    public class RepositoriesTests
    {
        [Fact]
        public void GetRepositoriesStatus()
        {
            MotocrossRepository motocross = new();
            EnduroRepository enduro = new();
            NakedRepository naked = new();
            SportRepository sport = new();
            TourerRepository tourer = new();

            HashSet<IRepository<IMotorcycle>> repos = new() { motocross, enduro, naked, sport, tourer };

            foreach (var repo in repos)
            {
                string result = repo.RepositoryStatus();
                Assert.Equal($"{repo.GetType().Name} is empty!", result);
            }
        }

        //TODO - ADD A CASE WHERE REPOSITORIES ARE NOT EMPTY!
    }
}
