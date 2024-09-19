using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EmpAttendanceR1; 

namespace EmpAttendanceR1.VIEW
{
    public class ManagerView
    {
        public static void ManagerCRUD()
        {
            IGenericCRUD<Manager> mngCRUD = new GenericCRUD<Manager>();
            List<Manager> lsmng = new List<Manager>();

            //manager objects
            Manager m1 = new Manager();           
           
            List<Employee> lstemp1 = new List<Employee>
            {
                new Employee { Name = "Pravin", Grade = "Grade 2", ManagerID = 1 },
                new Employee { Name = "Suman", Grade = "Grade 4", ManagerID = 1 }

            };
            List<Departments> lstdept1 = new List<Departments>
            {
               new Departments { DepartmentName = "Information Technology" },
               new Departments { DepartmentName = "Human Resource" }

            };
            
            m1.Employees = lstemp1;
            m1.Department = lstdept1;
            
            Manager m2 = new Manager();

            List<Employee> lstemp2 = new List<Employee>
            {
               new Employee { Name = "Manoj", Grade = "Grade 3", ManagerID = 2},
               new Employee { Name = "Mani", Grade = "Grade 3", ManagerID = 2}
            };
            List<Departments> lstdept2 = new List<Departments>
            {
               new Departments { DepartmentName = "Information Technology" }              

            };

            m2.Employees = lstemp2;
            m2.Department = lstdept2;

            lsmng.Add(m1);
            //lsmng.Add(m2);

            //Manager CRUD Operations
            Console.WriteLine(" ");
            Console.WriteLine("Manager CRUD Operations");
            Console.WriteLine("----------------------------");

            //call create
            var mncreate = mngCRUD.Create(lsmng, m2);
            lsmng = mncreate.ToList();
            int t = m1.Id;
            if (mncreate != null)
            {
                Console.WriteLine("CREATE Manager List");
                foreach (var i in mncreate)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"For Manager Id:{i.Id}");
                    
                    foreach (var j in i.Employees)
                    {
                        Console.WriteLine($"Employees List :{j.Name}");
                    }
                    foreach (var j in i.Department)
                    {
                        Console.WriteLine($"Departments List :{j.DepartmentName}");
                    }                    
                }
            }

            //call read
            Console.WriteLine(" ");
            var read = mngCRUD.GetById(lsmng, t);
            if (read != null)
            {
                Console.WriteLine("READ Manager List");
                foreach (var i in read)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"For Manager Id:{i.Id}");
                   
                    foreach (var j in i.Employees)
                    {
                        Console.WriteLine($"Employees List :{j.Name}");
                    }
                    foreach (var j in i.Department)
                    {
                        Console.WriteLine($"Departments List :{j.DepartmentName}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No Match found for Manager");
            }

            //call update
            Console.WriteLine(" ");
            var update = mngCRUD.UpdateById(lsmng, m1);
            if (update != null)
            {
                Console.WriteLine("UPDATE Manager List");
                foreach (var i in update)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"For Manager Id:{i.Id}");                   

                    foreach (var j in i.Employees)
                        {
                            Console.WriteLine($"Employees List :{j.Name}");
                        }
                        foreach (var j in i.Department)
                        {
                            Console.WriteLine($"Departments List :{j.DepartmentName}");
                        }                    
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
                    Console.WriteLine("");
                    Console.WriteLine($"For Manager Id:{i.Id}");                   

                    foreach (var j in i.Employees)
                    {
                        Console.WriteLine($"Employees List :{j.Name}");
                    }
                    foreach (var j in i.Department)
                    {
                        Console.WriteLine($"Departments List :{j.DepartmentName}");
                    }
                }
            }

        }
    }
}
