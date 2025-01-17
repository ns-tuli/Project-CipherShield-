﻿using CipherShield_Beta0._2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CipherShield_Beta
{
    public interface IPasswordToolbox
    {
        public static void PasswordToolbox()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Password Toolbox");
                Console.WriteLine("----------------");
                Console.WriteLine("");
                ColorConsole.Write("[ 1 ]", ConsoleColor.Blue);
                Console.WriteLine(" Password Generator");
                ColorConsole.Write("[ 2 ]", ConsoleColor.Blue);
                Console.WriteLine(" Password Strength-Checker");
                ColorConsole.Write("[ 3 ]", ConsoleColor.Blue);
                Console.WriteLine(" Back to Main Menu");
                Console.WriteLine("");
                ColorConsole.Write("Select an option: ", ConsoleColor.White);
                string choice = Console.ReadLine();


                switch (choice)
                {
                    case "1":
                        PasswordGenerator.GenerateCustomizedPassword();
                        break;
                    case "2":
                        StrengthChecker.PasswordStrengthReport();
                        break;
                    case "3":
                        Console.Clear();
                        return; // Return to the main menu.
                    default:
                        ColorConsole.WriteError("Invalid option. Please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

    }
}

