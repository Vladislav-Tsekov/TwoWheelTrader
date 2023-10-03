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
            switch (make.ToLower())
            {
                case "yam":
                case "yamaha":
                    if (model == "yzf")
                    {
                        return new Models.Motocross.Yamaha(model, cc, year, foreignPrice, link, distance);
                    }
                    else if (model == "wrf")
                    {
                        return new Models.Enduro.Yamaha(model, cc, year, foreignPrice, link, distance);
                    }
                    break;

                case "hon":
                case "honda":
                    if (model == "crf")
                    {
                        return new Models.Motocross.Honda(model, cc, year, foreignPrice, link, distance);
                    }
                    else if (model == "crx")
                    {
                        // To research possible Enduro addition
                    }
                    break;

                case "kaw":
                case "kawasaki":
                    if (model == "kxf")
                    {
                        return new Models.Motocross.Kawasaki(model, cc, year, foreignPrice, link, distance);
                    }
                    else if (model == "klx")
                    {
                        // To research possible Enduro addition
                    }
                    break;

                case "ktm":
                    if (model == "sxf")
                    {
                        return new Models.Motocross.KTM(model, cc, year, foreignPrice, link, distance);
                    }
                    else if (model == "exc")
                    {
                        return new Models.Enduro.KTM(model, cc, year, foreignPrice, link, distance);
                    }
                    break;

                case "hus":
                case "husqvarna":
                    if (model == "fc")
                    {
                        return new Models.Motocross.Husqvarna(model, cc, year, foreignPrice, link, distance);
                    }
                    else if (model == "fe")
                    {
                        return new Models.Enduro.Husqvarna(model, cc, year, foreignPrice, link, distance);
                    }
                    break;

                case "gas":
                case "gasgas":
                    if (model == "mcf")
                    {
                        return new Models.Motocross.GASGAS(model, cc, year, foreignPrice, link, distance);
                    }
                    else if (model == "ecf")
                    {
                        // To research possible Enduro addition
                    }
                    break;
            }

            return null; // Returns null for unsupported make/model combinations     
        }

        public string Add(IMotorcycle motorcycle)
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
        }

        public int DestinationExists(string pickUpDestination)
        {
            string filePath = @"C:\Users\tseko\OneDrive\Documents\SoftUni\C# Personal Projects\TwoWheelTrader\TwoWheelTrader\Routes\Routes.csv";
            int distance = 0;

            using var reader = new StreamReader(filePath);
            reader.ReadLine(); // SKIPPING THE COLUMN TITLES?

            string townName = string.Empty;

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] data = line.Split(',');

                townName = data[0].Trim();
                distance = int.Parse(data[1].Trim());

                Console.WriteLine($"City: {townName} / Distance: {distance}."); // TEST IF READING OCCURS OR NOT

                if (townName == pickUpDestination)
                {
                    return distance;
                }
            }

            reader.Dispose();

            // Create a StreamWriter to write to the CSV file
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
            enduro.RepositoryStatus();
            motocross.RepositoryStatus();

            //TO IMPLEMENT THE REST AS WELL
        }

        public void GetTransportationCost()
        {
            throw new NotImplementedException();
        }

        public string RemoveMotorcycle(IMotorcycle motorcycle)
        {
            throw new NotImplementedException();
        }

        public void PrintResult()
        {
            motocross.Repos
        }
    }
}
