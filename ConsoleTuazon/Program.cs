using FlightDataService;
using FlightModels;
using System;
using System.ComponentModel.Design;
using System.Xml.Linq;
using static FlightDataService.App;

namespace prog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 250, y = 340;
            int bagTotal = 0;
            int kg = 0, baggage = 0;
            int s = 150, premium = 250;
            int seat = 0;

            Console.WriteLine("PASSENGER INFORMATION");
            Console.WriteLine(" ");


            Models models = new Models();

            while (true)
            {
                Console.Write("Full Name: ");
                models.Name = Console.ReadLine();

                App valid = new App();
                if (App.IsValidFullName(models.Name))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid name.");
                }
            }


            while (true)
            {
                Console.Write("Nationality: ");
                models.Nationality = Console.ReadLine();

                App valid = new App();
                if (App.IsValidFullName(models.Nationality))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid.");
                }
            }


            while (true)
            {
                Console.Write("Enter Passport Number (numbers only): ");
                models.Passport = Console.ReadLine();

                App valid = new App();
                if (App.IsNumericOnly(models.Passport))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Only numbers are allowed and cannot be empty.");
                }
            }

            Console.WriteLine(" ");

            Console.WriteLine("FLIGHT DETAILS");
            Console.WriteLine(" ");

            while (true)
            {
                Console.Write("Departure City: ");
                models.Departure = Console.ReadLine();

                App valid = new App();
                if (App.IsValidFullName(models.Departure))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid.");
                }
            }

            while (true)
            {
                Console.Write("Destination City: ");
                models.Destination = Console.ReadLine();

                App valid = new App();
                if (App.IsValidFullName(models.Destination))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid.");
                }
            }

            while (true)
            {
                Console.Write("Travel Dates: ");
                models.Dates = Console.ReadLine();

                App valid = new App();
                if (App.IsInputEmpty(models.Dates))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Travel Dates cannot be empty.");
                }
            }


            while (true)
            {
                Console.Write("Flight type (one-way or round-trip): ");
                models.Flight = Console.ReadLine();

                App valid = new App();
                if (App.IsInputEmpty(models.Flight))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("This section cannot be empty.");
                }
            }
            Console.WriteLine(" ");


            Console.WriteLine("CONTACT INFORMATION");
            Console.WriteLine(" ");


            while (true)
            {
                Console.Write("Email Address: ");
                models.Email = Console.ReadLine();

                App valid = new App();
                if (App.IsInputEmpty(models.Email))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Email Address cannot be empty.");
                }
            }

            while (true)
            {
                Console.Write("Enter Contact Number (numbers only): ");
                models.Contact = Console.ReadLine();

                App valid = new App();
                if (App.IsNumericOnly(models.Contact))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Only numbers are allowed and cannot be empty.");
                }
            }

            Console.WriteLine(" ");

            Console.WriteLine("ADDITIONAL SERVICES");
            Console.WriteLine(" ");

            Console.WriteLine("Baggage Allowance");


            FlightService flightService = new FlightService();

            while (true)
            {
                Console.WriteLine("Baggage Allowance");
                Console.WriteLine("1. Excess Baggage: ₱250 per kg \n2. Prepaid Baggage: ₱340 per kg");
                Console.Write("Enter your option [1/2]: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out baggage) || (baggage != 1 && baggage != 2))
                {
                    Console.WriteLine("Invalid choice. Enter 1 or 2");
                    continue;
                }

                while (true)
                {
                    Console.Write("Enter kg: ");
                    string kgInput = Console.ReadLine();

                    if (!int.TryParse(kgInput, out kg) || kg <= 0)
                    {
                        Console.WriteLine("Invalid kg. Enter a positive number.");
                        continue;
                    }
                    break;
                }
                bagTotal = flightService.HandleBaggage(baggage, kg);
                break;
            }

            while (true)
            {
                Console.WriteLine("\nSeat Selection:");
                Console.WriteLine("1. Standard seats: Php150 - Php280\n2. Premium seats: Php250 - Php1,099");
                Console.Write("Enter your option [1/2]: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out seat) || (seat != 1 && seat != 2))
                {
                    Console.WriteLine("Invalid Choice.");
                    continue;
                }
                break;
            }

            int seatCost = flightService.HandleSeat(seat);
            int total = bagTotal + seatCost;

            Console.WriteLine(" ");
            Console.WriteLine("Payment Method (cash or online payment): ");
            string payment = Console.ReadLine();

            models.Payment = payment;
            models.Total = total;

            Console.WriteLine(" ");

            Console.WriteLine("------ E-receipt -----");

            JsonData json = new JsonData();

            json.SaveFlight(models);

            var passengers = json.Flight();


            foreach (var p in passengers)
            {
                Console.WriteLine("Customer's Name: " + p.Name);
                Console.WriteLine("Customer's Passport: " + p.Passport);
                Console.WriteLine("Customer's Departure City: " + p.Departure);
                Console.WriteLine("Customer's Destination City: " + p.Destination);
                Console.WriteLine("Travel Dates: " + p.Dates);
                Console.WriteLine("Customer's Flight Type: " + p.Flight);
                Console.WriteLine("Customer's Payment Method: " + p.Payment);
                Console.WriteLine("Total Expenses for baggage and seat: " + p.Total);
                Console.WriteLine();
                Console.WriteLine("Process Completed. Thank you!");
            }
        }
    }
}

