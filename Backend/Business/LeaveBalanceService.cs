using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Model.Domain;
using Backend.Model.Dto;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business
{
    public class LeaveBalanceService : ILeaveBalanceService
    {
        private readonly EMSDbContext eMSDbContext;

        public LeaveBalanceService(EMSDbContext eMSDbContext)
        {
            this.eMSDbContext = eMSDbContext;

        }

        public async Task<List<LeaveBalance>> GetAllAsync()
        {
            return await eMSDbContext.LeaveBalances.ToListAsync();
        }

        public async Task<LeaveBalance> GetByIdAsync(Guid id)
        {
            var existedEmployeeBalance = await eMSDbContext.LeaveBalances.FindAsync(id);
            if (existedEmployeeBalance == null)
            {
                return null;
            }

            return existedEmployeeBalance;
        }

        public async Task<LeaveBalanceResponseDto> AddAsync(LeaveBalanceResponseDto leaveBalanceResponseDto)
        {
            var existedEmployeeBalance = await eMSDbContext.LeaveBalances.FirstOrDefaultAsync(e => e.EmployeeId == leaveBalanceResponseDto.EmployeeId);
            if (existedEmployeeBalance != null)
            {
                return null;
            }

            var newLeaveBalanceDetail = new LeaveBalance
            {
                Id = Guid.NewGuid(),
                EmployeeId = leaveBalanceResponseDto.EmployeeId,
                PreviousBalance = leaveBalanceResponseDto.PreviousBalance,
                CurrentBalance = leaveBalanceResponseDto.CurrentBalance,
                TotalBalance = leaveBalanceResponseDto.PreviousBalance + leaveBalanceResponseDto.CurrentBalance,
                AcceptedLeave = 0,
                ExpiredLeave = 0,
                UsedLeave = 0,
                CarryOverBalance = 0
            };
            await eMSDbContext.LeaveBalances.AddAsync(newLeaveBalanceDetail);
            await eMSDbContext.SaveChangesAsync();
            return leaveBalanceResponseDto;
        }

        public async Task<LeaveBalance> UpdateAsync(Guid id, LeaveBalance leaveBalance)
        {
            var existedEmployeeBalance = await eMSDbContext.LeaveBalances.FindAsync(id);
            if (existedEmployeeBalance == null)
            {
                return null;
            }

            existedEmployeeBalance.AcceptedLeave = leaveBalance.AcceptedLeave;
            existedEmployeeBalance.CurrentBalance = leaveBalance.CurrentBalance;
            existedEmployeeBalance.CarryOverBalance = leaveBalance.CarryOverBalance;
            existedEmployeeBalance.ExpiredLeave = leaveBalance.ExpiredLeave;
            existedEmployeeBalance.PreviousBalance = leaveBalance.PreviousBalance;
            existedEmployeeBalance.RejectedLeave = leaveBalance.RejectedLeave;
            existedEmployeeBalance.TotalBalance = leaveBalance.PreviousBalance + leaveBalance.CurrentBalance;
            existedEmployeeBalance.UsedLeave = leaveBalance.AcceptedLeave + leaveBalance.ExpiredLeave;

            eMSDbContext.LeaveBalances.Update(existedEmployeeBalance);
            await eMSDbContext.SaveChangesAsync();
            return leaveBalance;
        }

        public async Task<LeaveBalance> DeleteAsync(Guid id)
        {
            var existedEmployeeBalance = await eMSDbContext.LeaveBalances.FindAsync(id);
            if (existedEmployeeBalance == null)
            {
                return null;
            }

            eMSDbContext.LeaveBalances.Remove(existedEmployeeBalance);
            await eMSDbContext.SaveChangesAsync();
            return existedEmployeeBalance;
        }
    }
}