using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.Domain
{
    public class AuditableEntity
    {
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }

        public DateTime? DeletedAt { get; set; } = null;
        public string? DeletedBy { get; set; }

        public bool IsDeleted { get; set;}
    }
}