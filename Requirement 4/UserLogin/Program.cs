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
                string input2 = Console.ReadLine();

                bool res = manageUser.AuthenticateUser(input1, input2);

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