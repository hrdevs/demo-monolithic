using demo_monolithic.Models;

namespace demo_monolithic.Repositories
{
    public interface IEmployeeRepository
    {
        Task<bool> ExistsAsync(string firstName, string lastName);
        Task<IEnumerable<Employee>> GetAll();
        Employee? GetById(int employeeId);
        Task Create(Employee employee);
        Task Update(Employee employee);
        Task Remove(Employee employee);
        Task SaveChanges();
    }
}
