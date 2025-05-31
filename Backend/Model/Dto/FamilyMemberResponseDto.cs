using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.Domain;

namespace Backend.Model.Dto
{
    public class FamilyMemberResponseDto
    {
        public Guid Id { get; set; }
        public RelationType Relation { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public Guid FamilyDetailId { get; set; }
        
    }
}