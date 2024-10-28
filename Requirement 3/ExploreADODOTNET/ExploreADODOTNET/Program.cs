using ExploreADODOTNET.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreADODOTNET
{
    public class Program
    {
       
        static void Main(string[] args)
        {
            ManageStudent manageStudent = new ManageStudent();
            ManageGrade managegrade = new ManageGrade();
            ManageSubject managesubject = new ManageSubject();

            int number;
            
            while (true)
            {
                Console.WriteLine("Select from below ::");
                Console.WriteLine("1. Student Info");
                Console.WriteLine("2.Grade Info");
                Console.WriteLine("3.Subject Info");

                string input = Console.ReadLine();
                if (int.TryParse(input, out number))
                {
                    switch (number)
                    {
                        case 1:
                            manageStudent.StudentMenu();
                            break;
                        case 2:
                            managegrade.GradeMenu();
                            break;
                        case 3:
                            managesubject.SubjectMenu();
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

        }             

    }
    static class Globals
    {
        public static int StudentId;
    }
}