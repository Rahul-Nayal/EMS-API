using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Exceptions;
using Backend.Model.Domain;
using Backend.Model.Dto;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business
{
    public class LeaveService : ILeaveService
    {

        private readonly EMSDbContext eMSDbContext;
        private readonly ILogger<LeaveService> logger;
        public LeaveService(EMSDbContext eMSDbContext, ILogger<LeaveService> logger)
        {
            this.eMSDbContext = eMSDbContext;
            this.logger = logger;
        }

        public async Task<List<LeaveRequestDto>> GetAllAsync()
        {
            // var leaveList = await eMSDbContext.Leaves.ToListAsync();
            // return leaveList;
            var leaveList = await eMSDbContext.Leaves
                            .Include(e => e.Employee)
                                .ThenInclude(d=> d.Department)
                            .Include(l => l.LeaveType)
                            .Select(l => new LeaveRequestDto
                            {
                                Id = l.Id,
                                EmployeeId = l.EmployeeId,
                                EmployeeName = l.Employee.FirstName + " " + l.Employee.LastName,
                                DepartmentName = l.Employee.Department.DepartmentName,
                                LeaveType = l.LeaveType.Name,
                                Status = l.Status,
                                StartDate = l.StartDate,
                                EndDate = l.EndDate,
                                RequestedOn = l.RequestedOn,
                                ApprovalDate = l.ApprovalDate,
                                ApprovedBy = l.ApprovedBy,
                                NumberOfDays = l.EndDate.Day - l.StartDate.Day
                            }).ToListAsync();
            return leaveList;
        }

        public async Task<List<Leave>> GetByIdAsync(Guid id)
        {
            var employeeLeave = await eMSDbContext.Leaves.Where(e => e.EmployeeId == id).ToListAsync();
            if (employeeLeave == null)
            {
                return null;
            }
            return employeeLeave;
        }

        public async Task<Leave> AddAsync(Guid id, Leave leave)
        {
            var leaveType = await eMSDbContext.LeaveTypes.FindAsync(leave.LeaveTypeId);
            if (leaveType == null)
            {
                logger.LogWarning("Invalid LeaveType Id: {leaveTypeId}", leave.LeaveTypeId);
                throw new ArgumentException("Invalid LeaveType Id.");
            }
            var duration = leave.EndDate - leave.StartDate;
            if (duration.Days+1 >leaveType.MaxDaysAllowed) // end and start date are encluded using +1
            {
                throw new BusinessException("Leave duration is more than max allowed days");
            }    
            leave.EmployeeId = id;
            await eMSDbContext.Leaves.AddAsync(leave);
            await eMSDbContext.SaveChangesAsync();

            var existedLeaveBalance = await eMSDbContext.LeaveBalances.FindAsync(id);
            return leave;
        }

        public async Task<Leave> UpdateAsync(Guid id, Leave leave)
        {
            var existedLeaveType = await eMSDbContext.Leaves.FindAsync(id);
            if (existedLeaveType == null)
            {
                logger.LogWarning("Invalid Leave for LeaveId : {id}", id);
                return null;
            }
            existedLeaveType.LeaveTypeId = leave.LeaveTypeId;
            existedLeaveType.StartDate = leave.StartDate;
            existedLeaveType.EndDate = leave.EndDate;
            eMSDbContext.Leaves.Update(existedLeaveType);
            await eMSDbContext.SaveChangesAsync();
            return leave;
        }
        
        public async Task<Leave> DeleteAsync(Guid id)
        {
            var existingEmployeeLeave = await eMSDbContext.Leaves.FindAsync(id);
            if (existingEmployeeLeave == null)
            {
                logger.LogWarning("Invalid Leave Id : {id}", id);
                return null;
            }
            eMSDbContext.Leaves.Remove(existingEmployeeLeave);
            await eMSDbContext.SaveChangesAsync();
            return existingEmployeeLeave;
        }
    }
}