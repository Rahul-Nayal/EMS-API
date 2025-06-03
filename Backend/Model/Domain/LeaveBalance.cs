using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.Domain
{
    public class LeaveBalance
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public int PreviousBalance { get; set; }
        public int CurrentBalance { get; set; }
        public int TotalBalance { get; set; }
        public int UsedLeave { get; set; }
        public int AcceptedLeave { get; set; }
        public int RejectedLeave { get; set; }
        public int ExpiredLeave { get; set; }
        public int CarryOverBalance { get; set; }
    }
}