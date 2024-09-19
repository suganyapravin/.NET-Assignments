using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpAttendanceR1.VIEW
{
    public class DepartmentView_Linkedlist
    {
        public static void DepartmentCRUD()
        {
            IGenericCRUD<Departments> deptCRUD = new GenericCRUD<Departments>();
            LinkedList<Departments> lsdept = new LinkedList<Departments>();


            //department objects
            Departments d1 = new Departments { DepartmentName = "Information Technology" };
            Departments d2 = new Departments { DepartmentName = "Human Resource" };
            //create
            Departments d3 = new Departments { DepartmentName = "Marketing" };

            lsdept.AddFirst(d1);
            lsdept.AddLast(d2);

            //Department CRUD Operations
            Console.WriteLine(" ");
            Console.WriteLine("Department CRUD Operations");
            Console.WriteLine("----------------------------");

            //call create
            var create = deptCRUD.Create(lsdept, d3);
            lsdept = new LinkedList<Departments>(create);

            int t = d2.Id;
            if (create != null)
            {
                Console.WriteLine("CREATE Department List");
                foreach (var i in create)
                {
                    Console.WriteLine($"ID :{i.Id} - Dept Name : {i.DepartmentName} - {i.ModifiedBy}");
                }
            }

            //call read
            Console.WriteLine(" ");
            var read = deptCRUD.GetById(lsdept, t);
            if (read != null)
            {
                Console.WriteLine("READ Department List");
                foreach (var i in read)
                {
                    Console.WriteLine($"ID :{i.Id} - Dept Name : {i.DepartmentName} - {i.ModifiedBy}");
                }

            }
            else
            {
                Console.WriteLine("No Match found for Manager");
            }

            //call update
            Console.WriteLine(" ");
            var update = deptCRUD.UpdateById(lsdept, d1);
            if (update != null)
            {
                Console.WriteLine("UPDATE Department List");
                foreach (var i in update)
                {

                    Console.WriteLine($"ID :{i.Id}  - Dept Name :{i.DepartmentName}   - {i.ModifiedBy}");
                }
            }

            //call delete
            Console.WriteLine(" ");
            var delete = deptCRUD.DeleteById(lsdept, t);
            if (delete != null)
            {
                Console.WriteLine("DELETE Department List");
                foreach (var i in delete)
                {
                    Console.WriteLine($"ID : {i.Id}  - Dept Name : {i.DepartmentName} - {i.ModifiedBy}");
                }
            }

        }
    }
}
