namespace Booking_System.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<Booking> Booking { get; set; } = new List<Booking>();
    }
}