using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.Domain
{
    public class JobRole : AuditableEntity
    {
        public Guid JobRoleId { get; set; }
        public string Title { get; set; }

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }

        // one job role can assigned to many employees
        ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}