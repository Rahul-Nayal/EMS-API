using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.Domain;

namespace Backend.Business
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveType>> GetAllAsync();
        Task<LeaveType> AddAsync(LeaveType leaveType);
        Task<LeaveType> UpdateAsync(Guid id, LeaveType leaveType);
        Task<LeaveType> DeleteAsync(Guid id);
    }
}