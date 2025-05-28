using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.Domain
{
    public class ContactDetails: AuditableEntity
    {
        [Key,ForeignKey("Employee")]
        public Guid EmployeeId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        
        // emergency contact
        public string EmergencyContactNumber { get; set; }
        public Employee Employee { get; set; }
        
    }
}