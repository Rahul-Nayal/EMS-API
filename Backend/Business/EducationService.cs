using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business
{
    public class EducationService : IEducationService
    {
        private readonly EMSDbContext eMSDbContext;
        public EducationService(EMSDbContext eMSDbContext)
        {
            this.eMSDbContext = eMSDbContext;
        }

        public async Task<List<Education>> GetAsync(Guid id)
        {
            var educationDetails = await eMSDbContext.Educations
                                    .Where(e => e.EmployeeId == id).ToListAsync();

            if (educationDetails == null)
            {
                return null;
            }
            return educationDetails;
        }

        public async Task<Education> AddUpdateAsync(Guid id, Education education)
        {
            // var existingEmployee = await eMSDbContext.Employees.FindAsync(id);
            // if (existingEmployee == null)
            // {
            //     throw new Exception("Employee doesn't exists");
            // }

            var existingEducationDetail = await eMSDbContext.Educations.FindAsync(id);
            if (existingEducationDetail != null)
            {
                existingEducationDetail.Course = education.Course;
                existingEducationDetail.CGPA = education.CGPA;
                existingEducationDetail.Title = education.Title;
                eMSDbContext.Educations.Update(existingEducationDetail);
            }
            else
            {
                var newEducationDetails = new Education
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = id,
                    Course = education.Course,
                    CGPA = education.CGPA,
                    Title = education.Title
                };
                await eMSDbContext.Educations.AddAsync(newEducationDetails);
            }

            await eMSDbContext.SaveChangesAsync();
            return education;
        }

        public async Task<Education> DeleteAsync(Guid id)
        {
            var existingEducationDetail = await eMSDbContext.Educations.FindAsync(id);
            if (existingEducationDetail != null)
            {
                eMSDbContext.Educations.Remove(existingEducationDetail);
                await eMSDbContext.SaveChangesAsync();
                return existingEducationDetail;
            }
            return null;
        }
    }
}