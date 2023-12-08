using Moq;
using VehEvalu8.Core;
using VehEvalu8.Data;
using VehEvalu8.Data.DBModels;
using VehEvalu8.Models.Interfaces;
using VehEvalu8.Repositories.Interfaces;
using Xunit;

namespace xUnitTests
{
    public class ControllerTests
    {
        [Fact]
        public void CreateMotorcycleMustCallRepository()
        {
            // Arrange
            var mockEnduroRepository = new Mock<IRepository<Enduro>>();
            var mockMotocrossRepository = new Mock<IRepository<Motocross>>();
            var mockContext = new Mock<MotoContext>();
        }

        [Fact]
        public void GetMotorcycleInfoAsyncMustReturnsData()
        {
            // Arrange
            var mockEnduroRepository = new Mock<IRepository<Enduro>>();
            var mockMotocrossRepository = new Mock<IRepository<Motocross>>();
            var mockContext = new Mock<MotoContext>();
        }
    }
}
