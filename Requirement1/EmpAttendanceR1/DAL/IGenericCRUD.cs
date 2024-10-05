using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpAttendanceR1
{
    public interface IGenericCRUD<T> where T : BaseEntity
    {
         IEnumerable<T> Create(IEnumerable<T> lstobj, T obj);
         IEnumerable<T> GetById(IEnumerable<T> lstobj, int id);
         IEnumerable<T> UpdateById(IEnumerable<T> lstobj, T obj);
         IEnumerable<T> DeleteById(IEnumerable<T> lstobj, int id);
    }
}
