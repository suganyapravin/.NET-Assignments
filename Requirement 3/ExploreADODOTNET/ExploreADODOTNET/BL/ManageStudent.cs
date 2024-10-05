using ExploreADODOTNET.DAL;
using ExploreADODOTNET.Entity;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExploreADODOTNET.BL
{
    public class ManageStudent
    {

        IGenericDAL<Student> stuCRUD = new StudentDAL<Student>();
        public void StudentMenu()
        {
            int number;
            bool counter = true;
            Console.WriteLine("Welcome to Student Page");
            Console.WriteLine("Please enter options from menu::");
            Console.WriteLine("1. List Student");
            Console.WriteLine("2. Add Student");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Back to Main Menu");

            while (counter)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out number))
                {
                    switch (number)
                    {
                        case 1:
                            ListStudents();
                            break;
                        case 2:
                            AddStudent();
                            break;
                        case 3:
                            UpdateStudent();
                            break;
                        case 4:
                            DeleteStudent();
                            break;
                        case 5:
                            counter = false;
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


        public void AddStudent()
        {
            while (true)
            {
                Student student = new Student();
                Console.WriteLine("Enter Student Name");
                student.StudentName = Console.ReadLine();
                Console.WriteLine("Enter Grade");
                student.Grade = Console.ReadLine();

                bool result = stuCRUD.Create(student);
                if (result == true)
                {
                    Console.WriteLine("Student Added Successfully");
                    ListStudents();
                    break;

                }
                else
                {
                    Console.WriteLine("Error Occured . Try Again");
                }
            }
        }


        public void ListStudents()
        {
            DataTable data = stuCRUD.GetAll();

            Console.WriteLine("Id - Name - Grade");
            foreach (DataRow row in data.Rows)
            {
               Console.WriteLine($"{row[0]} - {row[1]} - {row[2]}");
            }
        }

        public void DeleteStudent()
        {
            while (true)
            {
                Console.WriteLine("Enter Student Id to delete");
                int id = Convert.ToInt16(Console.ReadLine());
                bool result = stuCRUD.DeleteById(id);
                if (result == true)
                {
                    Console.WriteLine("Student Deleted Successfully");
                    ListStudents();
                    break;

                }
                else
                {
                    Console.WriteLine("Error Occured . Try Again");
                }
            }
        }

        public void UpdateStudent()
        {
            while (true)
            {
                Student student = new Student();
                Console.WriteLine("Enter Student Id to update");
                student.StudentId = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Enter Student Name to update");
                student.StudentName = Console.ReadLine();
                Console.WriteLine("Enter Grade to update ");
                student.Grade = Console.ReadLine();

                bool result = stuCRUD.Update(student);
                if (result == true)
                {
                    Console.WriteLine("Student Updated Successfully");
                    ListStudents();
                    break;

                }
                else
                {
                    Console.WriteLine("Error Occured . Try Again");
                }
            }
        }

    }
}
