using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Model.Domain;
using Backend.Model.Dto;
using Backend.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EMSDbContext eMSDbContext;
        private readonly UserManager<IdentityUser> userManager;
        public EmployeeService(EMSDbContext eMSDbContext, UserManager<IdentityUser> userManager)
        {
            this.eMSDbContext = eMSDbContext;
            this.userManager = userManager;
        }

        public Task<List<EmployeeRequestDto>> GetAllAsync()
        {
            var employee = eMSDbContext.Employees
                .Include(d => d.Department)
                .Include(j => j.JobRole)
                .Where(e => !e.IsDeleted)
                .Select(e => new EmployeeRequestDto
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
                    DepartmentId = e.DepartmentId,
                    DepartmentName = e.Department.DepartmentName,
                    JobRoleId = e.JobRoleId,
                    JobRoleName = e.JobRole.Title,
                }).ToListAsync();

            if (employee == null)
            {
                return null;
            }
            return employee;
        }

        public async Task<EmployeeRequestDto> GetByIdAsync(Guid id)
        {
            // var existingEmployee = await eMSDbContext.Employees.FindAsync(id);
            // if (existingEmployee == null)
            // {
            //     return null;
            // }
            var searchedEmployee = await  eMSDbContext.Employees
                                .Include(d => d.Department)
                                .Include(j => j.JobRole)
                                .Where(e => !e.IsDeleted)
                                .Where(e=> e.Id == id)
                                .Select(e => new EmployeeRequestDto
                                {

            // var searchedEmployee = new EmployeeRequestDto
            // {
                                    Id = id,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Gender = e.Gender,
                                    DOB = e.DOB,
                                    HireDate = e.HireDate,
                                    TerminationDate = e.TerminationDate , 
                                    Status = e.Status,
                                    DepartmentId = e.DepartmentId,
                                    DepartmentName = e.Department!=null ? e.Department.DepartmentName : null,
                                    JobRoleId = e.JobRoleId,
                                    JobRoleName =e.JobRole!=null ? e.JobRole.Title:null
                                // };
                                }).FirstOrDefaultAsync();
            // if (searchedEmployee == null)
            // {
            //     return null;
            // }
            return searchedEmployee;
        }

        public async Task<EmployeeResponseDto> AddAsync(EmployeeResponseDto employeeResponseDto)
        {
            var existingEmployee = await userManager.Users.FirstOrDefaultAsync(usr=> usr.UserName == employeeResponseDto.Username);
            if (existingEmployee != null)
            {
                return null;
            }
            var Id = Guid.NewGuid();
            var stringId = Id.ToString();
            var iUser = new IdentityUser
            {
                Id = stringId,
                UserName = employeeResponseDto.Username,
                Email = employeeResponseDto.Username,
            };
            var newIdentityResult = await userManager.CreateAsync(iUser, employeeResponseDto.Password);
            if (newIdentityResult.Succeeded)
            {
                if (employeeResponseDto.Roles != null && employeeResponseDto.Roles.Any())
                {
                    newIdentityResult = await userManager.AddToRolesAsync(iUser, employeeResponseDto.Roles);
                    if (newIdentityResult.Succeeded)
                    {
                        var newEmployee = new Employee()
                        {
                            Id = Id,
                            UserId = stringId,
                            FirstName = employeeResponseDto.FirstName,
                            LastName = employeeResponseDto.LastName,
                            Gender = employeeResponseDto.Gender,
                            DepartmentId = employeeResponseDto.DepartmentId,
                            JobRoleId = employeeResponseDto.JobRoleId,
                            FamilyDetail = null
                        };
                        await eMSDbContext.Employees.AddAsync(newEmployee);
                        await eMSDbContext.SaveChangesAsync();
                        return employeeResponseDto;
                    }
                }
            }
            return null;
        }

        public async Task<Employee> DeleteAsync(Guid id)
        {
            var existingEmployee = await eMSDbContext.Employees.FindAsync(id);
            if (existingEmployee != null)
            {
                eMSDbContext.Employees.Remove(existingEmployee);
                await eMSDbContext.SaveChangesAsync();
                return existingEmployee;
            }
            return null;
        }

        public async Task<Employee> UpdateAsync(Guid id, Employee employee)
        {
            var existingEmployee = await eMSDbContext.Employees.FindAsync(id);
            if (existingEmployee == null)
            {
                return null;
            }
            eMSDbContext.Employees.Update(employee);
            await eMSDbContext.SaveChangesAsync();
            return employee;
        }
    }
}