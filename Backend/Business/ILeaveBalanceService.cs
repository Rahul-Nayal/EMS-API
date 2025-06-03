using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.Domain;
using Backend.Model.Dto;

namespace Backend.Business
{
    public interface ILeaveBalanceService
    {
        Task<List<LeaveBalance>> GetAllAsync();
        Task<LeaveBalance> GetByIdAsync(Guid id);
        Task<LeaveBalanceResponseDto> AddAsync(LeaveBalanceResponseDto leaveBalanceResponseDto);
        Task<LeaveBalance> UpdateAsync(Guid id, LeaveBalance leaveBalance);
        Task<LeaveBalance> DeleteAsync(Guid id);
    }
}