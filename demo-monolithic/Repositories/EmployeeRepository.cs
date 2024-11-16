using demo_monolithic.Models;
using Microsoft.EntityFrameworkCore;

namespace demo_monolithic.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EmployeeRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> ExistsAsync(string firstName, string lastName)
        {
            return await _applicationDbContext.Employees.AnyAsync(x => x.FirstName == firstName && x.LastName == lastName);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _applicationDbContext.Employees.ToListAsync();
        }

        public Employee? GetById(int employeeId)
        {
            return _applicationDbContext.Employees.Find(employeeId);
        }

        public async Task Create(Employee employee)
        {
            await _applicationDbContext.AddAsync(employee);
        }

        public Task Update(Employee employee)
        {
            _applicationDbContext.Update(employee);

            return Task.CompletedTask;
        }

        public Task Remove(Employee employee)
        {
            _applicationDbContext.Remove(employee);

            return Task.CompletedTask;
        }

        public async Task SaveChanges()
        {
           await _applicationDbContext.SaveChangesAsync();
        }
    }
}
