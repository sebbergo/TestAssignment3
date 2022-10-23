using Booking_System.Context;
using Booking_System.Models;
using Booking_System.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemTests.DataLayerTest
{
    public class EmployeeStorageTests
    {
        private static DbContextOptions<DbApplicationContext> dbContextOptions = new DbContextOptionsBuilder<DbApplicationContext>()
            .UseInMemoryDatabase(databaseName: "postgres")
            .Options;

        DbApplicationContext context;
        IEmployeeStorage employeeStorageContext;

        [OneTimeSetUp]
        public void Setup()
        {
            context = new DbApplicationContext(dbContextOptions);
            context.Database.EnsureCreated();

            employeeStorageContext = new EmployeeStorage(context);

            ModelBuilder builder = new ModelBuilder();

            SeedDatabase(builder);
        }

        [Test]
        public void CreateEmployeeTest()
        {
            //ARRANGE
            Employee employee = new Employee { Id = 1, Booking = new List<Booking>(), Email = "employee@email.com", Name = "Employee", PhoneNumber = "12345612"};

            //ACT
            var employeeId = employeeStorageContext.createEmployee(employee);

            //ASSERT
            Assert.IsNotNull(employeeId);
        }

        [Test]
        public void GetEmployeeFromIdTest()
        {
            //ARRANGE
            var employeeId = 1;

            //ACT
            var employee = employeeStorageContext.getEmployeeById(employeeId);

            //ASSERT
            Assert.IsNotNull(employee);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }

        private void SeedDatabase(ModelBuilder builder)
        {
            builder.Entity<Customer>().HasData(
                new Customer { Id = 1, FirstName = "Sebastian", LastName = "Hansen"},
                new Customer { Id = 2, FirstName = "Phil", LastName = "Andersen"}
                );

            builder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Dr. Isenborg", Email = "isenborg@gmail.com", PhoneNumber = "31313131" },
                new Employee { Id = 2, Name = "Dr. Wegner", Email = "wegner@gmail.com", PhoneNumber = "75757575" }
                );

            builder.Entity<Booking>().HasData(
                   new Booking { Id = 1, CustomerId = 1, EmployeeId = 1, Date = DateTime.UtcNow, Start = DateTime.UtcNow, End = DateTime.UtcNow },
                   new Booking { Id = 2, CustomerId = 2, EmployeeId = 2, Date = DateTime.UtcNow, Start = DateTime.UtcNow, End = DateTime.UtcNow },
                   new Booking { Id = 3, CustomerId = 2, EmployeeId = 1, Date = DateTime.UtcNow, Start = DateTime.UtcNow, End = DateTime.UtcNow }
                );
        }
    }
}
