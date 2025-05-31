using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Model.Domain;
using Backend.Model.Dto;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business
{
    public class FamilyDetailService : IFamilyService
    {
        private readonly EMSDbContext eMSDbContext;
        public FamilyDetailService(EMSDbContext eMSDbContext)
        {
            this.eMSDbContext = eMSDbContext;
        }


        public async Task<FamilyDetailRequestDto> GetAsync(Guid id)
        {
            var familyDetails = await eMSDbContext.FamilyDetails
                                .Include(f => f.FamilyMemberDetails)
                                .Where(f => f.EmployeeId == id)
                                .Select(f => new FamilyDetailRequestDto
                                {
                                    EmployeeId = id,
                                    FamilyMembers = f.FamilyMemberDetails.Select(fe => new FamilyMemberRequestDto
                                    {
                                        Id = Guid.NewGuid(),
                                        RelationType = ((RelationType)fe.Relation).ToString(),
                                        Name = fe.Name != null ? fe.Name : "N/A",
                                        Address = fe.Address,
                                        PhoneNumber = fe.PhoneNumber,
                                        FamilyDetailId = id
                                    }).ToList()
                                }).FirstOrDefaultAsync();
            if (familyDetails == null)
            {
                return null;
            }
            return familyDetails;
        }

        public async Task<FamilyDetailResponseDto> AddUpdateAsync(Guid id, FamilyDetailResponseDto familyDetailResponseDto)
        {
            var existingEmployee = await eMSDbContext.Employees.FindAsync(id);
            if (existingEmployee == null)
            {
                throw new Exception("Employee with this id doesn't exists");
            }
            var existingFamilyDetail = await eMSDbContext.FamilyDetails.Include(fm => fm.FamilyMemberDetails).FirstOrDefaultAsync(e => e.EmployeeId == id);
            // if (existingFamilyDetail != null)
            // {
            //     return null;
            // }
            var memberDto = familyDetailResponseDto.FamilyMembers;
            if (existingFamilyDetail == null)
            {

                var newFamilyMemberDetails = new FamilyDetail
                {
                    EmployeeId = id,
                    // FamilyMemberDetails = familyDetailResponseDto.FamilyMembers.Select(Fm => new FamilyMemberDetail
                    // {
                    //     Id = Guid.NewGuid(),
                    //     Relation = Fm.Relation,
                    //     Name = Fm.Name,
                    //     Address = Fm.Address,
                    //     PhoneNumber = Fm.PhoneNumber,
                    //     FamilyDetailId = id
                    // })
                    FamilyMemberDetails = new List<FamilyMemberDetail>
                    {
                        new FamilyMemberDetail{
                            Id = Guid.NewGuid(),
                            Relation = memberDto.Relation,
                            Name = memberDto.Name,
                            Address = memberDto.Address,
                            PhoneNumber = memberDto.PhoneNumber,
                            FamilyDetailId = id
                        }
                    }
                };
                await eMSDbContext.FamilyDetails.AddAsync(newFamilyMemberDetails);
                // await eMSDbContext.SaveChangesAsync();
            }
            else
            {
                // var existingMemberById = existingFamilyDetail.FamilyMemberDetails.ToDictionary(m => m.Id);
                // Console.WriteLine(existingMemberById);

                // foreach (var memeberDto in familyDetailResponseDto.FamilyMembers)
                // {
                //     if (memeberDto.Id == ) {

                //     }
                // }
                FamilyMemberDetail existingFamilyMember = null;
                if (memberDto.Id != Guid.Empty)
                {
                    existingFamilyMember = existingFamilyDetail.FamilyMemberDetails.FirstOrDefault(m => m.Id == memberDto.Id);
                }

                if (existingFamilyMember != null)
                {
                    existingFamilyMember.Relation = memberDto.Relation;
                    existingFamilyMember.Name = memberDto.Name;
                    existingFamilyMember.Address = memberDto.Address;
                    existingFamilyMember.PhoneNumber = memberDto.PhoneNumber;
                    eMSDbContext.FamilyMemberDetails.Update(existingFamilyMember);
                }
                else
                {
                    var newFamilyMemberDetails =
                        // {
                        new FamilyMemberDetail
                        {
                            Id = Guid.NewGuid(),
                            Relation = memberDto.Relation,
                            Name = memberDto.Name,
                            Address = memberDto.Address,
                            FamilyDetailId = id
                            // }

                        };
                    await eMSDbContext.FamilyMemberDetails.AddAsync(newFamilyMemberDetails);
                }

            }
            await eMSDbContext.SaveChangesAsync();
            return familyDetailResponseDto;
        }

        // public async Task<FamilyDetailResponseDto> AddAsync(Guid id, FamilyDetailResponseDto familyDetailResponseDto)
        // {
        //     var existingFamilyDetail = await eMSDbContext.FamilyDetails.FindAsync(id);
        //     if (existingFamilyDetail != null)
        //     {
        //         return null;
        //     }

        //     var newFamilyMemberDetails = new FamilyDetail
        //     {
        //         EmployeeId = id,
        //         FamilyMemberDetails = familyDetailResponseDto.FamilyMembers.Select(fm => new FamilyMemberDetail
        //         {
        //             Id = Guid.NewGuid(),
        //             Relation = fm.RelationType,
        //             Name = fm.Name,
        //             Address = fm.Address,
        //             PhoneNumber = fm.PhoneNumber,
        //             FamilyDetailId = id
        //         }).ToList() 
        //     };
        //     await eMSDbContext.FamilyDetails.AddAsync(newFamilyMemberDetails);
        //     await eMSDbContext.SaveChangesAsync();
        //     return new FamilyDetailResponseDto
        //     {
        //         FamilyMembers = newFamilyMemberDetails.FamilyMemberDetails.Select(fm => new FamilyMemberResponseDto
        //         {
        //             // Id = fm.Id,
        //             RelationType = fm.Relation,
        //             Name = fm.Name,
        //             Address = fm.Address,
        //             PhoneNumber = fm.PhoneNumber,
        //             FamilyDetailId = fm.FamilyDetailId
        //         }).ToList()
        //     };
        // }



        // public async Task<FamilyDetailResponseDto> UpdateAsync(Guid id, FamilyDetailResponseDto familyDetailResponseDto)
        // {
        //     var existingFamilyDetail = await eMSDbContext.FamilyDetails.FindAsync(id);
        //     if (existingFamilyDetail == null)
        //     {
        //         return null;
        //     }

        //     var existingFamilyMemberDetails = await eMSDbContext.FamilyMemberDetails
        //                                     .Where(f => f.FamilyDetailId == existingFamilyDetail.EmployeeId && f.Id == familyDetailResponseDto.FamilyMembers.)
        //                                     .ToListAsync();

        //     // foreach (var member in existingFamilyMemberDetails)
        //     // {
        //     //      = 
        //     // }

        // }


        public async Task<FamilyMemberDetail> DeleteAsync(Guid id)
        {
            var existingFamilyMemberDetail = await eMSDbContext.FamilyMemberDetails.FindAsync(id);
            if (existingFamilyMemberDetail != null)
            {
                eMSDbContext.FamilyMemberDetails.Remove(existingFamilyMemberDetail);
                await eMSDbContext.SaveChangesAsync();
                return existingFamilyMemberDetail;
            }
            return null;
        }
    }
}