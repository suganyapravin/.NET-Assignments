using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UserLogin.BL;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UserLogin
{
    public class Program
    {
        static void Main(string[] args)
        {
            int number;
            ManageUser manageUser = new ManageUser();

            while (true)
            {
                Console.WriteLine("Enter UserName/Email to Continue : ");
                string input1 = Console.ReadLine();
                Console.WriteLine("Enter Password :");
                string input2 = "";               
                while (true)
                {
                    var key = System.Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Backspace && input2.Length > 0)
                    {
                        Console.Write("\b \b");
                        input2 = input2[0..^1];
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    else {

                        input2 += key.KeyChar;
                        Console.Write("*");
                    }
                }
                bool res = manageUser.AuthenticateUser(input1, input2);
                Console.WriteLine("");
                if (res)

                {
                    Console.WriteLine("Welcome to User Management Page!!!!");
                    Console.WriteLine("1. Add User");
                    Console.WriteLine("2. Delete User");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out number))
                    {
                        switch (number)
                        {
                            case 1:
                                manageUser.AddUser();
                                break;
                            case 2:
                                manageUser.RemoveUser();
                                break;
                            default:
                                Console.WriteLine("Invalid Entry");
                                Console.ReadLine();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number:");
                    }

                }

                else { Console.WriteLine("Username or Password entered is wrong.. Try again.."); }
            }
        }


      
    }
}