using Booking_System.Context;
using Booking_System.Models;
using Booking_System.Storage;
using Microsoft.EntityFrameworkCore;

namespace BookingSystemTests.DataLayerTest
{
    public class BookingStorageTests
    {
        private static DbContextOptions<DbApplicationContext> dbContextOptions = new DbContextOptionsBuilder<DbApplicationContext>()
            .UseInMemoryDatabase(databaseName: "postgres")
            .Options;

        DbApplicationContext context;
        IBookingStorage bookingStorageContext;

        [OneTimeSetUp]
        public void Setup()
        {
            context = new DbApplicationContext(dbContextOptions);
            context.Database.EnsureCreated();

            bookingStorageContext = new BookingStorage(context);

            ModelBuilder builder = new ModelBuilder();

            SeedDatabase(builder);
        }

        [Test]
        public void CreateBookingTest()
        {
            //ARRANGE
            Booking booking = new Booking { Id = 1, CustomerId = 1, EmployeeId = 1, Date = DateTime.UtcNow, Start = DateTime.UtcNow, End = DateTime.UtcNow };

            //ACT
            var bookingId = bookingStorageContext.createBooking(booking);

            //ASSERT
            Assert.IsNotNull(bookingId);
        }

        [Test]
        public void CustomerBookingsTest()
        {
            //ARRANGE
            var customerId = 2;

            //ACT
            var bookings = bookingStorageContext.getBookingsForCustomer(customerId);

            //ASSERT
            Assert.IsNotNull(bookings);
        }

        [Test]
        public void EmployeeBookingsTest()
        {
            //ARRANGE
            var employeeId = 1;

            //ACT
            var bookings = bookingStorageContext.getBookingsForEmployee(employeeId);

            //ASSERT
            Assert.IsNotNull(bookings);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }

        private void SeedDatabase(ModelBuilder builder)
        {
            builder.Entity<Customer>().HasData(
                new Customer { Id = 1, FirstName = "Sebastian", LastName = "Hansen", PhoneNumber = "42424242" },
                new Customer { Id = 2, FirstName = "Phil", LastName = "Andersen", PhoneNumber = "84848484" }
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