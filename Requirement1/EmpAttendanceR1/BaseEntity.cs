using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace EmpAttendanceR1
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }       
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public int GetId()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(5000);
            return randomNumber; 
        }
        public BaseEntity()
        {
            Id = GetId();
            ModifiedBy = "job";
            ModifiedDate = DateTime.Now;
        }
    }
}
