using TwoWheelTrader.Core.Interfaces;
using TwoWheelTrader.Models.Interfaces;

namespace TwoWheelTrader.Core
{
    public class Engine : IEngine
    {
        private readonly IController controller;

        public Engine()
        {
            controller = new Controller();   
        }

        public void RunProgram()
        {
            while (true)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                string[] input = Console.ReadLine().ToLower().Split();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                try
                {
                    string output = string.Empty;
                    string command = input[0];

                    if (command == "done")
                    {
                        Environment.Exit(0);
                    }
                    else if (command == "add")
                    {
                        // EXAMPLE INPUT: [1] = YAMAHA / [2] = YZF / [3] = 250 / [4] = 2019 / [5] = 33000 (FOREIGN PRICE - PRE-CONVERT) / [6] = www.blocket.com/...

                        // IMPLEMENTED MOTOCROSS MODELS
                        // IMPLEMENTED ENDURO MODELS

                        string make = input[1];
                        string model = input[2];
                        int cc = int.Parse(input[3]);
                        int year = int.Parse(input[4]);
                        int foreignPrice = int.Parse(input[5]);
                        string link = input[6]; //ADD TO CONSTRUCTORS - MX/ENDURO MODELS / INTERFACES AS WELL

                        if (make == "yam" || make == "yamaha")
                        {
                            if (model == "yzf")
                            {
                                IMotorcycle yamaha = new Models.Motocross.Yamaha(model, cc, year, foreignPrice, link);
                                Console.WriteLine(controller.Add(yamaha)); 
                            }
                            else if (model == "wrf")
                            {
                                IMotorcycle yamaha = new Models.Enduro.Yamaha(model, cc, year, foreignPrice, link);
                                controller.Add(yamaha);
                            }
                        }
                        else if (make == "hon" || make == "honda")
                        {
                            if (model == "crf")
                            {
                                IMotorcycle honda = new Models.Motocross.Honda(model, cc, year, foreignPrice, link);
                                controller.Add(honda);
                            }
                        }
                        else if (make == "kaw" || make == "kawasaki")
                        {
                            if (model == "kxf")
                            {
                                IMotorcycle kawasaki = new Models.Motocross.Kawasaki(model, cc, year, foreignPrice, link);
                                controller.Add(kawasaki);
                            }
                        }
                        else if (make == "ktm")
                        {
                            if (model == "sxf")
                            {
                                IMotorcycle ktm = new Models.Motocross.KTM(model, cc, year, foreignPrice, link);
                                controller.Add(ktm);
                            }
                            else if (model == "exc")
                            {
                                IMotorcycle ktm = new Models.Enduro.KTM(model, cc, year, foreignPrice, link);
                                controller.Add(ktm);
                            }
                        }
                        else if (make == "hus" || make == "husqvarna")
                        {
                            if (model == "fc")
                            {
                                IMotorcycle husqvarna = new Models.Motocross.Husqvarna(model, cc, year, foreignPrice, link);
                                controller.Add(husqvarna);
                            }
                            else if (model == "fe")
                            {
                                IMotorcycle husqvarna = new Models.Enduro.Husqvarna(model, cc, year, foreignPrice, link);
                                controller.Add(husqvarna);
                            }
                        }
                        else if (make == "gas" || make == "gasgas")
                        {
                            if (model == "mcf")
                            {
                                IMotorcycle gasgas = new Models.Motocross.GASGAS(model, cc, year, foreignPrice, link);
                                controller.Add(gasgas);
                            }

                            // MUST IMPLEMENT THE GASGAS ENDURO MODEL AT SOME POINT
                        }
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