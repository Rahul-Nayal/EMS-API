using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business
{
    public class LeaveTypeService : ILeaveTypeService
    {
        private readonly EMSDbContext eMSDbContext;
        public LeaveTypeService(EMSDbContext eMSDbContext)
        {
            this.eMSDbContext = eMSDbContext;
        }

        public async Task<List<LeaveType>> GetAllAsync()
        {
            var leaveTypeList = await eMSDbContext.LeaveTypes.ToListAsync();
            if (leaveTypeList != null)
            {
                return leaveTypeList;
            }
            return null;
        }

        public async Task<LeaveType> AddAsync(LeaveType leaveType)
        {
            var existedLeaveType = await eMSDbContext.LeaveTypes.FirstOrDefaultAsync(l => l.Name == leaveType.Name);
            if (existedLeaveType != null)
            {
                return null;
            }

            await eMSDbContext.LeaveTypes.AddAsync(leaveType);
            await eMSDbContext.SaveChangesAsync();
            return leaveType;
        }

        public async Task<LeaveType> UpdateAsync(Guid id, LeaveType leaveType)
        {
            var existedLeaveType = await eMSDbContext.LeaveTypes.FindAsync(id);
            if (existedLeaveType == null)
            {
                return null;
            }
            // var newLeaveType = await eMSDbContext.LeaveTypes.FirstOrDefaultAsync(l => l.Name == leaveType.Name);
            existedLeaveType.Description = leaveType.Description;
            existedLeaveType.MaxDaysAllowed = leaveType.MaxDaysAllowed;

            eMSDbContext.LeaveTypes.Update(existedLeaveType);
            await eMSDbContext.SaveChangesAsync();
            return leaveType;
        }

        public async Task<LeaveType> DeleteAsync(Guid id)
        {
            var checkedLeaveType = await eMSDbContext.LeaveTypes.FindAsync(id);
            if (checkedLeaveType != null)
            {
                eMSDbContext.LeaveTypes.Remove(checkedLeaveType);
                await eMSDbContext.SaveChangesAsync();
                return checkedLeaveType;
            }
            return null;
        }
    }
}