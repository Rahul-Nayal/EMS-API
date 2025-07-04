using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.Dto
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Guid? ProfileImageUrl { get; set; }
        public DateTime DOB { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public bool Status { get; set; } = true;
        public string UserId { get; set; }
        public Guid JobRoleId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid FamilyDetail { get; set; }
    }
}