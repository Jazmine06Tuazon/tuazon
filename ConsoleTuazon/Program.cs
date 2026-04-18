using FlightAppService;
using FlightBookingModels;
using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace FlightBookingSystem
{
    class Program
    {
        static AppService service = new AppService();
        static void Main(string[] args)
        {
           
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
        }

        static void AddBooking()
        {
            FlightModels b = new FlightModels();

            b.PassportNumber = GetInput("Passport");
            Console.WriteLine(" ");

            Console.WriteLine("---- Personal Information ----");
            b.Name = GetInput("Name");
            b.Gender = GetInput("Gender");
            b.Nationality = GetInput("Nationality");
            b.Age = GetNumericInput("Age");
            b.BirthDate = GetInput("Birth Date");

            Console.WriteLine(" ");
            Console.WriteLine("---- Flight Details ------");
            b.Departure = GetInput("Departure City");
            b.Destination = GetInput("Destination City");
            b.Date = GetInput("Travel Dates");
            b.Type = GetInput("Flight Type [one-way or round-trip]");

            Console.WriteLine(" ");
            Console.WriteLine("----- Contact Information ----");

            b.Contact = GetInput("Contact Number");
            b.Email = GetEmail();
            Console.WriteLine(" ");
            Console.WriteLine("1. Excess Baggage(200Php/kg)");
            Console.WriteLine("2. Prepaid Baggage(300Php/kg)");
         
            int choice = GetNumericInput("Choice");

            switch (choice)
                    {
                        case 1:
                            b.BaggageType = "1";
                            break;

                        case 2:
                            b.BaggageType = "2";
                            break;

                        default:
                            Console.WriteLine("Invalid baggage type.");
                            return;
                    }

            Console.Write("Baggage kg: ");
            b.BaggageKg = Convert.ToInt32(Console.ReadLine());

            service.Add(b);
            Console.WriteLine("Added!");
            }

        static void ViewBooking()
        {
            string pass = GetInput("Passport");
            var res = service.GetBooking(pass);

            if (res != null)
            {
                Console.WriteLine($"Name: {res.Name}\nGender: {res.Gender}\nNationality {res.Nationality}\nAge: {res.Age}\nBirth Date: {res.BirthDate}\nDeparture: {res.Departure}\nDestination: {res.Destination}\nTravel Dates: {res.Date}\nFlight Type: {res.Type}\nEmail: {res.Email}\nContact Number: {res.Contact}\nTotal Cost: {res.TotalCost}");
            }
            else
            {
                Console.WriteLine("Not found.");
            }
        }
                
        static void UpdateBooking()
        {
            try
            {
                FlightModels up = new FlightModels();

                string pass = GetInput("Passport");

                var existing = service.GetBooking(pass);

                if (existing == null)
                {
                    Console.WriteLine("Booking does not exist or has been deleted.");
                    return; 
                }
                up.PassportNumber = pass;
                up.Name = GetInput("Name");
                up.Gender = GetInput("Gender");
                up.Nationality = GetInput("Nationality");
                up.Age = GetNumericInput("Age");
                up.BirthDate = GetInput("Birth Date");

                Console.WriteLine(" ");
                Console.WriteLine("----- Flight Details -----");
                up.Departure = GetInput("Departure City");
                up.Destination = GetInput("Destination City");
                up.Date = GetInput("Travel Dates");
                up.Type = GetInput("Flight Type [one-way or round-trip");

                Console.WriteLine(" ");
                Console.WriteLine("----- Contact Information ----");
                up.Contact = GetInput("Contact Number");
                up.Email = GetEmail();

                Console.WriteLine(" ");
                Console.WriteLine("1. Excess Baggage(200Php/kg)");
                Console.WriteLine("2. Prepaid Baggage(300Php/kg)");
            
                int choice = GetNumericInput("Choice");

                switch (choice)
                {
                    case 1:
                        up.BaggageType = "1";
                        break;

                    case 2:
                        up.BaggageType = "2";
                        break;

                    default:
                        Console.WriteLine("Invalid baggage type.");
                        return;
                }


                Console.Write("Baggage kg: ");
                up.BaggageKg = Convert.ToInt32(Console.ReadLine());

                service.Update(up);
                Console.WriteLine("Booking updated successfully!");
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }
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
                Console.WriteLine($"{item.PassportNumber} - {item.Name} - {item.Destination} - {item.Departure} - {item.TotalCost}");
            }
        }
        static string GetInput(string field)
        {
            string value;

            Regex regex = new Regex(@"^[a-zA-Z0-9 \-\,]+$"); 

            do
            {
                Console.Write($"{field}: ");
                value = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Input cannot be empty.");
                    continue;
                }

                if (!regex.IsMatch(value))
                {
                    Console.WriteLine("No special characters allowed. Try again.");
                    continue;
                }
                return value;

            } while (true);

           
        }

        static int GetNumericInput(string field)
        {
            string value;

            do
            {
                Console.Write($"{field}: ");
                value = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Input cannot be empty.");
                    continue;
                }

                if (!value.All(char.IsDigit))
                {
                    Console.WriteLine("Only numbers are allowed.");
                    value = null;
                }

            } while (value == null);

            return int.Parse(value);
        }

        static string GetEmail()
        {
            string value;
            Regex emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            do
            {
                Console.Write("Email: ");
                value = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Email cannot be empty.");
                    value = null;
                }
                else if (!emailRegex.IsMatch(value))
                {
                    Console.WriteLine("Invalid email format. Try again.");
                    value = null;
                }

            } while (value == null);

            return value;
        }
    }
}