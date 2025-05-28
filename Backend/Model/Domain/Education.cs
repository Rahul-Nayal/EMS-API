using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.Domain
{
    public class Education
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public CourseType Course { get; set; }
        public string Title { get; set; }
        public long CGPA { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
    public enum CourseType
    {
        Bachelor,
        Master,
        Certificates,
        Experience
    }
}