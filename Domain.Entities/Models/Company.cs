using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public class Company
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public bool Status { set; get; }
        public List<Employee> Employees { set; get; } = new List<Employee>();
    }
}
