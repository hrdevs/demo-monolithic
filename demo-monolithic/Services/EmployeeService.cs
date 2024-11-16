using demo_monolithic.Models;
using demo_monolithic.Models.Dtos;
using demo_monolithic.Repositories;

namespace demo_monolithic.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> EmployeeExistsAsync(string firstName, string lastName)
        {
            return await _employeeRepository.ExistsAsync(firstName, lastName);
        }

        public IEnumerable<Employee> GetAll()
        {
            var employees = _employeeRepository.GetAll().Result;

            return employees;
        }

        public Employee? GetById(int employeeId)
        {
            return _employeeRepository.GetById(employeeId);
        }

        public async Task<Employee> Create(EmployeeDto employeeDto)
        {
            var newEmployee = new Employee()
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Address = employeeDto.Address,
                Position = employeeDto.Position,
                CreatedAt = DateTime.Now
            };

            await _employeeRepository.Create(newEmployee);
            await _employeeRepository.SaveChanges();

            return newEmployee;
        }

        public async Task Update(int employeeId, EmployeeDto employeeDto)
        {
            var employee = _employeeRepository.GetById(employeeId);
            if (employee == null) throw new Exception("Employee not found");

            employee.FirstName = employeeDto.FirstName;
            employee.LastName = employeeDto.LastName;
            employee.Address = employeeDto.Address;
            employee.Position = employeeDto.Position;

            await _employeeRepository.SaveChanges();
        }

        public async Task Remove(int employeeId)
        {
            var employee = _employeeRepository.GetById(employeeId);
            if (employee == null) throw new Exception("Employee not found");

            await _employeeRepository.Remove(employee);
            await _employeeRepository.SaveChanges();
        }
    }
}
