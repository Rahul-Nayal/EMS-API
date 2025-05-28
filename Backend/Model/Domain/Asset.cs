using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.Domain
{
    public class Asset
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public Guid AssetId { get; set; }
        [ForeignKey("AssetId")]
        public AssetType AssetType { get; set; }
        public string SerialNumber { get; set; }
        public DateTime AssignedDate { get; set; }
        public AssignedStatus Status { get; set; }
    }

    public enum AssignedStatus
    {
        Assigned,
        Returned
    }
}