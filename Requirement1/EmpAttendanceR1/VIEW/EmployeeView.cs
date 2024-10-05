using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpAttendanceR1
{
    internal class EmployeeView
    {
        public static void EmployeeCRUD()
        {
            IGenericCRUD<Employee> empCRUD = new GenericCRUD<Employee>();

            //employee objects
            Employee e1 = new Employee { Name = "Suganya", Grade = "Grade 1", ManagerID = 1 };         
            Employee e2 = new Employee { Name = "Pravin", Grade = "Grade 2", ManagerID = 1 };
            Employee e3 = new Employee { Name = "Manoj", Grade = "Grade 3", ManagerID = 2};
            Employee e4 = new Employee { Name = "Mani", Grade = "Grade 3", ManagerID = 2};

            //for create
            Employee e5 = new Employee { Name = "Suman", Grade = "Grade 4", ManagerID = 1 }; 

            List<Employee> lsemp = new List<Employee>();
            lsemp.Add(e1);
            lsemp.Add(e2);
            lsemp.Add(e3);
            lsemp.Add(e4);

            //Employee CRUD Operations
            Console.WriteLine("Employee CRUD Operations");
            Console.WriteLine("----------------------------");

            //call create
            var empcreate = empCRUD.Create(lsemp, e5);
            lsemp = empcreate.ToList();
            int t = e4.Id;
            if (empcreate != null)
            {
                Console.WriteLine("CREATE Employee List");
                foreach (var i in empcreate)
                {
                    Console.WriteLine($"{i.Id} - {i.Name} - {i.Grade} - {i.ModifiedBy}");
                }
            }

            //call read
            Console.WriteLine(" ");
            var empread = empCRUD.GetById(lsemp, t);
            if (empread != null)
            {
                Console.WriteLine("READ Employee List");
                foreach (var i in empread)
                {
                    Console.WriteLine($"{i.Id} - {i.Name} - {i.Grade} - {i.ModifiedBy}");
                }
               
            }
            else
            {
                Console.WriteLine("No Match found for Employee");
            }

            //call update
            Console.WriteLine(" ");
            var empupdate = empCRUD.UpdateById(lsemp, e1);
            if (empupdate != null)
            {
                Console.WriteLine("UPDATE Employee List");
                foreach (var i in empupdate)
                {

                    Console.WriteLine($"{i.Id} - {i.Name} - {i.Grade}   - {i.ModifiedBy}");
                }
            }

            //call delete
            Console.WriteLine(" ");
            var empdelete = empCRUD.DeleteById(lsemp, t);
            if (empdelete != null)
            {
                Console.WriteLine("DELETE Employee List");
                foreach (var i in empdelete)
                {
                    Console.WriteLine($"{i.Id} - {i.Name} - {i.Grade} - {i.ModifiedBy}");
                }
            }
        }      
        
    }
}
