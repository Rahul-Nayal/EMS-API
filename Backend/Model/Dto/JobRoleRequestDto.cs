using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.Dto
{
    public class JobRoleRequestDto
    {
        public string Title { get; set; }
        public Guid DepartmentId { get; set; }

    }
}