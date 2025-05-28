using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.Domain
{
    public class SalaryStructure : AuditableEntity
    {
        public Guid Id { get; set; }
        public long BasicPay { get; set; }
        public long HRA { get; set; }
        public long Bonus { get; set; }
        public long Deduction { get; set; }
        public long NetSalary { get; set; }

        public Guid EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        
    }
}