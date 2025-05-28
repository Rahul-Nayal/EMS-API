using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Model.Domain;
using Backend.Model.Dto;
using Backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business
{
    public class DepartmentService : IDepartmentService
    {
        private readonly EMSDbContext eMSDbContext;
        public DepartmentService(EMSDbContext eMSDbContext)
        {
            this.eMSDbContext = eMSDbContext;
        }

        public async Task<List<JobRole>> GetAllJobRoleAsync(Guid id)
        {
            var existingDepartment = await eMSDbContext.Departments.FindAsync(id);
            if (existingDepartment != null)
            {
                var jobRoles = await eMSDbContext.JobRoles.Where(jb => jb.DepartmentId == existingDepartment.DepartmentId).ToListAsync();

                return jobRoles;
            }
            return null;
        }
        public async Task<List<DepartmentDto>> GetAllAsync()
        {
            var departments = await eMSDbContext.Departments
                .Include(d => d.Employees)
                .Include(d => d.JobRoles)
                .Where(d => !d.IsDeleted)
                .Select(d => new DepartmentDto
                {
                    Id = d.DepartmentId,
                    DepartmentName = d.DepartmentName,
                    Employees = d.Employees.Select(e => new EmployeeDto
                    {
                        Id = e.Id,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Gender = e.Gender,
                        ProfileImageUrl = e.ProfileImageUrl,
                        DOB = e.DOB,
                        HireDate = e.HireDate,
                        TerminationDate = e.TerminationDate,
                        Status = e.Status,
                        UserId = e.UserId,
                        JobRoleId = e.JobRoleId,
                        DepartmentId = e.DepartmentId

                    }).ToList(),
                    JobRoles =  d.JobRoles.Select(j => new JobRoleDto
            {
                JobRoleId = j.JobRoleId,
                Title = j.Title
            }).ToList()
                }).ToListAsync();
            return departments;
        }

        public async Task<Department?> GetByIdAsync(Guid id)
        {
            var existingDepartment = await eMSDbContext.Departments.FindAsync(id);
            if (existingDepartment == null)
            {
                return null;
            }
            return existingDepartment;
        }

        public async Task<Department> AddAsync(Department department)
        {
            var newDepartment = await eMSDbContext.Departments.FirstOrDefaultAsync(dep => dep.DepartmentName == department.DepartmentName);
            if (newDepartment == null)
            {
                await eMSDbContext.Departments.AddAsync(department);
                await eMSDbContext.SaveChangesAsync();
                return department;
            }
            return null;
        }

        public async Task<Department> UpdateAsync(Guid id, Department department)
        {
            var existingDepartment = await eMSDbContext.Departments.FindAsync(id);
            if (existingDepartment != null)
            {
                eMSDbContext.Entry(existingDepartment).CurrentValues.SetValues(department);
                // eMSDbContext.Departments.Update(department);
                await eMSDbContext.SaveChangesAsync();
                return existingDepartment;
            }

            return null;
        }

        public async Task<Department> DeleteAsync(Guid id)
        {
            var existingDepartment = await eMSDbContext.Departments.FindAsync(id);
            if (existingDepartment != null)
            {
                eMSDbContext.Departments.Remove(existingDepartment);
                await eMSDbContext.SaveChangesAsync();
                return existingDepartment;
            }

            return null;
        }
    }
}