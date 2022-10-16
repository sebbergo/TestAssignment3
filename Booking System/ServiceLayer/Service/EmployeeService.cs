using Booking_System.Models;

namespace Booking_System.Service
{
    public interface IEmployeeService
    {
        int createEmployee(Employee employee);
        Employee getEmployeeById(int employeeId);
    }
    public class EmployeeService : IEmployeeService
    {
        public int createEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee getEmployeeById(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
