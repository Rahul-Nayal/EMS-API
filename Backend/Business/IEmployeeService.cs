using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.Domain;
using Backend.Model.Dto;
using Microsoft.AspNetCore.Identity;

namespace Backend.Business
{
    public interface IEmployeeService
    {
        Task<List<EmployeeRequestDto>> GetAllAsync();
        Task<EmployeeRequestDto> GetByIdAsync(Guid id);
        Task<EmployeeResponseDto> AddAsync(EmployeeResponseDto employeeResponseDto);
        Task<Employee> UpdateAsync(Guid id, Employee employee);
        Task<Employee> DeleteAsync(Guid id); 
    }
}