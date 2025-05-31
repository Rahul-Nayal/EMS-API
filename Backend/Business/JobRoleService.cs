using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Model.Domain;
using Backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business
{
    public class JobRoleService : IJobRoleService
    {
        // GenericService<JobRole>,
        // private readonly IGenericRepository<JobRole> jobRole; 
        private readonly EMSDbContext eMSDbContext;



        // public JobRoleService(IGenericRepository<JobRole> jobRole)
        // {
        //     this.jobRole = jobRole;
        // }

        public JobRoleService(EMSDbContext eMSDbContext)
        {
            this.eMSDbContext = eMSDbContext;
        }
        public async Task<JobRole> DeleteAsync(Guid id)
        {
            var exisitingRole = await eMSDbContext.JobRoles.FindAsync(id);
            if (exisitingRole == null)
            {
                return null;
            }
            eMSDbContext.JobRoles.Remove(exisitingRole);
            await eMSDbContext.SaveChangesAsync(); 
            return exisitingRole;
        }

        public async Task<IEnumerable<JobRole>> GetAllAsync()
        {
            var allJobDetails = await eMSDbContext.JobRoles.ToListAsync();
            if (allJobDetails == null)
            {
                return [];
            }
            return allJobDetails;
        }
        public async Task<JobRole> GetByIdAsync(Guid id)
        {
            var checkedRole = await eMSDbContext.JobRoles.FindAsync(id);
            if (checkedRole == null)
            {
                return null;
            }
            return checkedRole;
        }
        public async Task<JobRole> AddAsync(JobRole jbRole)
        {
            var newJobRole = await eMSDbContext.JobRoles.FindAsync(jbRole.JobRoleId);
            if (newJobRole == null)
            {
                await eMSDbContext.JobRoles.AddAsync(jbRole);
                await eMSDbContext.SaveChangesAsync();
                return jbRole;
            }
            return null;
        }

        public async Task<JobRole> UpdateAsync(Guid id, JobRole jbRole)
        {
            var exisitingRole = await eMSDbContext.JobRoles.FindAsync(id);
            if (exisitingRole == null)
            {
                return null;
            }
            eMSDbContext.JobRoles.Update(exisitingRole);
            await eMSDbContext.SaveChangesAsync();
            return exisitingRole;
        }        
    }
}