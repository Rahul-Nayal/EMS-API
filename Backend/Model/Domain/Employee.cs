using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Backend.Model.Domain
{
    public class Employee : AuditableEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Guid? ProfileImageUrl { get; set; }
        [ForeignKey("ProfileImageUrl")]
        public Image? ProfileImage { get; set; }
        public DateTime DOB { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public bool Status { get; set; } = true;



        //  Foreign Key to ApplicationUser
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser IdentityUser { get; set; }

        public ContactDetails ContactDetails { get; set; }
        public Guid JobRoleId { get; set; }    
        [ForeignKey("JobRoleId")]
        public JobRole JobRole { get; set; }

        // foreign key 
        public Guid DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        // public Guid SalaryStructureId { get; set; }
        // [ForeignKey("SalaryStructureId")]
        // public SalaryStructure SalaryStructure { get; set; }
        public FamilyDetail FamilyDetail { get; set; }


        // one to many relationship
        public ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
        public ICollection<Asset> Assets { get; set; } = new List<Asset>();
        public ICollection<Leave> Leave { get; set; } = new List<Leave>();
        public ICollection<Attendance> Attendance { get; set; } = new List<Attendance>();
        public ICollection<Payroll> Payroll { get; set; } = new List<Payroll>();
        public ICollection<Education> Educations { get; set; } = new List<Education>();
        public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
    }
}