using TwoWheelTrader.Core.Interfaces;
using TwoWheelTrader.Models.Interfaces;
using TwoWheelTrader.Repositories;

namespace TwoWheelTrader.Core
{
    public class Controller : IController
    {
        private EnduroRepository enduro;
        private MotocrossRepository motocross;
        private NakedRepository naked;
        private SportRepository sport;
        private TourerRepository tourer;

        public Controller()
        {
            enduro = new EnduroRepository();
            motocross = new MotocrossRepository();
            naked = new NakedRepository();
            sport = new SportRepository();
            tourer = new TourerRepository();
        }

        public string AddMotorcycle(IMotorcycle motorcycle)
        {
            string output = string.Empty;

            var currentClass = motorcycle.GetType();
            Console.WriteLine(currentClass); // ONLY FOR TEST PURPOSES
            Type[] interfaces = currentClass.GetInterfaces();
            foreach (var inter in interfaces)
            {
                Console.WriteLine(inter);
            }

            if (true)
            {

            }

            return output;
        }

        public string GetMotorcycleInfo(IMotorcycle motorcycle)
        {
            throw new NotImplementedException();
        }

        public string GetMotorcycleList()
        {
            throw new NotImplementedException();
        }

        public string RemoveMotorcycle(IMotorcycle motorcycle)
        {
            throw new NotImplementedException();
        }
    }
}
