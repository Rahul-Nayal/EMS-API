using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.Domain;
using Backend.Model.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Backend.Permission;
namespace Backend.Data
{
    public class EMSDbContext : IdentityDbContext<IdentityUser>
    {
        public EMSDbContext(DbContextOptions<EMSDbContext> options):base(options)
        {
        }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobRole> JobRoles { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<FamilyDetail> FamilyDetails { get; set; }
        public DbSet<FamilyMemberDetail> FamilyMemberDetails { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<SalaryStructure> SalaryStructures { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<LeaveBalance> LeaveBalances { get; set; }

        // seedind data
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var AdminRoleId = "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63";
            var EmployeeRoleId = "7f99b3c4-6cf1-44b7-b62b-e7411b52a89d";
            var Roles = new List<IdentityRole>
            {
                new IdentityRole{
                    Id = AdminRoleId,
                    ConcurrencyStamp = AdminRoleId,
                    Name ="Admin",
                    NormalizedName = "Admin"
                },
                new IdentityRole{
                    Id = EmployeeRoleId,
                    ConcurrencyStamp = EmployeeRoleId,
                    Name = "Employee",
                    NormalizedName = "Employee"
                }
            };

            builder.Entity<IdentityRole>().HasData(Roles);


            var roleClaims = new List<IdentityRoleClaim<string>>();

            var adminPermission = new[]{
                Permission.Permission.Employee.View,
                Permission.Permission.Employee.Create,
                Permission.Permission.Employee.Update,
                Permission.Permission.Employee.Delete,
                Permission.Permission.Employee.Attendance.View,
                Permission.Permission.Employee.Attendance.Create,
                Permission.Permission.Employee.Attendance.Update,
                Permission.Permission.Employee.Attendance.Delete,
                Permission.Permission.Employee.Certificate.View,
                Permission.Permission.Employee.Certificate.Create,
                Permission.Permission.Employee.Certificate.Update,
                Permission.Permission.Employee.Certificate.Delete,
                Permission.Permission.Employee.Education.View,
                Permission.Permission.Employee.Education.Create,
                Permission.Permission.Employee.Education.Update,
                Permission.Permission.Employee.Education.Delete,
                Permission.Permission.Employee.WorkExperience.View,
                Permission.Permission.Employee.WorkExperience.Create,
                Permission.Permission.Employee.WorkExperience.Update,
                Permission.Permission.Employee.WorkExperience.Delete,
                Permission.Permission.Employee.ContactDetails.View,
                Permission.Permission.Employee.ContactDetails.Create,
                Permission.Permission.Employee.ContactDetails.Update,
                Permission.Permission.Employee.ContactDetails.Delete,
                Permission.Permission.Employee.FamilyDetail.View,
                Permission.Permission.Employee.FamilyDetail.Create,
                Permission.Permission.Employee.FamilyDetail.Update,
                Permission.Permission.Employee.FamilyDetail.Delete,

                Permission.Permission.Department.View,
                Permission.Permission.Department.Create,
                Permission.Permission.Department.Update,
                Permission.Permission.Department.Delete,

                Permission.Permission.JobRole.View,
                Permission.Permission.JobRole.Create,
                Permission.Permission.JobRole.Update,
                Permission.Permission.JobRole.Delete,

                Permission.Permission.Asset.View,
                Permission.Permission.Asset.Create,
                Permission.Permission.Asset.Update,
                Permission.Permission.Asset.Delete,

                Permission.Permission.AssetType.View,
                Permission.Permission.AssetType.Create,
                Permission.Permission.AssetType.Update,
                Permission.Permission.AssetType.Delete,

                Permission.Permission.LeaveType.View,
                Permission.Permission.LeaveType.Create,
                Permission.Permission.LeaveType.Update,
                Permission.Permission.LeaveType.Delete,

                Permission.Permission.Leave.View,
                Permission.Permission.Leave.Create,
                Permission.Permission.Leave.Update,
                Permission.Permission.Leave.Delete,

                Permission.Permission.LeaveBalance.View,
                Permission.Permission.LeaveBalance.Create,
                Permission.Permission.LeaveBalance.Update,
                Permission.Permission.LeaveBalance.Delete,

                Permission.Permission.SalaryStructure.View,
                Permission.Permission.SalaryStructure.Create,
                Permission.Permission.SalaryStructure.Update,
                Permission.Permission.SalaryStructure.Delete,

                Permission.Permission.Payroll.View,
                Permission.Permission.Payroll.Create,
                Permission.Permission.Payroll.Update,
                Permission.Permission.Payroll.Delete,

                Permission.Permission.Project.View,
                Permission.Permission.Project.Create,
                Permission.Permission.Project.Update,
                Permission.Permission.Project.Delete,

                Permission.Permission.EmployeeProject.View,
                Permission.Permission.EmployeeProject.Assign,
                Permission.Permission.EmployeeProject.Unassign,
                Permission.Permission.EmployeeProject.UpdateRole

            };
            int claimId = 1;
            foreach (var permission in adminPermission)
            {
                roleClaims.Add(new IdentityRoleClaim<string>
                {
                    Id = claimId++,
                    RoleId = AdminRoleId,
                    ClaimType = "Permission",
                    ClaimValue = permission
                });
            }


            var employeePermission = new[]{
                Permission.Permission.Employee.View,
                Permission.Permission.Employee.Attendance.View,
                Permission.Permission.Employee.Attendance.Create,
                Permission.Permission.Employee.Attendance.Update,
                Permission.Permission.Employee.Certificate.View,
                Permission.Permission.Employee.Education.View,
                Permission.Permission.Employee.WorkExperience.View,
                Permission.Permission.Employee.ContactDetails.View,
                Permission.Permission.Employee.FamilyDetail.View,
                Permission.Permission.Leave.View,
                Permission.Permission.LeaveBalance.View,
                Permission.Permission.Payroll.View,
                Permission.Permission.Asset.View,
            };

            foreach (var permission in employeePermission)
            {
                roleClaims.Add(new IdentityRoleClaim<string>
                {
                    Id = claimId++,
                    RoleId = EmployeeRoleId,
                    ClaimType = "Permission",
                    ClaimValue = permission
                });
            }

            builder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
            // 1:1 familyDetail-Employee
            builder.Entity<FamilyDetail>()
                .HasKey(f => f.EmployeeId);

            builder.Entity<FamilyDetail>()
                .HasOne(f => f.Employee)
                .WithOne(e => e.FamilyDetail)
                .HasForeignKey<FamilyDetail>(fr => fr.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1:Many FamilyDetail - FamilyMembers

            builder.Entity<FamilyMemberDetail>()
                .HasOne(f => f.FamilyDetail)
                .WithMany(e => e.FamilyMemberDetails)
                .HasForeignKey(fr => fr.FamilyDetailId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        
    }
}