
using FlightModels;
using System.IO.Pipes;
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
            
            return !string.IsNullOrWhiteSpace(input);
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
            public int standardSeat = 150;
            public int premiumSeat = 250;
            public int HandleBaggage(int baggage, int kg)
            {
                int bagTotal = 0;

                if (kg < 0)
                    throw new ArgumentException("Invalid kg");

                if (baggage == 1)
                    bagTotal += excessPrice * kg;
                else if (baggage == 2)
                    bagTotal += prepaidPrice * kg;
                else
                    throw new ArgumentException("Invalid baggage type");

                int x = bagTotal;
                return bagTotal;
            }
        

        public int HandleSeat(int seat)
        {
                if (seat == 1)
                    return standardSeat;
                else if (seat == 2)
                    return premiumSeat;
                else
                    throw new ArgumentException("Invalid seat type");
        }

        public int CalculateTotal(int baggage, int kg, int seat)
            {
                int bagCost = HandleBaggage(baggage, kg);
                int seatCost = HandleSeat(seat);
                int total = bagCost + seatCost;
                return total;
            }  
       } 
    }
}