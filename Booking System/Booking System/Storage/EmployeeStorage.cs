using System.Collections.ObjectModel;
using Booking_System.Models;

namespace Booking_System.Storage
{
    public interface IEmployeeStorage
    {
        int createEmployee(Employee employee);
        Collection<Employee> getEmployeeWithId(int employeeId);

    }
    public class EmployeeStorage : IEmployeeStorage
    {
        public int createEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Collection<Employee> getEmployeeWithId(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
