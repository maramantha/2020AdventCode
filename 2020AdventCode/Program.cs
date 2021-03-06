﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020AdventCode
{
    class Program
    {
        private static string Day1Challenge()
        {
            string userFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
            userFolder = userFolder + @"\Pictures\InputCode\Day1Input.txt";
            Day1Challenge D1 = new Day1Challenge(inputReader(userFolder));
            return D1.BalanceProduct.ToString();
        }
        private static string Day2Challenge()
        {
            string userFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
            userFolder = userFolder + @"\Pictures\InputCode\Day2Input.txt";
            Day2Challenge D2 = new Day2Challenge(inputReader(userFolder));
            return D2.validPasswordCount.ToString();
        }
        private static string Day3Challenge()
        {
            string userFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
            userFolder = userFolder + @"\Pictures\InputCode\Day3Input.txt";
            Day3Challenge D3 = new Day3Challenge(inputReader(userFolder));
            return D3.TreeEncounterCount.ToString();
        }
        private static string Day4Challenge()
        {
            string userFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
            userFolder = userFolder + @"\Pictures\InputCode\Day4Input.txt";
            Day4Challenge D4 = new Day4Challenge(inputReader(userFolder));
            return D4.validPassportCount.ToString();
        }
        private static string Day5Challenge()
        {
            string userFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
            userFolder = userFolder + @"\Pictures\InputCode\Day5Input.txt";
            Day5Challenge D5 = new Day5Challenge(inputReader(userFolder));
            return D5.yourSeatID.ToString();
        }
        private static string Day6Challenge()
        {
            string userFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
            userFolder = userFolder + @"\Pictures\InputCode\Day6Input.txt";
            Day6Challenge D6 = new Day6Challenge(inputReader(userFolder));
            return D6.sumYesAnswers.ToString();
        }
        private static string Day7Challenge(string targetBag)
        {
            string userFolder = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
            userFolder = userFolder + @"\Pictures\InputCode\Day7Input.txt";
            Day7Challenge D7 = new Day7Challenge(inputReader(userFolder),targetBag, 1);
            return D7.GetLogestedRoute().ToString();
        }
        private static string Day9Challenge()
        {
            string userFolder = @"C:\Users\natha\Source\Repos\maramantha\2020AdventCode\2020AdventCode\Resources\Day9Input.txt";
            Day9Challenge D9 = new Day9Challenge(inputReader(userFolder),25);
            return D9.MissingFactorOutput().ToString();
        }
        private static string Day10Challenge()
        {
            string userFolder = @"C:\Users\natha\Source\Repos\maramantha\2020AdventCode\2020AdventCode\Resources\Day10Input.txt";
            Day10Challenge D10 = new Day10Challenge(inputReader(userFolder));
            return D10.SomeValu().ToString();
        }
        private static string[] inputReader(string fileName)
        {
            string input;
            List<string> collInput = new List<string>();
            StreamReader dayInput = new StreamReader(fileName);
            while((input = dayInput.ReadLine() ) != null)
            {
                collInput.Add(input);
            }
            dayInput.Close();
            return collInput.ToArray<string>();
        }
        static void Main(string[] args)
        {
            string outputAnswer = "";
            //outputAnswer = Day1Challenge();
            //Console.WriteLine("Day 1 Answer: ");
            //Console.WriteLine("My Balance: " + outputAnswer);
            //Console.WriteLine("");
            //Console.WriteLine("Day 2 Answer: ");
            //outputAnswer = Day2Challenge();
            //Console.WriteLine("Number of Good Passwords: " + outputAnswer);
            //Console.WriteLine("");
            //Console.WriteLine("Day 3 Answer: ");
            //outputAnswer = Day3Challenge();
            //Console.WriteLine("Number of Trees hit: " + outputAnswer);
            //Console.WriteLine("");
            //Console.WriteLine("Day 4 Answer: ");
            //outputAnswer = Day4Challenge();
            //Console.WriteLine("Number of Valid Passports: " + outputAnswer);
            //Console.WriteLine("");
            //Console.WriteLine("Day 5 Answer: ");
            //outputAnswer = Day5Challenge();
            //Console.WriteLine("Your Seat ID: " + outputAnswer);
            //Console.WriteLine("");
            //Console.WriteLine("Day 6 Answer: ");
            //outputAnswer = Day6Challenge();
            //Console.WriteLine("Sum of Yes Answers: " + outputAnswer);
            //Console.WriteLine("");
            //Console.WriteLine("Day 7 Answer: ");
            //outputAnswer = Day7Challenge("shiny gold");
            //Console.WriteLine("Sum of bag steps to gold bag: " + outputAnswer);
            //Console.WriteLine("");
            //outputAnswer = Day9Challenge();
            //Console.WriteLine("Day 9 Challenge Answer: " + outputAnswer);
            //Console.WriteLine("");
            outputAnswer = Day10Challenge();
            Console.WriteLine("Day 10 Challenge Answer: " + outputAnswer);
            Console.WriteLine("");
         }
    }
}
