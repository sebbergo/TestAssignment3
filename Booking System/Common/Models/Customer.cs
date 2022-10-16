namespace Booking_System.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Booking> Booking { get; set; } = new List<Booking>();
    }
}