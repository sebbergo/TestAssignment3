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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Seed(builder);
            base.OnModelCreating(builder);
        }

        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Customer>().HasData(
                new Customer { Id = 1, FirstName = "Sebastian", LastName = "Hansen"},
                new Customer { Id = 2, FirstName = "Phil", LastName = "Andersen"}
                );

            builder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Dr. Isenborg", Email = "isenborg@gmail.com", PhoneNumber = "31313131" },
                new Employee { Id = 2, Name = "Dr. Wegner", Email = "wegner@gmail.com", PhoneNumber = "75757575"}
                );

            builder.Entity<Booking>().HasData(
                   new Booking { Id = 1, CustomerId = 1, EmployeeId = 1, Date = DateTime.UtcNow, Start = DateTime.UtcNow, End = DateTime.UtcNow },
                   new Booking { Id = 2, CustomerId = 2, EmployeeId = 2, Date = DateTime.UtcNow, Start = DateTime.UtcNow, End = DateTime.UtcNow },
                   new Booking { Id = 3, CustomerId = 2, EmployeeId = 1, Date = DateTime.UtcNow, Start = DateTime.UtcNow, End = DateTime.UtcNow }
                );
        }
    }
}
