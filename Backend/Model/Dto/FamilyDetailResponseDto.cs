using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.Domain;

namespace Backend.Model.Dto
{
    public class FamilyDetailResponseDto
    {
        // public Guid EmployeeId { get; set; }
        // public List<FamilyMemberResponseDto> FamilyMembers { get; set; }
        public FamilyMemberResponseDto FamilyMembers { get; set; }
    }
}