using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmpAttendanceR1
{
    public abstract class BaseEntity
    {


        public  int Id { get; }    
        public string ModifiedBy
        {
            get { return "job 1"; }           
        }
        public DateTime ModifiedDate
        {
            get { return DateTime.Now; }
        }       
        public BaseEntity()
        {
           Id = IDGenerator.GenerateId();          
        }

    }
    public class IDGenerator
    {
        private static int lastId = 0;
        public static int GenerateId()
        {
            return Interlocked.Increment(ref lastId);
        }
    }
}
