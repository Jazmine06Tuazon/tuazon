using FlightAppService;
using FlightDataService;
using FlightModels;
using System;
using System.ComponentModel.Design;
using static FlightAppService.App;

namespace prog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 250, y = 340;
            int bagTotal = 0;
            int kg = 0;
            int s = 150, premium = 250;

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

            Console.Write("Passport Number: ");
            string passport = Console.ReadLine();
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
                models.Destination = Console.ReadLine();

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
                    Console.WriteLine("This scetion cannot be empty.");
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
                Console.Write("Enter Passport Number (numbers only): ");
                models.Passport = Console.ReadLine();

                App valid = new App();
                if (App.IsNumericOnly(passport))
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
            /*Console.WriteLine("Domestic flights:\n 1. Excess Baggage: ₱250-₱1,200 per kg \n 2. Prepaid Baggage ₱340-₱1,599");
            Console.WriteLine("Choose: ");
            int baggage = Convert.ToInt16(Console.ReadLine());

            switch (baggage)
            {
                case 1:
                    Console.Write("Enter kg: ");
                    kg = Convert.ToInt16(Console.ReadLine());
                    int p = x * kg;
                    bagTotal += p;
                    break;

                case 2:
                    Console.Write("Enter kg: ");
                    kg = Convert.ToInt16(Console.ReadLine());
                    int z = x * kg;
                    bagTotal += z;
                    break;
            }
            int bag = bagTotal;

            Console.WriteLine(" ");

            Console.WriteLine("Seat Selection");
            Console.WriteLine("1. Standard seats: Php150 - Php280(domestic) \n 2. Premium seats: Php250 - Php1, 099(domestic)");
            Console.WriteLine("Choose: ");
            int seat = Convert.ToInt16(Console.ReadLine());
            switch (seat)
            {
                case 1:
                    bag += s;
                    break;

                case 2:
                    bag += premium;
                    break;
            }
            int total = bag;
            Console.WriteLine(" ");

            Console.WriteLine("Travel Insurance");

            Console.WriteLine(" ");
            Console.WriteLine("Domestic Flights:\n1. One - way base fare: Php 88 - Php 1,427.57\n2. Round - trip: Php2, 668.73\nInternational Flights:\n1.One - way base fare: Php 588 -₱1, 299\n2. Round - trip: Php2, 668.73\nPromo Fares:\n1. Piso Fare: Php 1.00 base fare(limited seats)\n2.P10 Seat Sale: Php10 one - way base fare");
            */

            FlightService flightService = new FlightService();


            int totalCost = flightService.CalculateTotal();

            Console.WriteLine($"\nTotal Expenses for baggage and seat: {totalCost}");
            Console.WriteLine(" ");

            Console.WriteLine("Payment Method (cash or online payment): ");
            string payment = Console.ReadLine();
            Console.WriteLine(" ");

            Console.WriteLine("------ E-receipt -----");
            /*Console.WriteLine("Customer's Name: " + models.Name);
            Console.WriteLine("Customer's Passport: " + models.Passport);
            Console.WriteLine("Customer's Departure City: " + models.Departure);
            Console.WriteLine("Customer's Destination City: " + models.Destination);
            Console.WriteLine("Travel Dates: " + models.Dates);
           Console.WriteLine("Customer's Flight Type: " + models.Flight);*/


            PassengerData passengerData = new PassengerData();
            passengerData.AddPassenger(models);


            foreach (var p in passengerData.Passengers)
            {
                Console.WriteLine("Customer's Name: " + p.Name);
                Console.WriteLine("Customer's Passport: " + p.Passport);
                Console.WriteLine("Customer's Departure City: " + p.Departure);
                Console.WriteLine("Customer's Destination City: " + p.Destination);
                Console.WriteLine("Travel Dates: " + p.Dates);
                Console.WriteLine("Customer's Flight Type: " + p.Flight);
                Console.WriteLine("Customer's Payment Method: " + p.Payment);
                Console.WriteLine("Total Expenses for baggage and seat: " + p.TotalCost);
                Console.WriteLine();
                Console.WriteLine("Process Completed. Thank you!");
            }
        }
    }
}
