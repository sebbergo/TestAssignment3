using Booking_System.Models;
using Booking_System.Storage;
using Data_Layer.Service;
using System.Collections.ObjectModel;

namespace Booking_System.Service
{
    public interface IBookingService
    {
        int createBooking(int customerId, int employeeId, DateOnly date, TimeOnly start, TimeOnly end);
        Collection<Booking> getBookingsForCustomer(int customerId);
        Collection<Booking> getBookingsForEmployee(int employeeId);
    }
    public class BookingService : IBookingService
    {
        private readonly IBookingStorage _bookingStorage;
        private readonly ICustomerStorage _customerStorage;
        private readonly IEmployeeStorage _employeeStorage;
        private readonly INotifications _notifications;

        public BookingService(
            IBookingStorage bookingStorage,
            ICustomerStorage customerStorage,
            IEmployeeStorage employeeStorage,
            INotifications notifications)
        {
            _bookingStorage = bookingStorage;
            _customerStorage = customerStorage;
            _employeeStorage = employeeStorage;
            _notifications = notifications;
        }

        public int createBooking(int customerId, int employeeId, DateOnly date, TimeOnly start, TimeOnly end)
        {
            try
            {
                Booking booking = new Booking(customerId, employeeId, date, start, end);

                _bookingStorage.createBooking()
            }
            catch
            {

            }
        }

        public Collection<Booking> getBookingsForCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public Collection<Booking> getBookingsForEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
