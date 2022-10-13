using Booking_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking_System.Context
{
    public class DbApplicationContext : DbContext
    {
        public DbApplicationContext(DbContextOptions<DbApplicationContext> options) : base(options) { }
        
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employess { get; set; }
        public DbSet<SmsMessage> SmsMessages { get; set; }
    }
}
