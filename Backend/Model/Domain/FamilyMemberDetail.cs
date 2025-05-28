using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.Domain
{
    public class FamilyMemberDetail
    {
        public Guid Id { get; set; }
        public RelationType Relation { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public Guid FamilyDetailId { get; set; }
        public FamilyDetail FamilyDetail { get; set; }

    }

    public enum RelationType
    {
        Father,
        Mother,
        Sister,
        Brother
    }
}