using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.Domain;
using Backend.Model.Dto;

namespace Backend.Business
{
    public interface IFamilyService
    {
        Task<FamilyDetailRequestDto> GetAsync(Guid id);
        Task<FamilyDetailResponseDto> AddUpdateAsync(Guid id, FamilyDetailResponseDto familyDetailResponseDto);
        // Task<FamilyDetailResponseDto> UpdateAsync(Guid id, FamilyDetailResponseDto familyDetailResponseDto);
        Task<FamilyMemberDetail> DeleteAsync(Guid id); 
    }
}