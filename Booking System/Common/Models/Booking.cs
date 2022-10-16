using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_System.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

    }
}