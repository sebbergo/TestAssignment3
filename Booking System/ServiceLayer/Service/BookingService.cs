using Booking_System.Models;
using Booking_System.Storage;
using System.Collections.ObjectModel;

namespace Booking_System.Service
{
    public interface IBookingService
    {
        Task<int> createBooking(int customerId, int employeeId, DateTime date, DateTime start, DateTime end);
        Task<List<Booking>> getBookingsForCustomer(int customerId);
        Task<List<Booking>> getBookingsForEmployee(int employeeId);
    }
    public class BookingService : IBookingService
    {
        private readonly IBookingStorage _bookingStorage;

        public BookingService(IBookingStorage bookingStorage)
        {
            _bookingStorage = bookingStorage;
        }

        public Task<int> createBooking(int customerId, int employeeId, DateTime date, DateTime start, DateTime end)
        {
            try
            {
                Booking booking = new Booking { CustomerId = customerId, EmployeeId = employeeId, Date = date, Start = start, End = end };

                var bookingId = _bookingStorage.createBooking(booking);

                return bookingId;
            }
            catch (Exception e)
            {

                throw new Exception("There was an error: " + e.Message);
            }
        }

        public Task<List<Booking>> getBookingsForCustomer(int customerId)
        {
            try
            {
                var bookings = _bookingStorage.getBookingsForCustomer(customerId);

                return bookings;
            }
            catch (Exception e)
            {

                throw new Exception("There was an error: " + e.Message);
            }
        }

        public Task<List<Booking>> getBookingsForEmployee(int employeeId)
        {
            try
            {
                var bookings = _bookingStorage.getBookingsForEmployee(employeeId);

                return bookings;
            }
            catch (Exception e)
            {

                throw new Exception("There was an error: " + e.Message);
            }
        }
    }
}
