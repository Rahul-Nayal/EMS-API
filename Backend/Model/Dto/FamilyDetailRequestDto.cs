using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.Dto
{
    public class FamilyDetailRequestDto
    {
        public Guid EmployeeId { get; set; }
        public List<FamilyMemberRequestDto> FamilyMembers { get; set; }
    }
}