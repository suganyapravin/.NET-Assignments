using EmpAttendanceR1.VIEW;
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
            EmployeeView.EmployeeCRUD();
            ManagerView.ManagerCRUD();
            DepartmentView.DepartmentCRUD();
            DepartmentView_Linkedlist.DepartmentCRUD();
            Console.ReadLine();
        }
     
    }
}
