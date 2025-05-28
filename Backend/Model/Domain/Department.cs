using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.Domain
{
    public class Department : AuditableEntity
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        // one department has many employees
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();

        // one department has many job roles
        public ICollection<JobRole> JobRoles { get; set; } = new List<JobRole>();

    }
}