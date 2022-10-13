using Booking_System.Models;
using System.Collections.ObjectModel;

namespace Data_Layer.Service
{
    public interface ICustomerService
    {
        int createCustomer(string firstName, string lastName, DateOnly birthday);
        CustomerService getCustomerById(int id);
        Collection<Customer> getCustomersByFirstName(string firstName);
    }
    public class CustomerService : ICustomerService
    {
        public int createCustomer(string firstName, string lastName, DateOnly birthday)
        {
            throw new NotImplementedException();
        }

        public CustomerService getCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public Collection<Customer> getCustomersByFirstName(string firstName)
        {
            throw new NotImplementedException();
        }
    }
}
