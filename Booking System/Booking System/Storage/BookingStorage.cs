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
        Task<List<Booking>> getBookingsForEmployee(int employeeId);
    }
    public class BookingStorage : IBookingStorage
    {
        private readonly DbApplicationContext _context;

        public BookingStorage(DbApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a booking
        /// </summary>
        /// <param name="booking"></param>
        /// <returns>Id of the created booking</returns>
        public async Task<int> createBooking(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();

            return booking.Id;
        }

        public async Task<List<Booking>> getBookingsForCustomer(int customerId)
        {
            var bookings = await _context.Bookings.Where(x => customerId.Equals(x.CustomerId)).ToListAsync();

            return bookings;
        }

        public async Task<List<Booking>> getBookingsForEmployee(int employeeId)
        {
            var bookings = await _context.Bookings.Where(x => employeeId.Equals(x.EmployeeId)).ToListAsync();

            return bookings;
        }
    }
}
