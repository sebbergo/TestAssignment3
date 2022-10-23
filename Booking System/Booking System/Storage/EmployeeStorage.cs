using System.Collections.ObjectModel;
using Booking_System.Context;
using Booking_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking_System.Storage
{
    public interface IEmployeeStorage
    {
        Task<int> createEmployee(Employee employee);
        Task<Employee> getEmployeeById(int employeeId);

    }
    public class EmployeeStorage : IEmployeeStorage
    {
        private readonly DbApplicationContext _context;

        public EmployeeStorage(DbApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> createEmployee(Employee employee)
        {
            await _context.Employess.AddAsync(employee);
            await _context.SaveChangesAsync();

            return employee.Id;
        }

        public async Task<Employee> getEmployeeById(int employeeId)
        {
            var employee = await _context.Employess.Where(x => x.Equals(employeeId)).FirstOrDefaultAsync();

            return employee;
        }

    }
}
