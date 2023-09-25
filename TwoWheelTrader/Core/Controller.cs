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
            string filePath = @"../../../Routes.csv";
            int distance = 0;

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found. Distance will be 0.");
                return distance;
            }

            try
            {
                using var reader = new StreamReader(filePath);
                reader.ReadLine(); // SKIPPING THE COLUMN TITLES?

                string townName = string.Empty;

                while (!reader.EndOfStream)
                {
                    if (pickUpDestination != townName)
                    {
                        string line = reader.ReadLine();
                        string[] data = line.Split(',');

                        townName = data[0].Trim();
                        distance = int.Parse(data[1].Trim());

                        Console.WriteLine($"City: {townName} / Distance: {distance}."); // TEST IF READING OCCURS OR NOT

                        if (townName == pickUpDestination)
                        {
                            break;
                        }
                    }

                    else
                    {
                        Console.WriteLine($"No matching cities found. Please write down the distance from Linkoping to {pickUpDestination}");
                        try
                        {
                            // Create a StreamWriter to write to the CSV file
                            using (var writer = new StreamWriter(filePath, append: true))
                            {
                                writer.WriteLine($"");    
                            }

                            Console.WriteLine("Data has been written to " + filePath);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Failed to generate output: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not read/open the file: " + ex.Message);
            }
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
    }
}
