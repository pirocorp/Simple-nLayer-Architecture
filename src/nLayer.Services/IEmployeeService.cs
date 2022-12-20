namespace nLayer.Services;

using Models.Employees;

public interface IEmployeeService
{
    Task<EmployeeDetailsDto?> GetById(int id);

    Task<IEnumerable<EmployeeDto>> GetAll();

    Task<EmployeeDetailsDto> CreateEmployee(
        CreateEmployeeDto input,
        CancellationToken cancellationToken);

    Task<EmployeeDto?> FireEmployee(
        int employeeId, 
        CancellationToken cancellationToken);

    Task<EmployeeDetailsDto?> Update(
        int id, 
        UpdateEmployeeDto input, 
        CancellationToken cancellationToken);
}
