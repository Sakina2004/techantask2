namespace Techannnntaskk
{
    public class TelegramNotification : INotify
    {
        public void Send(string value)
        {
            Console.WriteLine("Sent telegram notification to" + value);
        }
    }
}
