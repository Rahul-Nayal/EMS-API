using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.Domain;

namespace Backend.Model.Dto
{
    public class LeaveBalanceRequestDto
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
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