using System.Text;
using VehEvalu8.Core.Interfaces;
using VehEvalu8.Data;
using VehEvalu8.Data.DBModels;
using VehEvalu8.Models.Interfaces;
using VehEvalu8.Repositories;

namespace VehEvalu8.Core
{
    public class Controller : IController
    {
        public EnduroRepository enduro;
        public MotocrossRepository motocross;
        public NakedRepository naked;
        public SportRepository sport;
        public TourerRepository tourer;
        public MotoContext context;

        public Controller()
        {
            enduro = new EnduroRepository();
            motocross = new MotocrossRepository();
            naked = new NakedRepository();
            sport = new SportRepository();
            tourer = new TourerRepository();
            context = new MotoContext();
        }

        public IMotorcycle CreateMotorcycle(string make, string model, int cc, int year, int foreignPrice, string link, int distance) 
        {
            IMotorcycle motorcycle = null;

            switch (make.ToLower())
            {
                case "yam":
                case "yamaha":
                    if (model == "yzf" || model == "yz-f")
                    {
                        motorcycle = new Models.Motocross.Yamaha(cc, year, foreignPrice, link, distance);
                        motocross.AddMotorcycle(motorcycle, context);
                    }
                    else if (model == "wrf" || model == "wr-f")
                    {
                        motorcycle = new Models.Enduro.Yamaha(cc, year, foreignPrice, link, distance);
                        enduro.AddMotorcycle(motorcycle, context);
                    }
                    break;

                case "hon":
                case "honda":
                    if (model == "crf" || model == "cr-f")
                    {
                        motorcycle = new Models.Motocross.Honda(cc, year, foreignPrice, link, distance);
                        motocross.AddMotorcycle(motorcycle, context);
                    }
                    else if (model == "crx" || model == "cr-x")
                    {
                        motorcycle = new Models.Enduro.Honda(cc, year, foreignPrice, link, distance);
                        motocross.AddMotorcycle(motorcycle, context);
                    }
                    break;

                case "kaw":
                case "kawasaki":
                    if (model == "kxf" || model == "kx-f")
                    {
                        motorcycle = new Models.Motocross.Kawasaki(cc, year, foreignPrice, link, distance);
                        motocross.AddMotorcycle(motorcycle, context);
                    }
                    else if (model == "klx")
                    {
                        motorcycle = new Models.Enduro.Kawasaki(cc, year, foreignPrice, link, distance);
                        motocross.AddMotorcycle(motorcycle, context);
                    }
                    break;

                case "ktm":
                    if (model == "sxf" || model == "sx-f")
                    {
                        motorcycle = new Models.Motocross.KTM(cc, year, foreignPrice, link, distance);
                        motocross.AddMotorcycle(motorcycle, context);
                    }
                    else if (model == "exc")
                    {
                        motorcycle = new Models.Enduro.KTM(cc, year, foreignPrice, link, distance);
                        enduro.AddMotorcycle(motorcycle, context);
                    }
                    break;

                case "hus":
                case "husqvarna":
                    if (model == "fc")
                    {
                        motorcycle = new Models.Motocross.Husqvarna(cc, year, foreignPrice, link, distance);
                        motocross.AddMotorcycle(motorcycle, context);
                    }
                    else if (model == "fe")
                    {
                        motorcycle = new Models.Enduro.Husqvarna(cc, year, foreignPrice, link, distance);
                        enduro.AddMotorcycle(motorcycle, context);
                    }
                    break;

                case "suz":
                case "suzuki":
                    if (model == "rmz" || model == "rm-z")
                    {
                        motorcycle = new Models.Motocross.Suzuki(cc, year, foreignPrice, link, distance);
                        motocross.AddMotorcycle(motorcycle, context);
                    }
                    else if (model == "drz" || model == "dr-z")
                    {
                        motorcycle = new Models.Enduro.Suzuki(cc, year, foreignPrice, link, distance);
                        motocross.AddMotorcycle(motorcycle, context);
                    }
                    break;

                case "gas":
                case "gasgas":
                    if (model == "mcf" || model == "mc-f")
                    {
                        motorcycle = new Models.Motocross.GASGAS(cc, year, foreignPrice, link, distance);
                        motocross.AddMotorcycle(motorcycle, context);
                    }
                    else if (model == "ecf" || model == "ec-f")
                    {
                        motorcycle = new Models.Enduro.GASGAS(cc, year, foreignPrice, link, distance);
                        motocross.AddMotorcycle(motorcycle, context );
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
            string filePath = @"C:\Users\tseko\OneDrive\Documents\SoftUni\C# Personal Projects\VehEvalu8\VehEvalu8\Routes\Routes.csv";
            int distance;

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
    
        public async Task<string> GetMotorcycleInfoAsync(string link)
        {
            Motocross mxExists = await motocross.MotorcycleInfoAsync(link, context);
            Enduro enduroExists = await enduro.MotorcycleInfoAsync(link, context);

            StringBuilder infoBuilder = new();

            infoBuilder.AppendLine((mxExists != null) 
                ? $"The motorcycle exists in the MotocrossRepository. ID: {mxExists.Id}" 
                : "No such link was found in the MotocrossRepository");

            infoBuilder.AppendLine((enduroExists != null)
                ? $"The motorcycle exists in the EnduroRepository. It's ID: {enduroExists.Id}"
                : "No such link was found in the EnduroRepository");

            return infoBuilder.ToString().TrimEnd();
        }

        public async Task GetRepositoriesStatusAsync()
        {
            Console.WriteLine(await motocross.RepositoryStatusAsync());
            Console.WriteLine(await enduro.RepositoryStatusAsync());
            // Console.WriteLine(await naked.RepositoryStatusAsync());
            // Console.WriteLine(await sport.RepositoryStatusAsync());
            // Console.WriteLine(await tourer.RepositoryStatusAsync());
        }

        public async Task TopFiveByProfitAsync()
        {
            var tasks = new List<Task>
            {
                motocross.TopFiveByProfitAsync(),
                enduro.TopFiveByProfitAsync(),
                // naked.TopFiveByProfitAsync(),
                // sport.TopFiveByProfitAsync(),
                // tourer.TopFiveByProfitAsync()
            };

            await Task.WhenAll(tasks);
        }

        public void GetTransportationCost()
        {
            throw new NotImplementedException();
            //TODO - SEPARATE LOGIC, CALCULATING THE FUEL COST FOR EACH MOTORCYCLE?
        }

        public void RemoveMotorcycle(string link)
        {
            Console.WriteLine(motocross.RemoveMotorcycle(link, context));
            Console.WriteLine(enduro.RemoveMotorcycle(link, context));
            //Console.WriteLine(naked.RemoveMotorcycle(link, context));
            //Console.WriteLine(sport.RemoveMotorcycle(link, context));
            //Console.WriteLine(tourer.RemoveMotorcycle(link, context));
        }
    }
}
