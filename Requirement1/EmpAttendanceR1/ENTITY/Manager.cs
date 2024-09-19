using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpAttendanceR1;

namespace EmpAttendanceR1
{
    public class Manager : BaseEntity
    {
        public List<Employee> Employees { get; set; }
        public List<Departments> Department { get; set; }

        public Manager() :base()
        {
            Employees = new List<Employee>();
            Department = new List<Departments>(); 
        }
    }
}
