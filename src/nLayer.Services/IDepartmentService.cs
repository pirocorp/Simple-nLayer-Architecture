namespace nLayer.Services;

using nLayer.Services.Models.Departments;

public interface IDepartmentService
{
    Task<DepartmentFullDetailsDto?> GetById(int id);

    Task<IEnumerable<DepartmentListingDto>> GetAll();

    Task<DepartmentDetailsDto> CreateDepartment(
        CreateDepartmentDto departmentDto, 
        CancellationToken cancellationToken);

    Task<DepartmentDetailsDto?> RenameDepartment(
        int id, 
        RenameDepartmentDto dto, 
        CancellationToken cancellationToken);

    Task<DepartmentDetailsDto?> DeleteDepartment(
        int id, 
        CancellationToken cancellationToken);
}
