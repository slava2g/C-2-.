using System;

namespace Task2
{
    public class MessagePublisher
    {
        public event Action<string> MessageSent;

        public void Send(string message)
        {
            MessageSent?.Invoke(message);
        }
        
    }
    internal class Program
    {

    }

}



