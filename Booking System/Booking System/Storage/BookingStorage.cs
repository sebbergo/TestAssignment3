using Booking_System.Models;
using System.Collections.ObjectModel;

namespace Booking_System.Storage
{
    public interface IBookingStorage
    {
        int createBooking(Booking booking);
        Collection<Booking> getBookingsForCustomer(int customerId);
    }
    public class BookingStorage : IBookingStorage
    {
        public int createBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        public Collection<Booking> getBookingsForCustomer(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
