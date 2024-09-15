using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace EmpAttendanceR1
{
    public class GenericCRUD<T> where T : BaseEntity
    {
       
        //CREATE
        public List<T> Create(List<T> lstobj, T obj)
        {
            //pass the entity object and make an entry in db
            lstobj.Add(obj);
            return lstobj;
        }
        
        //READ
        public T GetById(List<T> lstobj,int id)
        {
            //pass id and retrieve the data pertaining to id
            return lstobj.Find(x => x.Id == id);

        }

        //UPDATE
        public List<T> UpdateById(List<T> lstobj,int id)
        {
            //pass entity object and update the database 
           var rs = lstobj.Find(x => x.Id == id);
           lstobj.Remove(rs);
           rs.ModifiedBy = "Some other job";           
           lstobj.Add(rs);           
           return lstobj;
        }

        //DELETE
        public List<T> DeleteById(List<T> lstobj,int id)
        {
            //pass id and delete the data pertaining to id
            var rs = lstobj.Find(x => x.Id == id);
            lstobj.Remove(rs);
            return lstobj;
        }

    }
}
