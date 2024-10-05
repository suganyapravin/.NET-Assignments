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

         public Employee() : base()
        {
           
        }

    }
   
   
}
