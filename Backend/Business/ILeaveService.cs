using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.Domain;
using Backend.Model.Dto;

namespace Backend.Business
{
    public interface ILeaveService
    {
        Task<List<LeaveRequestDto>> GetAllAsync();
        Task<List<Leave>> GetByIdAsync(Guid id);
        Task<Leave> AddAsync(Guid id, Leave leave);
        Task<Leave> UpdateAsync(Guid id, Leave leave);
        Task<Leave> DeleteAsync(Guid id);
    }
}