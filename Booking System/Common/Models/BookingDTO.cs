namespace Common.Models
{
    public class BookingDTO
    {
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
