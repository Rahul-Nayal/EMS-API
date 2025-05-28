using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.Domain;

namespace Backend.Business
{
    public interface IContactDetails
    {
        // Task<List<ContactDetails>> GetAllAsync();
        Task<ContactDetails?> GetAsync(Guid id);
        // Task<ContactDetails> AddAsync(Guid id, ContactDetails contactDetails);
        Task<ContactDetails> UpdateAsync(Guid id, ContactDetails contactDetails);
        Task<ContactDetails> DeleteAsync(Guid id);
    }
}