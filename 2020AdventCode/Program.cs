using System;
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
            string outputAnswer = Day1Challenge();
            Console.WriteLine("Day 1 Answer: ");
            Console.WriteLine("My Balance: " + outputAnswer);
            Console.WriteLine("");
            Console.WriteLine("Day 2 Answer: ");
            outputAnswer = Day2Challenge();
            Console.WriteLine("Number of Good Passwords: " + outputAnswer);
            Console.WriteLine("");
            Console.WriteLine("Day 3 Answer: ");
            outputAnswer = Day3Challenge();
            Console.WriteLine("Number of Trees hit: " + outputAnswer);
            Console.WriteLine("");
        }
    }
}
