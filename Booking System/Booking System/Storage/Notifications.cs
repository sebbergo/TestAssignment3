using Booking_System.Models;

namespace Booking_System.Storage
{
    public interface INotifications
    {
        bool sendSms(SmsMessage message);
    }
    public class Notifications : INotifications
    {
        public bool sendSms(SmsMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
