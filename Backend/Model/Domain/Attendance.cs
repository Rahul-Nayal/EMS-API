using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.Domain
{
    public class Attendance
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }

        public AttendanceStatus Status { get; set; }
        public Guid EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        public TimeSpan? InTime { get; set; }
        public TimeSpan? OutTime { get; set; }

    }

    public enum AttendanceStatus {
        Present,
        Absent,
        Leave
    }
}