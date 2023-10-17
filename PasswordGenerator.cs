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

   private static string GenerateRandomPassword(int length, bool includeUppercase, bool includeLowercase, bool includeNumbers, bool includeSymbols, string excludedSymbols, char requiredSymbol)
        {
            string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
            string numberChars = "0123456789";
            string symbolChars = "!@#$%^&*()_+";

            string allChars = "";

            if (includeUppercase)
                allChars += uppercaseChars;
            if (includeLowercase)
                allChars += lowercaseChars;
            if (includeNumbers)
                allChars += numberChars;
            if (includeSymbols)
                allChars += symbolChars;

            // Remove excluded symbols from the list of symbols to use.
            foreach (char excludedSymbol in excludedSymbols)
            {
                allChars = allChars.Replace(excludedSymbol.ToString(), "");
            }

            // Ensure the required symbol is in the list of symbols to use.
            if (requiredSymbol != '\0' && !allChars.Contains(requiredSymbol.ToString()))
            {
                Console.WriteLine($"\nRequired symbol '{requiredSymbol}' is not in the list of allowed symbols.");
                return "";
            }

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] randomBytes = new byte[length];
                rng.GetBytes(randomBytes);

                StringBuilder password = new StringBuilder(length);

                for (int i = 0; i < length; i++)
                {
                    int index = randomBytes[i] % allChars.Length;
                    password.Append(allChars[index]);
                }

                // If a required symbol is specified, replace one of the characters with it.
                if (requiredSymbol != '\0')
                {
                    int position = randomBytes[randomBytes.Length - 1] % length;
                    password[position] = requiredSymbol;
                }

                return password.ToString();
            }
        }
    }
}
