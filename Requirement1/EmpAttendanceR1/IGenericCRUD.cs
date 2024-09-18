using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpAttendanceR1
{
    public interface IGenericCRUD<T> where T : class
    {
         List<T> Create(List<T> lstobj, T obj);
         T GetById(List<T> lstobj, int id);
         List<T> UpdateById(List<T> lstobj, int id);
         List<T> DeleteById(List<T> lstobj, int id);
    }
}
