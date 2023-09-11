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

        public string Add(IMotorcycle motorcycle)
        {
            var currentClass = motorcycle.GetType();
            var motorcycleMake = currentClass.Name;
            Console.WriteLine(motorcycleMake);
            Type[] motorcycleInterface = currentClass.GetInterfaces();
            var category = motorcycleInterface[0].Name;

            string output;

            if (category == "IEnduro")
            {
                enduro.AddMotorcycle(motorcycle);
                output = $"{motorcycleMake} added successfully!";
            }
            else if (category == "IMotocross")
            {
                motocross.AddMotorcycle(motorcycle);
                output = $"{motorcycleMake} added successfully!";
            }
            else if (category == "INaked")
            {
                naked.AddMotorcycle(motorcycle);
                output = $"{motorcycleMake} added successfully!";
            }
            else if (category == "ISport")
            {
                sport.AddMotorcycle(motorcycle);
                output = $"{motorcycleMake} added successfully!";
            }
            else if (category == "ITourer")
            {
                tourer.AddMotorcycle(motorcycle);
                output = $"{motorcycleMake} added successfully!";
            }
            else
            {
                throw new ArgumentException($"Could not add the motorcycle! Please check for errors and try again! Class: Controller / Method: Add");
            }

            return output;
        }

        public string GetMotorcycleInfo(IMotorcycle motorcycle)
        {

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
