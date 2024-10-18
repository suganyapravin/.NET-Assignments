using ExploreADODOTNET.DAL;
using ExploreADODOTNET.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ExploreADODOTNET.BL
{
    
    public class ManageSubject
    {
  
        IGenericDAL<Subject> subjectCRUD = new SubjectDAL<Subject>();

        public void SubjectMenu()
        {
            ManageStudent  student = new ManageStudent();
            int number;            

            student.ListStudents();
            Console.WriteLine("");
            Console.WriteLine("Enter StudentId to add Subjects");
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out Globals.StudentId))
                {
                    AddSubject(Globals.StudentId);
                    break;                   
                }
                else 
                {
                    Console.WriteLine("Enter valid StudentId");
                }
            }          
           
        }
        public void AddSubject(int id)
        {
            while (true)
            {
                Subject sub = new Subject();
                Console.WriteLine("Enter Subject Name");
                sub.Name = Console.ReadLine();
               

                bool result = subjectCRUD.Create(sub);
                if (result == true)
                {
                    Console.WriteLine("Subject Added Successfully");
                    Console.WriteLine("Do u want to add more Y/N");
                    string a = Console.ReadLine();
                    if (a == "y" || a =="Y")
                    {
                        continue;
                    }else
                    {
                        ListSubjects(id);
                        break;
                    }
                   
                }
                else
                {
                    Console.WriteLine("Error Occured . Try Again");
                }
            }
        }


        public void ListSubjects(int id )
        {
            List<Subject> lstSub = new List<Subject>();

            lstSub = subjectCRUD.GetAll();

            Console.WriteLine("Id - Name");
            foreach (var sub in lstSub)
            {
                Console.WriteLine($"{sub.SubjectId} - {sub.Name}");
            }           
        }
    }
}
