using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework1.DIP
{
    // Bad Example of DIP
    /*
    public class EmailSender
    {
        public void SendEmail(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }

    public class NotificationService
    {
        private EmailSender _emailSender;

        public NotificationService()
        {
            _emailSender = new EmailSender(); // Doğrudan bağımlılık
        }

        public void Notify(string message)
        {
            _emailSender.SendEmail(message);
        }
    }*/

    public interface IMessageSender
    {
        void SendMessage(string message);
    }

    public class EmailSender : IMessageSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }

    public class SmsSender : IMessageSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }
    }

    public class NotificationService
    {
        private readonly IMessageSender _messageSender;

        public NotificationService(IMessageSender messageSender)
        {
            _messageSender = messageSender; // Arayüze bağımlılık
        }

        public void Notify(string message)
        {
            _messageSender.SendMessage(message);
        }
    }
}