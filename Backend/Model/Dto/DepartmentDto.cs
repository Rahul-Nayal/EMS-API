using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.Domain;

namespace Backend.Model.Dto
{
    public class DepartmentDto
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }
        public List<EmployeeDto> Employees { get; set; } 
        public List<JobRoleDto> JobRoles { get; set; }
    }
}