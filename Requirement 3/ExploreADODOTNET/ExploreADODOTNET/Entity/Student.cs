using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreADODOTNET.Entity
{
    public class Student
    {
            public int StudentId {  get; set; }
            public string StudentName { get; set; }
            public string Grade{ get; set; }    
    }
}
