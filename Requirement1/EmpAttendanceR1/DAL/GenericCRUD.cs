using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmpAttendanceR1
{
    public class GenericCRUD<T> : IGenericCRUD<T> where T : BaseEntity 
    {
       
        //CREATE
        public IEnumerable<T> Create(IEnumerable<T> lstobj, T obj)
        {
            //pass the entity object and make an entry in db
            lstobj = lstobj.Append(obj);
            return lstobj;
        }
      
        //READ
        public IEnumerable<T> GetById(IEnumerable<T> lstobj,int id)
        {
            //pass id and retrieve the data pertaining to id
            return lstobj.Where(x => x.Id == id);
        }

        //UPDATE
        public IEnumerable<T> UpdateById(IEnumerable<T> lstobj, T obj)
        {
            //pass entity object and update the database 
            var rs = lstobj.Where(x => x.Id != obj.Id).AsEnumerable();
            var temp = lstobj.Where(x => x.Id == obj.Id);
            return rs.Append(obj);
           
        }

        //DELETE
        public IEnumerable<T> DeleteById(IEnumerable<T> lstobj,int id)
        {
            //pass id and delete the data pertaining to id
            var rs = lstobj.Where(x => x.Id != id).ToList();            
            return rs.AsEnumerable();
        }       

    }
}
