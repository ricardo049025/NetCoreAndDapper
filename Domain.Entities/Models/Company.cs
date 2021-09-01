using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public class Company
    {
        [Description("Ignore")]
        public int Id { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public bool Status { set; get; }
        
        [Description("Ignore")]
        public virtual List<Employee> Employees { set; get; } = new List<Employee>();
    }
}
