using Booking_System.Context;
using Booking_System.Models;
using System.Collections.ObjectModel;

namespace Booking_System.Service
{
    public interface ICustomerService
    {
        Task<int> createCustomer(Customer customer);
    }
    public class CustomerService : ICustomerService
    {
        private readonly DbApplicationContext _context;
        public CustomerService(DbApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> createCustomer(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return customer.Id;
        }
    }
}
