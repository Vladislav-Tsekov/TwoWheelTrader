using System.Reflection;
using System.Text;
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

        public IMotorcycle CreateMotorcycle(string make, string model, int cc, int year, int foreignPrice, string link, int distance) 
        {
            IMotorcycle motorcycle = null;

            switch (make.ToLower())
            {
                case "yam":
                case "yamaha":
                    if (model == "yzf")
                    {
                        motorcycle = new Models.Motocross.Yamaha(model, cc, year, foreignPrice, link, distance);
                        motocross.AddMotorcycle(motorcycle);
                    }
                    else if (model == "wrf")
                    {
                        motorcycle = new Models.Enduro.Yamaha(model, cc, year, foreignPrice, link, distance);
                        enduro.AddMotorcycle(motorcycle);
                    }
                    break;

                case "hon":
                case "honda":
                    if (model == "crf")
                    {
                        motorcycle = new Models.Motocross.Honda(model, cc, year, foreignPrice, link, distance);
                        motocross.AddMotorcycle(motorcycle);
                    }
                    else if (model == "crx")
                    {
                        motorcycle = new Models.Enduro.Honda(model, cc, year, foreignPrice, link, distance);
                        motocross.AddMotorcycle(motorcycle);
                    }
                    break;

                case "kaw":
                case "kawasaki":
                    if (model == "kxf")
                    {
                        motorcycle = new Models.Motocross.Kawasaki(model, cc, year, foreignPrice, link, distance);
                        motocross.AddMotorcycle(motorcycle);
                    }
                    else if (model == "klx")
                    {
                        motorcycle = new Models.Enduro.Kawasaki(model, cc, year, foreignPrice, link, distance);
                        motocross.AddMotorcycle(motorcycle);
                    }
                    break;

                case "ktm":
                    if (model == "sxf")
                    {
                        motorcycle = new Models.Motocross.KTM(model, cc, year, foreignPrice, link, distance);
                        motocross.AddMotorcycle(motorcycle);
                    }
                    else if (model == "exc")
                    {
                        motorcycle = new Models.Enduro.KTM(model, cc, year, foreignPrice, link, distance);
                        enduro.AddMotorcycle(motorcycle);
                    }
                    break;

                case "hus":
                case "husqvarna":
                    if (model == "fc")
                    {
                        motorcycle = new Models.Motocross.Husqvarna(model, cc, year, foreignPrice, link, distance);
                        motocross.AddMotorcycle(motorcycle);
                    }
                    else if (model == "fe")
                    {
                        motorcycle = new Models.Enduro.Husqvarna(model, cc, year, foreignPrice, link, distance);
                        enduro.AddMotorcycle(motorcycle);
                    }
                    break;

                case "suz":
                case "suzuki":
                    if (model == "rmz")
                    {
                        motorcycle = new Models.Motocross.Suzuki(model, cc, year, foreignPrice, link, distance);
                        motocross.AddMotorcycle(motorcycle);
                    }
                    else if (model == "drz")
                    {
                        motorcycle = new Models.Enduro.Suzuki(model, cc, year, foreignPrice, link, distance);
                        motocross.AddMotorcycle(motorcycle);
                    }
                    break;

                case "gas":
                case "gasgas":
                    if (model == "mcf")
                    {
                        motorcycle = new Models.Motocross.GASGAS(model, cc, year, foreignPrice, link, distance);
                        motocross.AddMotorcycle(motorcycle);
                    }
                    else if (model == "ecf")
                    {
                        motorcycle = new Models.Enduro.GASGAS(model, cc, year, foreignPrice, link, distance);
                        motocross.AddMotorcycle(motorcycle);
                    }
                    break;
            }

            if (motorcycle is null)
            {
                Console.WriteLine($"Failed to create motorcycle.");
                return motorcycle;
            }

            Console.WriteLine($"The potential profit for this {motorcycle.GetType().Name} is: {motorcycle.Profit:F2}");
            return motorcycle;
        }

        public int DestinationExists(string pickUpDestination)
        {
            string filePath = @"C:\Users\tseko\OneDrive\Documents\SoftUni\C# Personal Projects\TwoWheelTrader\TwoWheelTrader\Routes\Routes.csv";
            int distance = 0;

            using var reader = new StreamReader(filePath);
            reader.ReadLine(); // Used to skip the column titles.

            string townName = string.Empty;

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] data = line.Split(',');

                townName = data[0].Trim();
                distance = int.Parse(data[1].Trim());

                Console.WriteLine($"City: {townName} / Distance: {distance}.");

                if (townName == pickUpDestination)
                {
                    return distance;
                }
            }

            reader.Dispose();
            Console.WriteLine($"No matching cities found. Please write down the distance from Linkoping to {pickUpDestination}");
            
            using var writer = new StreamWriter(filePath, append: true);

            int newDistance = int.Parse(Console.ReadLine());

            Console.WriteLine($"New location added: {pickUpDestination}. Distance from Linkoping: {newDistance}");
            writer.WriteLine($"{pickUpDestination}, {newDistance}");
            writer.Dispose();

            return newDistance;
        }
    
        public string GetMotorcycleInfo(string link, string targetRepo)
        {
            IMotorcycle currMoto;

            if (targetRepo == "mx")
            {
                currMoto = motocross.MotorcycleInfo(link);

                if (currMoto is null)
                {
                    return $"This motorcycle does not exists in the Motocross repository!";
                }
                else
                {
                    StringBuilder sb = new();

                    sb.AppendLine($"Information requested about motorcycle: {currMoto.Make} {currMoto.Model}, CC: {currMoto.CC}, Year: {currMoto.Year}");
                    sb.AppendLine($"The price in BGN is: {currMoto.PriceBGN}. The current market price in Bulgaria is: {currMoto.MarketPrice}");
                    sb.AppendLine($"The estimated profit is: {currMoto.Profit}, ROI %: {currMoto.ROI}.");

                    return sb.ToString().TrimEnd();
                }
            }
            else if (targetRepo == "enduro")
            {
                // LOGIC, AVOID REPEATING THE CODE FROM THE ROWS ABOVE
            }

            return $"Wrong input format. Try again!";
        }

        public void GetRepositoriesStatus()
        {
            Console.WriteLine(motocross.RepositoryStatus());
            Console.WriteLine(enduro.RepositoryStatus());
            Console.WriteLine(naked.RepositoryStatus());
            Console.WriteLine(sport.RepositoryStatus());
            Console.WriteLine(tourer.RepositoryStatus());
        }

        public void GetTransportationCost()
        {
            throw new NotImplementedException();
        }

        public string RemoveMotorcycle(IMotorcycle motorcycle)
        {
            throw new NotImplementedException();
        }

        //DEPRECATED

        /*public string Add(IMotorcycle motorcycle)
        {
            var currentClass = motorcycle.GetType();
            var motorcycleMake = currentClass.Name;

            Console.WriteLine(motorcycleMake); //TESTING PURPOSES

            Type[] motorcycleInterface = currentClass.GetInterfaces();
            var category = motorcycleInterface[0].Name;

            Console.WriteLine(category); // TESTING PURPOSES

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
        }*/

        /* public void PrintResult()
        {
            Console.WriteLine(motocross.RepositoryStatus());
            Console.WriteLine(enduro.RepositoryStatus());
            Console.WriteLine(naked.RepositoryStatus());
            Console.WriteLine(sport.RepositoryStatus());
            Console.WriteLine(tourer.RepositoryStatus());
        }*/
    }
}
