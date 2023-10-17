using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CipherShield_Beta0._2
{
    public class PasswordGenerator
    {
        public static void GenerateCustomizedPassword()
        {

        }

        private static char ReadRequiredSymbol()
        {
            char symbol;
            while (true)
            {
                Console.Write("Enter the required symbol: ");
                if (char.TryParse(Console.ReadLine(), out symbol))
                {
                    return symbol;
                }
                Console.WriteLine("Invalid input. Please enter a single character.");
            }
        }

    }
}
