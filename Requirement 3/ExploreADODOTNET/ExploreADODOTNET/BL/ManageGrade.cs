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
    public class ManageGrade
    {

        IGenericDAL<Grade> gradeCRUD = new GradeDAL<Grade>();
        public void GradeMenu()
        {
            int number;
            bool counter = true;
            Console.WriteLine("Welcome to Grade Page");
            Console.WriteLine("Please enter options from menu::");
            Console.WriteLine("1. List Grade");
            Console.WriteLine("2. Add Grade");
            Console.WriteLine("3. Update Grade");
            Console.WriteLine("4. Delete Grade");
            Console.WriteLine("5. Back to Main Menu");

            while (counter)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out number))
                {
                    switch (number)
                    {
                        case 1:
                            ListGrades();
                            break;
                        case 2:
                            AddGrade();
                            break;
                        case 3:
                            UpdateGrade();
                            break;
                        case 4:
                            DeleteGrade();
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


        public void AddGrade()
        {
            while (true)
            {
                Grade grade = new Grade();
                Console.WriteLine("Enter Grade Name");
                grade.GradeName = Console.ReadLine();
               
                bool result = gradeCRUD.Create(grade);
                if (result == true)
                {
                    Console.WriteLine("Grade Added Successfully");
                    ListGrades();
                    break;

                }
                else
                {
                    Console.WriteLine("Error Occured . Try Again");
                }
            }
        }


        public void ListGrades()
        {
            List<Grade> lstgrade = new List<Grade>();

            lstgrade = gradeCRUD.GetAll();

            Console.WriteLine("Id - Grade Name");
            foreach (var grade in lstgrade)
            {
                Console.WriteLine($"{grade.GradeId} - {grade.GradeName}");
            }

            // DataTable data = gradeCRUD.GetAll();

            //  Console.WriteLine("GradeId - GradeName");
            //   foreach (DataRow row in data.Rows)
            //   {
            //     Console.WriteLine($"{row[0]} - {row[1]}");
            //  }

        }

        public void DeleteGrade()
        {
            while (true)
            {
                Console.WriteLine("Enter Grade Id to delete");
                int id = Convert.ToInt16(Console.ReadLine());
                bool result = gradeCRUD.DeleteById(id);
                if (result == true)
                {
                    Console.WriteLine("Grade Deleted Successfully");
                    ListGrades();
                    break;

                }
                else
                {
                    Console.WriteLine("Error Occured . Try Again");
                }
            }
        }

        public void UpdateGrade()
        {
            while (true)
            {
                Grade grade = new Grade();
                Console.WriteLine("Enter Grade Id to update");
                grade.GradeId = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Enter Grade Name to update");
                grade.GradeName = Console.ReadLine();
             
                bool result = gradeCRUD.Update(grade);
                if (result == true)
                {
                    Console.WriteLine("Student Updated Successfully");
                    ListGrades();
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
