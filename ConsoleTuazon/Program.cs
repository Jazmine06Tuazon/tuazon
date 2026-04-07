using FlightAppService;
using FlightBookingModels;
using System;
using System.Numerics;

namespace FlightBookingSystem
{
    class Program
    {
        static AppService service;
        static void Main(string[] args)
        {
            try
            {
                service = new AppService();
                service.SeedDataIfEmpty();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error initializing AppService:");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException?.Message);
            }

            while (true)
            {

                Console.WriteLine("\n1. Add Booking");
                Console.WriteLine("2. View Booking");
                Console.WriteLine("3. Update Booking");
                Console.WriteLine("4. Delete Booking");
                Console.WriteLine("5. View All");
                Console.WriteLine("6. Exit");

                Console.WriteLine("Choice:");
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddBooking();
                            break;
                        case "2":
                            ViewBooking();
                            break;

                        case "3":
                            UpdateBooking();
                            break;

                        case "4":
                            DeleteBooking();
                            break;

                        case "5":
                            ViewAll();
                            break;

                        case "6":
                            return;

                        default:
                            Console.WriteLine("Invalid input.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        static void AddBooking()
        {
                FlightModels b = new FlightModels();

                b.PassportNumber = GetInput("Passport");
                b.Name = GetInput("Name");
                b.Nationality = GetInput("Nationality");
                b.Departure = GetInput("Departure City");
                b.Destination = GetInput("Destination City");
                b.Date = GetInput("Travel Dates");
                b.Type = GetInput("Flight Type [one-way or round-trip]");
                Console.WriteLine(" ");
                Console.WriteLine("----- Personal Information ----");

                b.Contact = GetInput("Contact Number");
                b.Email = GetInput("Email Address");

                Console.WriteLine("Baggage kg: ");
                b.BaggageKg = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("1. Excess Baggage(200Php/kg)");
                    Console.WriteLine("2. Prepaid Baggage(300Php/kg)");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            b.BaggageType = "1";
                            break;

                        case "2":
                            b.BaggageType = "2";
                            break;

                        default:
                            Console.WriteLine("Invalid baggage type.");
                            return;
                    }
                
                service.Add(b);
                Console.WriteLine("Added!");
            }

        static void ViewBooking()
        {
            string pass = GetInput("Passport");
            var res = service.GetBooking(pass);

            if (res != null)
            {
                Console.WriteLine($"Name: {res.Name}\nNationality {res.Nationality}\nDeparture: {res.Departure}\nDestination: {res.Destination}\nTravel Dates: {res.Date}\nTotal Cost: {res.TotalCost}");
            }
            else
            {
                Console.WriteLine("Not found.");
            }
        }
                
        static void UpdateBooking()
        {
            FlightModels up = new FlightModels();

            up.PassportNumber = GetInput("Passport");
            up.Name = GetInput("Name");
            up.Nationality = GetInput("Nationality");
            up.Departure = GetInput("Departure City");
            up.Destination = GetInput("Destination City");
            up.Date = GetInput("Travel Dates");
            up.Type = GetInput("Flight Type [one-way or round-trip");
            Console.WriteLine(" ");
            Console.WriteLine("----- Personal Information ----");

            up.Contact = GetInput("Contact Number");
            up.Email = GetInput("Email Address");

            Console.WriteLine("Baggage kg: ");
            up.BaggageKg = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("1. Excess Baggage(200Php/kg)");
            Console.WriteLine("2. Prepaid Baggage(300Php/kg)");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    up.BaggageType = "1";
                    break;

                case "2":
                    up.BaggageType = "2";
                    break;

                default:
                    Console.WriteLine("Invalid baggage type.");
                    return;
            }

            service.Update(up);
            Console.WriteLine("Updated!");
        }
        static void DeleteBooking()
        {
            string del = GetInput("Passport");
            service.Delete(del);
            Console.WriteLine("Deleted!");
        }

        static void ViewAll()
        {
            var all = service.GetAllBookings();

            foreach (var item in all)
            {
                Console.WriteLine($"{item.PassportNumber} - {item.Name} - {item.Destination}");
            }
        }
        static string GetInput(string field)
        {
            string value;

            do
            {
                Console.Write($"{field}: ");
                value = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(value));

            return value;
        }

       /* static int GetNumberInput(string field)
        {
            int value;

            while (true)
            {
                Console.Write($"{field}: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out value) && value >= 0)
                    return value;

                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }*/


    }
}