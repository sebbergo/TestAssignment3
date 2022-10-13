namespace Booking_System.Models
{
    public class SmsMessage
    {
        public int Id { get; set; }
        public string Recipient { get; set; }
        public string Message { get; set; }
    }
}