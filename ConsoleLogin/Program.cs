using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLogin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userName = "";
            string password = "";
            FileManipulators fm = new FileManipulators();
            List<string> lines = new List<string>();
            string dbName = "UserDatabase.csv";
            Dictionary<string, string[]> UserDB = new Dictionary<string, string[]>();

            Console.Write("Username: ");
            userName = Console.ReadLine();
            Console.Write("Password: ");
            password = Console.ReadLine();

            lines = fm.FileRead(dbName);

            foreach(string line in lines)
            {
                string[] temp = line.Split(',');
                UserDB[temp[0]] = new string[] { temp[1], temp[2] };
            }

            if (UserDB.ContainsKey(userName))
            {
                string[] temp = UserDB[userName];
                if (password == temp[0])
                {
                    Console.WriteLine("Login Successful!");
                    Console.WriteLine($"Welcome {temp[1]}");

                }
                else
                {
                    Console.WriteLine("UserName/Password does not match");
                }
            }
            else
            {
                Console.WriteLine("UserName/Password does not match");
            }

            Console.ReadKey();

        }
    }
}
