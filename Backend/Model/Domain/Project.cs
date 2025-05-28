using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.Domain
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ProjectImageUrl { get; set; }
        [ForeignKey("ProjectImageUrl")]
        public Image ProjectImage { get; set; }
        public ProjectStatus Status { get; set; }
        // one project can assigned to many employeeprojects
        public ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
    }

    public enum ProjectStatus
    {
        Completed,
        Active,
        OnHold
    }
}