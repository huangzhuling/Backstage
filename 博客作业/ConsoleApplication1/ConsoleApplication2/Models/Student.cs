using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string sex { get; set; }
        public int ClassId { get; set; }
        public virtual ClassName ClassName { get; set; }
    }
}
