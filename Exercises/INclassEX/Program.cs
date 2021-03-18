using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INclassEX
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Class List Exercise(Live)");
            while (true)
            {
                Console.WriteLine("Enter 'Q' to quit.");
                string quit = Console.ReadLine();
                if (quit == "Q" || quit == "q")
                {
                    Environment.Exit(0);
                }
                else
                    Console.WriteLine("----------------------------------------------------------------------------------------------");
                    Shuffle();
            }
        }

        private static void Shuffle()
        {
            Console.WriteLine("This is method shuffle");
            List<string> Letters = new List<string>();
            foreach (string letter in new string[6] { "alpha", "bravo", "charlie", "delta", "echo", "foxtrot" })
            {
                Letters.Add(letter);
            }
            foreach (string letter in Letters)
            {
                Console.WriteLine(letter);
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            List<string> NewList = new List<string>();
            Random randomLetter = new Random();
            while (Letters.Count > 0)
            {
                int chad = randomLetter.Next(Letters.Count);
                NewList.Add(Letters[chad]);
                Letters.RemoveAt(chad);
            }
            foreach (string s in NewList)
            {
                Console.WriteLine(s);
            }
        }
    }
}
