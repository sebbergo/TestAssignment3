using Booking_System.Models;
using Booking_System.Service;
using Booking_System.Storage;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemTests.ServiceLayerTest
{
    internal class EmployeeServiceTest
    {
        private Mock<IEmployeeStorage> employeeStorageMock;
        private IEmployeeService employeeService;

        [OneTimeSetUp]
        public void Setup()
        {
            employeeStorageMock = new Mock<IEmployeeStorage>();
            employeeService = new EmployeeService(employeeStorageMock.Object);
        }

        [Test]
        public void CreateEmployeeTest()
        {
            ///ARRANGE
            Employee employee = new Employee { Id = 1, Booking = new List<Booking>(), Email = "employee@email.com", Name = "Employee", PhoneNumber = "12345612" };

            //ACT
            var employeeId = employeeService.createEmployee(employee);

            //ASSERT
            Assert.IsNotNull(employeeId);
        }

        [Test]
        public void GetEmployeeByIdTest()
        {
            //ARRANGE
            var employeeId = 1;

            //ACT
            var employee = employeeService.getEmployeeById(employeeId);

            //ASSERT
            Assert.IsNotNull(employee);
        }

    }
}
