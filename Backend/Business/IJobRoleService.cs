using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.Domain;

namespace Backend.Business
{
    public interface IJobRoleService
    {
        Task<IEnumerable<JobRole>> GetAllAsync();
        Task<JobRole> GetByIdAsync(Guid id);
        Task<JobRole> AddAsync(JobRole jobRole);
        Task<JobRole> UpdateAsync(Guid id,JobRole jobRole);
        Task<JobRole> DeleteAsync(Guid id);
    }
}