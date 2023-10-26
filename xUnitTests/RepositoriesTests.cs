using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoWheelTrader.Core;
using TwoWheelTrader.Repositories;
using Xunit;

namespace xUnitTests
{
    public class RepositoriesTests
    {
        [Fact]
        public void GetRepositoriesStatus()
        {
            // Arrange
            Controller controller = new();
            MotocrossRepository motocross = new();

            string result = motocross.RepositoryStatus();

            Assert.Equal($"{motocross.GetType().Name} is empty!", result);
        }
    }
}
