using Booking_System.Context;
using Booking_System.Models;
using Common.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace Booking_System.Storage
{
    public interface IBookingStorage
    {
        Task<int> createBooking(Booking booking);
        Task<List<Booking>> getBookingsForCustomer(int customerId);
        Task<List<Booking>> getBookingsForEmployee(int customerId);
    }
    public class BookingStorage : IBookingStorage
    {
        private readonly DbApplicationContext _applicationContext;

        public BookingStorage(DbApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        private static readonly Expression<Func<Booking, BookingDTO>> AsBookingDTO =
        x => new BookingDTO()
        {
            CustomerId = x.CustomerId,
            EmployeeId = x.EmployeeId,
            Date = x.Date,
            Start = x.Start,
            End = x.End
        };

        /// <summary>
        /// Creates a booking
        /// </summary>
        /// <param name="booking"></param>
        /// <returns>Id of the created booking</returns>
        public async Task<int> createBooking(Booking booking)
        {
            var bookingSaved = await _applicationContext.Bookings.AddAsync(booking);
            await _applicationContext.SaveChangesAsync();

            return booking.Id;
        }

        public async Task<List<Booking>> getBookingsForCustomer(int customerId)
        {
            var bookings = await _applicationContext.Bookings.Where(x => customerId.Equals(x.CustomerId)).ToListAsync();

            return bookings;
        }

        public async Task<List<Booking>> getBookingsForEmployee(int employeeId)
        {
            var bookings = await _applicationContext.Bookings.Where(x => employeeId.Equals(x.CustomerId)).ToListAsync();

            return bookings;
        }
    }
}
