using Backend.Model.Domain;
using Backend.Model.Dto;

namespace Backend.Business
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetAllAsync();
        Task<List<JobRole>> GetAllJobRoleAsync(Guid id);
        Task<Department?> GetByIdAsync(Guid id);
        Task<Department> AddAsync(Department department);
        Task<Department> UpdateAsync(Guid id, Department department);
        Task<Department> DeleteAsync(Guid id);
    }
}
