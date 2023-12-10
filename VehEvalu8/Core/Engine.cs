using VehEvalu8.Core.Interfaces;
using VehEvalu8.Data;

namespace VehEvalu8.Core
{
    public class Engine : IEngine
    {
        private readonly IController controller;

        public Engine(IController controller)
        {
            this.controller = controller;   
        }

        public void RunProgram()
        {
            while (true)
            {
                Console.WriteLine($"{Environment.NewLine}" +
                                  $"Please select a command and input motorcycle's --| Make, Model, CC, Year, Price, Link |--." +
                                  $"{Environment.NewLine}Available commands: 'Add', 'Remove', 'Check', 'Status', 'Top' or 'Done'." +
                                  $"{Environment.NewLine}");

                string[] input = Console.ReadLine().ToLower().Split();

                try
                {
                    string command = input[0];

                    if (command == "done")
                    {
                        Task.Run(async () => await controller.GetRepositoriesStatusAsync());
                        Environment.Exit(0);
                    }
                    else if (command == "add")
                    {
                        string make = input[1];
                        string model = input[2];
                        int cc = int.Parse(input[3]);
                        int year = int.Parse(input[4]);
                        int foreignPrice = int.Parse(input[5]);
                        string link = input[6].Trim(); 

                        Console.WriteLine($"Please input the current location of the vehicle:");
                        string location = Console.ReadLine().Trim();
                        int distance = controller.DestinationExists(location);

                        controller.CreateMotorcycle(make, model, cc, year, foreignPrice, link, distance);
                    }
                    else if (command == "remove")
                    {
                        string link = input[1].Trim();
                        controller.RemoveMotorcycle(link);
                    }
                    else if (command == "check")
                    {
                        string link = input[1].Trim();
                        Console.WriteLine(controller.GetMotorcycleInfoAsync(link));
                    }
                    else if (command == "status")
                    {
                        Task.Run(async () => await controller.GetRepositoriesStatusAsync()).Wait();
                    }
                    else if (command == "update")
                    {
                        //TODO - IMPLEMENT "UPDATE" COMMAND
                        // When a change of some property is needed, usually the price - when the motorcycle has had a discount
                        // Again - must search by link (???), or by primary key if I learn DB until then
                    }
                    else if (command == "top")
                    {
                        Task.Run(async () => await controller.TopFiveByProfitAsync()).Wait();
                    }
                    else
                    {
                        Console.WriteLine("Invalid command. Try again!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}{Environment.NewLine}" +
                                      $"{ex.StackTrace}{Environment.NewLine}" +
                                      $"{ex.InnerException}{Environment.NewLine}" +
                                      $"{ex.TargetSite}{Environment.NewLine}" +
                                      $"{ex.Source}{Environment.NewLine}");
                }
            }
        }
    }
}