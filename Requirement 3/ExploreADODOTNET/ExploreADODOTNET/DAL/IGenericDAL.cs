using ExploreADODOTNET.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreADODOTNET.DAL
{
    public interface IGenericDAL<T> where T : class
    {
        public bool Create(T obj);
        public bool Update(T obj);
        public bool DeleteById(int id);
        public DataTable GetAll();

    }
}
