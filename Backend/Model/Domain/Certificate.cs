using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.Domain
{
    public class Certificate
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string Title { get; set; }
        public string Issue { get; set; }
        public DateTime DateIssued { get; set; }
        public Employee Employee { get; set; }
    }
}