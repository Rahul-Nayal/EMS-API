using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.Domain
{
    public class FamilyDetail
    {
        [Key, ForeignKey("EmployeeId")]
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public ICollection<FamilyMemberDetail> FamilyMemberDetails { get; set; } = new List<FamilyMemberDetail>();
    }
}