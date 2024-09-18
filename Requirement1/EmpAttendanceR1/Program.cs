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
            EmployeePresentation.EmployeeCRUD();
            EmployeePresentation.ManagerCRUD();
            EmployeePresentation.DepartmentCRUD();           
            Console.ReadLine();
        }

     
    }
}
