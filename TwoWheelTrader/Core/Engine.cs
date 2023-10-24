using TwoWheelTrader.Core.Interfaces;
using TwoWheelTrader.Models.Interfaces;

namespace TwoWheelTrader.Core
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
                Console.WriteLine($"Please input motorcycle's --| Make, Model, CC, Year, Price, Link |--.");
                Console.WriteLine($"Available commands: 'Add', 'Check', 'Status' or 'Done'.");

                string[] input = Console.ReadLine().ToLower().Split();

                try
                {
                    string command = input[0];

                    if (command == "done")
                    {
                        controller.GetRepositoriesStatus();
                        Environment.Exit(0);
                    }
                    else if (command == "add")
                    {
                        string make = input[1];
                        string model = input[2];
                        int cc = int.Parse(input[3]);
                        int year = int.Parse(input[4]);
                        int foreignPrice = int.Parse(input[5]);
                        string link = input[6]; 

                        Console.WriteLine($"Please input the pick-up location of the vehicle:");
                        string pickUpDestination = Console.ReadLine();
                        int distance = controller.DestinationExists(pickUpDestination);

                        controller.CreateMotorcycle(make, model, cc, year, foreignPrice, link, distance);
                    }
                    else if (command == "remove")
                    {
                        // Once the program is connected to the MS SQL this command should become a viable option
                        // I will need primary keys, need to find what hold the bikes apart, besides the primary key, like a web link
                    }
                    else if (command == "check")
                    {
                        // EXAMPLE INPUT: [1] "https://www.../ktm_350_exc_f_sixdays/110994476" / [2] MX (mx), ENDURO (enduro)

                        string link = input[1];
                        string targetRepo = input[2];
                        Console.WriteLine(controller.GetMotorcycleInfo(link, targetRepo));
                    }
                    else if (command == "status")
                    {
                        controller.GetRepositoriesStatus();
                    }
                    else if (command == "update")
                    {
                        // When a change of some property is needed, usually the price - when the motorcycle has had a discount
                        // Again - must search by link (???), or by primary key if I learn DB until then
                    }
                    else
                    {
                        Console.WriteLine("Invalid command. Try again!");
                    }

                    // TO ADD MORE ELSE IFS BASED ON DIFFERENT SCENARIOS
                    // ARE FORMS A VIABLE OPTION OR I SHOULD LEARN F.E. FIRST AND APPLY IT DIRECTLY?
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}