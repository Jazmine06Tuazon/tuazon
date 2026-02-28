using System.ComponentModel.Design;

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
            Console.Write("Full Name: ");
            string fname = Console.ReadLine();

            Console.Write("Date of birth: ");
            string birth = Console.ReadLine();

            Console.Write("Nationality: ");
            string nationality = Console.ReadLine();

            Console.Write("Passport Number: ");
            string passport = Console.ReadLine();
            Console.WriteLine(" ");

            Console.WriteLine("FLIGHT DETAILS");
            Console.WriteLine(" ");

            Console.Write("Departure City: ");
            string city1 = Console.ReadLine();

            Console.Write("Destination City: ");
            string city2 = Console.ReadLine();

            Console.Write("Travel Dates: ");
            string travel = Console.ReadLine();

            Console.Write("Flight type (one-way or round-trip): ");
            string flight = Console.ReadLine();
            Console.WriteLine(" ");

            Console.WriteLine("CONTACT INFORMATION");
            Console.WriteLine(" ");

            Console.Write("Email Address: ");
            string email = Console.ReadLine();

            Console.Write("Phone Number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(" ");

            Console.WriteLine("ADDITIONAL SERVICES");
            Console.WriteLine(" ");

            Console.WriteLine("Baggage Allowance");
            Console.WriteLine("Domestic flights:\n 1. Excess Baggage: ₱250-₱1,200 per kg \n 2. Prepaid Baggage ₱340-₱1,599");
            Console.WriteLine("Choose: ");
            int baggage = Convert.ToInt16(Console.ReadLine());
            
            switch(baggage)
            {
                case 1:
                    Console.Write("Enter kg: ");
                    kg = Convert.ToInt16(Console.ReadLine());
                    int p = x * kg;
                    bagTotal  += p;
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
            
            Console.WriteLine(" ");
            Console.WriteLine("Payment Method (cash or online payment): ");
            string payment = Console.ReadLine();
            Console.WriteLine(" ");

            Console.WriteLine("------ E-receipt -----");
            Console.WriteLine("Customer's Name: " + fname);
            Console.WriteLine("Customer's Passport: " + passport);
            Console.WriteLine("Customer's Departure City: " + city1);
            Console.WriteLine("Customer's Destination City: " + city2);
            Console.WriteLine("Travel Dates: " + travel);
            Console.WriteLine("Customer's Flight Type: " + flight);
            Console.WriteLine("Customer's Payment Method: " + payment);
            Console.WriteLine("Total Expenses for baggage and seat: "+ total);
            Console.WriteLine(" ");
            Console.WriteLine("Process Completed. Thank you!");
        }
    }
}
