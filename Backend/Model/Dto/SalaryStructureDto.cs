using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.Domain;

namespace Backend.Model.Dto
{
    public class SalaryStructureDto
    {
        public long BasicPay { get; set; }
        public long HRA { get; set; }
        public long Bonus { get; set; }
        public long Deduction { get; set; }
        public long NetSalary { get; set; }
        public Guid EmployeeId { get; set; }
        
    }
}