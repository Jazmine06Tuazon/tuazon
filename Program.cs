namespace prog
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
            Console.WriteLine("Domestic flights:\n Excess Baggage: ₱250-₱1,200 per kg \n Prepaid Baggage ₱340-₱1,599");
            Console.WriteLine(" ");

            Console.WriteLine("Seat Selection");
            Console.WriteLine("Standard seats: ₱150 -₱280(domestic) \n Premium seats: ₱250 -₱1, 099(domestic)");
            Console.WriteLine(" ");

            Console.WriteLine("Travel Insurance");

            Console.WriteLine(" ");
            Console.WriteLine("Domestic Flights: \n One - way base fare: ₱88 -₱1, 427.57 \n Round - trip: ₱2, 668.73 \n International Flights: \n One - way base fare: ₱588 -₱1, 299 \n Round - trip: ₱2, 668.73 \\n Promo Fares: \\n Piso Fare: ₱1 base fare(limited seats) \n P10 Seat Sale: ₱10 one - way base fare");

            Console.WriteLine(" ");
            Console.WriteLine("Payment Method (cash or online payment): ");
            string payment = Console.ReadLine();
            Console.WriteLine(" ");
            Console.WriteLine("Process Completed. Thank you!");
        }
    }
}
