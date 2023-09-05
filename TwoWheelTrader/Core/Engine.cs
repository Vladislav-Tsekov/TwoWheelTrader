using TwoWheelTrader.Core.Interfaces;

namespace TwoWheelTrader.Core
{
    public class Engine : IEngine
    {
        public void RunProgram()
        {
            while (true)
            {
                string[] input = Console.ReadLine().ToLower().Split();

                try
                {
                    string output = string.Empty;
                    string command = input[0];

                    while (true)
                    {
                        if (command == "done")
                        {
                            Environment.Exit(0);
                        }
                        else if (command == "add")
                        {
                            // 1 = YAMAHA / 2 = YZF / 3 = 250 / 4 = 2019 / 5 = 33000 (FOREIGN PRICE - PRE-CONVERT)
                        }
                        else if (command == "remove")
                        {
                            // Once the program is connected to the MS SQL this command should become a viable option
                        }
                        else if (command == "update")
                        {
                            // When a change of some property is needed, usually the price - when the motorcycle has had a discount
                        }
                        else
                        {
                            Console.WriteLine("Invalid command. Try again!");
                        }
                        // TO ADD MORE ELSE IFS BASED ON DIFFERENT SCENARIOS
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}