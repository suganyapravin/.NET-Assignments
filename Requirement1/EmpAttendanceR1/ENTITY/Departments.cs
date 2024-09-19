using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpAttendanceR1
{
    public class Departments : BaseEntity
    {
        public string DepartmentName { get; set; }
        public Departments() : base()
        {  
        }
    }
}
