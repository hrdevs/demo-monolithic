using demo_monolithic.Models;
using demo_monolithic.Models.Dtos;

namespace demo_monolithic.Services
{
    public interface IEmployeeService
    {
        Task<bool> EmployeeExistsAsync(string firstName, string lastName);
        IEnumerable<Employee> GetAll();
        Employee? GetById(int employeeId);
        Task<Employee> Create(EmployeeDto employeeDto);
        Task Update(int employeeId, EmployeeDto employeeDto);
        Task Remove(int employeeId);
    }
}
