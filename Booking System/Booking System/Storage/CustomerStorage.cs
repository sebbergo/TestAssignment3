using System.Collections.ObjectModel;
using Booking_System.Models;

namespace Booking_System.Storage
{
    public interface ICustomerStorage
    {
        Customer getCustomerWithId(int customerId);
        List<Customer> getCustomersByFirstName(string firstName);
        int createCustomer(Customer customer);
    }
    public class CustomerStorage : ICustomerStorage
    {
        public int createCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public List<Customer> getCustomersByFirstName(string firstName)
        {
            throw new NotImplementedException();
        }

        public Customer getCustomerWithId(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
