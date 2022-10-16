using Booking_System.Context;
using Booking_System.Models;
using Booking_System.Service;
using Booking_System.Storage;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemTests.ServiceLayerTest
{
    internal class BookingServiceTest
    {
        private Mock<IBookingStorage> bookingStorageMock;
        private IBookingService bookingService;

        [OneTimeSetUp]
        public void Setup()
        {
            bookingStorageMock = new Mock<IBookingStorage>();
            bookingService = new BookingService(bookingStorageMock.Object);
        }

        [Test]
        public void CreateServiceTest()
        {
            //ARRANGE
            Booking booking = new Booking { CustomerId = 1, EmployeeId = 1, Date = DateTime.UtcNow, Start = DateTime.UtcNow, End = DateTime.UtcNow };

            //ACT
            var returnedId = bookingService.createBooking(booking.CustomerId, booking.EmployeeId, booking.Date, booking.Start, booking.End);

            //ASSERT
            Assert.That(returnedId.IsCompletedSuccessfully);
        }

        [Test]
        public void GetBookingsForCustomers()
        {
            //ARRANGE
            int customerId = 1;

            //ACT
            Task<List<Booking>> customerBookings = bookingService.getBookingsForCustomer(customerId);

            //ASSERT
            Assert.IsNotNull(customerBookings);
        }

        [Test]
        public void GetBookingsForEmployee()
        {
            //ARRANGE
            int employeeId = 1;

            //ACT
            Task<List<Booking>> customerBookings = bookingService.getBookingsForEmployee(employeeId);

            //ASSERT
            Assert.IsNotNull(customerBookings);
        }
    }
}
