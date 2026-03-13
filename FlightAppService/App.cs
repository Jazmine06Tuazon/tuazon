
using FlightModels;
namespace FlightAppService
{
    public class App
    {
        public static bool IsValidFullName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            foreach (char c in name)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsInputEmpty(string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        public static bool IsNumericOnly(string pass)
        {
            if (string.IsNullOrWhiteSpace(pass))
                return false;

            foreach (char c in pass)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }


        public class FlightService
        {
            private int excessPrice = 250;
            private int prepaidPrice = 340;
            private int standardSeat = 150;
            private int premiumSeat = 250;
            public int HandleBaggage()
            {
                int bagTotal = 0;
                int kg = 0;

                while (true)
                {
                    Console.WriteLine("Baggage Allowance");
                    Console.WriteLine("1. Excess Baggage: ₱250 per kg \n2. Prepaid Baggage: ₱340 per kg");
                    Console.Write("Choose: ");
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out int baggage) || (baggage != 1 && baggage != 2))
                    {
                        Console.WriteLine("Invalid choice. Enter 1 or 2.");
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

                    if (baggage == 1)
                        bagTotal += excessPrice * kg;
                    else if (baggage == 2)
                        bagTotal += prepaidPrice * kg;

                    break;
                }

                return bagTotal;
            }

            public int HandleSeat()
            {
                while (true)
                {
                    Console.WriteLine("\nSeat Selection");
                    Console.WriteLine("1. Standard seats: Php150 - Php280\n2. Premium seats: Php250 - Php1,099");
                    Console.Write("Choose: ");
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out int seat) || (seat != 1 && seat != 2))
                    {
                        Console.WriteLine("Invalid choice. Enter 1 or 2.");
                        continue;
                    }

                    if (seat == 1)
                        return standardSeat;
                    else
                        return premiumSeat;
                }
            }

            public int CalculateTotal()
            {
                int bagCost = HandleBaggage();
                int seatCost = HandleSeat();
                int total = bagCost + seatCost;
                return total;
            }
        }
    }
}