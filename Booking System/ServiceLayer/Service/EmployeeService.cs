using Booking_System.Models;
using Booking_System.Storage;

namespace Booking_System.Service
{
    public interface IEmployeeService
    {
        Task<int> createEmployee(Employee employee);
        Task<Employee> getEmployeeById(int employeeId);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeStorage _context;

        public EmployeeService(IEmployeeStorage context)
        {
            _context = context;
        }
        public async Task<int> createEmployee(Employee employee)
        {
            var employeeid = await _context.createEmployee(employee);

            return employeeid;
        }

        public async Task<Employee> getEmployeeById(int employeeId)
        {
            var employee = await _context.getEmployeeById(employeeId);

            return employee;
        }
    }
}
