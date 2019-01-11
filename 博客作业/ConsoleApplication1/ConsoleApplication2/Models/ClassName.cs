using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.Models
{
    public class ClassName
    {
        public int ClassNameId { get; set; }
        public string Name { get; set; }

        public virtual List<Student> Student { get; set; }
    }
}
