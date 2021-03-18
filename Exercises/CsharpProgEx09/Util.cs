using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CsharpProgEx09
{
    class Util
    {
        
        static Dictionary<string, string> User = new Dictionary<string, string>();

        public static void printUI()
        {
            
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1) Create a new User");
            Console.WriteLine("2) Authenticate an exisiting user");
            Console.WriteLine("3) Display all users");
            Console.WriteLine("4) Exit");
            Console.Write("Enter 1, 2, 3, or 4: ");
            string input = Console.ReadLine();
            
            

            if (input == "1")
            {
                Util.NewUser(User);
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                Console.Clear();
                Util.printUI();
            }
            else if (input == "2")
            {
                
                Util.AuthenticateUser(User);
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                Console.Clear();
                Util.printUI();
            }
            else if (input == "3")
            {
                Util.DisplayUser(User);
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                Console.Clear();
                Util.printUI();
            }
            else if (input == "4")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid response");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                Console.Clear();
                Util.printUI();
            }


        }

        private static void DisplayUser(Dictionary<string, string> u)
        {
            Console.WriteLine("Current Users");
            Console.WriteLine("-------------------------------------------------------------------");
            
            foreach (KeyValuePair<string, string> element in u)
            {
                string userName = element.Key;
                string hash = element.Value;
                Console.WriteLine($"UserName: {userName} Password: {hash}");
            }
        }

        private static void AuthenticateUser(Dictionary<string, string> u)
        {
            Console.WriteLine("Find a user");
            Console.Write("Enter User Name: ");
            string searchedUser = Console.ReadLine();
            Console.Write("Enter password: ");
            string value = Console.ReadLine();
            if (u[searchedUser] == getHash(value))
            {
                Console.WriteLine($"{searchedUser} is an active user");
            }
            else
                Console.WriteLine("Invalid");
           
        }

        public static Dictionary<string, string> NewUser(Dictionary<string, string> u)
        {
            
            Console.Write("Enter a UserName: ");
            string userName = Console.ReadLine();
            Console.Write("Enter a password: ");
            string hashedPassword = getHash(Console.ReadLine());
            if (!u.ContainsKey(userName))
            {
                u.Add(userName, hashedPassword);
            }
            else
            {
                Console.WriteLine("User name exists.  Try Again");
                NewUser(u);
            }    
            return u;
        }
        public static string getHash(string text)
        {
            using(var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
