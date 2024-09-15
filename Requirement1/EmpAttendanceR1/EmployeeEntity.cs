using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmpAttendanceR1
{
   
    public class Employee : BaseEntity
    {
         
        public string Name { get; set; }
        public string Grade { get; set; }
        public int ManagerID { get; set; }

        public Employee(string name , string grade, int mngid) :base() 
        {
         
            Name = name;
            Grade = grade;
            ManagerID = mngid;
        }       

    }
    public class Manager : BaseEntity
    {
     public int DepartmentID { get; set; }

        public Manager(int departmentID) : base() 
        {
            DepartmentID = departmentID;
        }   
    }
    public class Department : BaseEntity
    {
      public string DepartmentName { get; set; }
        public Department(string departmentName) : base()
        {
            DepartmentName = departmentName;
        }

    }
}
