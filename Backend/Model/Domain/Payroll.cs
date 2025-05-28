using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.Domain
{
    public class Payroll
    {
        public Guid Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public long GrossPay { get; set; }
        public long Deduction { get; set; }
        public long NetSalary { get; set; }
        public string? PaymentMode { get; set; } // storing pay method, upi,bank 
        public Guid EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

    }
}