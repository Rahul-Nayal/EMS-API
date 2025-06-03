using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.Domain;

namespace Backend.Model.Dto
{
    public class LeaveTypeRequestDto:AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxDaysAllowed { get; set; }
    }
}