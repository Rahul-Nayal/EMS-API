using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Model.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business
{
    public class ContactDetailsService : IContactDetails
    {
        private readonly EMSDbContext eMSDbContext;
        public ContactDetailsService(EMSDbContext eMSDbContext)
        {
            this.eMSDbContext = eMSDbContext;
        }

        public async Task<ContactDetails> GetAsync(Guid id)
        {
            var employeeExist = await eMSDbContext.Employees.AnyAsync(e => e.Id == id);
            if (employeeExist == null)
            {
                Console.WriteLine("line executed");
                return null;
            }
            var contactDetails = await eMSDbContext.ContactDetails.FirstOrDefaultAsync(cd => cd.EmployeeId == id);
            if (contactDetails != null)
            {
                return contactDetails;
            }
            Console.WriteLine("Second line executed");
            return null;
        }

        public async Task<ContactDetails> UpdateAsync(Guid id, ContactDetails contactDetails)
        {
            var employeeExists = await eMSDbContext.Employees.AnyAsync(e => e.Id == id);
            if (!employeeExists)
            {
                Console.WriteLine("line executed");
                return null;
            }
            var exisitingContactDetails = await eMSDbContext.ContactDetails.FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (exisitingContactDetails == null)
            {
                contactDetails.EmployeeId = id;
                await eMSDbContext.ContactDetails.AddAsync(contactDetails);
            }
            else
            {
                eMSDbContext.ContactDetails.Update(exisitingContactDetails);
            }

            await eMSDbContext.SaveChangesAsync();
            return contactDetails;
        }

        public async Task<ContactDetails> DeleteAsync(Guid id)
        {
            var deletedContactDetails = await eMSDbContext.ContactDetails.FindAsync(id);
            if (deletedContactDetails == null)
            {
                return null;
            }
            eMSDbContext.ContactDetails.Remove(deletedContactDetails);
            await eMSDbContext.SaveChangesAsync();
            return deletedContactDetails;
        }


    }
}