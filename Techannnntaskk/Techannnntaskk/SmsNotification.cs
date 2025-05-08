namespace Techannnntaskk
{
    public class SmsNotification : INotify
    {
        public void Send(string value)
        {
            Console.WriteLine("Sent sms to"+value);
        }
    }
}
