using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.Domain;

namespace Backend.Model.Dto
{
    public class LeaveResponseDto
    {
        [Required(ErrorMessage ="Employee Id is required")]
        public Guid EmployeeId { get; set; }
        [Required(ErrorMessage = "Leave Type Id is required")]
        public Guid LeaveTypeId { get; set; }
        public LeaveStatus Status { get; set; }
        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage ="End Date is required")]
        public DateTime EndDate { get; set; }
    }
}