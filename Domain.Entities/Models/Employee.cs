using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public class Employee
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public DateTime birthday { set; get; }
        public bool Status { set; get; }
        public int CompanyId { set; get; }
    }

}
