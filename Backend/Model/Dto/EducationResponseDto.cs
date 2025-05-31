using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.Domain;

namespace Backend.Model.Dto
{
    public class EducationResponseDto
    {
        // public Guid EmployeeId { get; set; }
        public CourseType Course { get; set; }
        public string Title { get; set; }
        public decimal CGPA { get; set; }
    }
}