using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.Domain;

namespace Backend.Model.Dto
{
    public class LeaveRequestDto
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public string LeaveType { get; set; }
        public LeaveStatus Status { get; set; }
        // [Required]
        public DateTime StartDate { get; set; }
        // [Required]
        public DateTime EndDate { get; set; }
        public DateTime RequestedOn { get; set; }
        public int NumberOfDays { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string ApprovedBy { get; set; }
    }
}