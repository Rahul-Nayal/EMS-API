using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.Domain;

namespace Backend.Business
{
    public interface IEducationService
    {
        Task<List<Education>> GetAsync(Guid id);
        Task<Education> AddUpdateAsync(Guid id, Education education);
        Task<Education> DeleteAsync(Guid id);
    }
}