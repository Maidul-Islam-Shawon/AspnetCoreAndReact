using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiApp.Models
{
    public class Department
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
