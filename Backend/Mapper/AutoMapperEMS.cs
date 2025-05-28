using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Model.Domain;
using Backend.Model.Dto;

namespace Backend.Mapper
{
    public class AutoMapperEMS:Profile
    {
        public AutoMapperEMS()
        {
            CreateMap<Employee, EmployeeResponseDto>().ReverseMap();
            CreateMap<Employee, EmployeeRequestDto>().ReverseMap();
            CreateMap<JobRole, JobRoleRequestDto>().ReverseMap();
            CreateMap<JobRole, JobRoleDto>().ReverseMap();
            CreateMap<DepartmentDto, Department>().ReverseMap();
            CreateMap<SalaryStructure, SalaryStructureDto>().ReverseMap();
            CreateMap<ContactDetails, ContactDetailsRequestDto>().ReverseMap();
            CreateMap<AssetType, AssetTypeRequestDto>().ReverseMap();
            CreateMap<Department, DepartmentResponseDto>().ReverseMap()
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedBy, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedAt, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
            ;
        }
    }
}