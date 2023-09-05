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

                    if (input[0] == "done")
                    {
                        Environment.Exit(0);
                    }
                    else if (input[0] == "check")
                    {

                    }
                    // TO ADD MORE ELSE IFS BASED ON DIFFERENT SCENARIOS
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}