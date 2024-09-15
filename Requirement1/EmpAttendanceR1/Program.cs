using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpAttendanceR1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeCRUD();
            ManagerCRUD();
            DepartmentCRUD();           
            Console.ReadLine();
        }

        public static void EmployeeCRUD()
        {
            GenericCRUD<Employee> empCRUD = new GenericCRUD<Employee>();

            //employee objects
            Employee e1 = new Employee("Suganya", "Grade 1", 2);
            Employee e2 = new Employee("Pravin", "Grade 2", 2);
            Employee e3 = new Employee("Manoj", "Grade 3", 1);
            Employee e4 = new Employee("Mani", "Grade 1", 1);

            //for create
            Employee e5 = new Employee("Suman", "Grade 4", 1);          

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
                Console.WriteLine($"{empread.Id} - {empread.Name} - {empread.Grade} - {empread.ModifiedBy}");
            }
            else
            {
                Console.WriteLine("No Match found for Employee");
            }

            //call update
            Console.WriteLine(" ");
            var empupdate = empCRUD.UpdateById(lsemp, t);
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

        public static void ManagerCRUD()
        {
            GenericCRUD<Manager> mngCRUD = new GenericCRUD<Manager>();
            List<Manager> lsmng = new List<Manager>();


            //manager objects
            Manager m1 = new Manager(1);            
            Manager m2 = new Manager(2);
            //for create
            Manager m3 = new Manager(3);

            lsmng.Add(m1);
            lsmng.Add(m2);

            //Manager CRUD Operations
            Console.WriteLine(" ");
            Console.WriteLine("Manager CRUD Operations");
            Console.WriteLine("----------------------------");

            //call create
            var mncreate = mngCRUD.Create(lsmng, m3);
            int t = m2.Id;
            if (mncreate != null)
            {
                Console.WriteLine("CREATE Manager List");
                foreach (var i in mncreate)
                {
                    Console.WriteLine($"ID :{i.Id} - DeptId: {i.DepartmentID} - {i.ModifiedBy}");
                }
            }

            //call read
            Console.WriteLine(" ");
            var read = mngCRUD.GetById(lsmng, t);
            if (read != null)
            {
                Console.WriteLine("READ Manager List");
                Console.WriteLine($"ID:{read.Id} -DeptId : {read.DepartmentID} - {read.ModifiedBy}");
            }
            else
            {
                Console.WriteLine("No Match found for Manager");
            }

            //call update
            Console.WriteLine(" ");
            var update = mngCRUD.UpdateById(lsmng, t);
            if (update != null)
            {
                Console.WriteLine("UPDATE Manager List");
                foreach (var i in update)
                {

                    Console.WriteLine($"ID:{i.Id}  - Dept Id :{i.DepartmentID}   - {i.ModifiedBy}");
                }
            }

            //call delete
            Console.WriteLine(" ");
            var delete = mngCRUD.DeleteById(lsmng, t);
            if (delete != null)
            {
                Console.WriteLine("DELETE Manager List");
                foreach (var i in delete)
                {
                    Console.WriteLine($"ID: {i.Id} - Dept Id :{i.DepartmentID} - {i.ModifiedBy}");
                }
            }

        }
        public static void DepartmentCRUD()
        {
            GenericCRUD<Department> deptCRUD = new GenericCRUD<Department>();
            List<Department> lsdept = new List<Department>();


            //department objects
            Department d1 = new Department("Information Technology");            
            Department d2 = new Department("Hardware");
            //create
            Department d3 = new Department("Marketing");

            lsdept.Add(d1); 
            lsdept.Add(d2);

            //Department CRUD Operations
            Console.WriteLine(" ");
            Console.WriteLine("Department CRUD Operations");
            Console.WriteLine("----------------------------");

            //call create
            var create = deptCRUD.Create(lsdept,d3);
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
                Console.WriteLine($"ID :{read.Id} - Dept Name :{read.DepartmentName} - {read.ModifiedBy}");
            }
            else
            {
                Console.WriteLine("No Match found for Manager");
            }

            //call update
            Console.WriteLine(" ");
            var update = deptCRUD.UpdateById(lsdept, t);
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
