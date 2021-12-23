using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Email
{
    public class EmailSender : IEmailSender
    {
        public EmailSender()
        {
        }

        public void Send()
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress(
                name: "Admin",
                address: "salman1277@gmail.com");

            message.From.Add(from);

            MailboxAddress to = new MailboxAddress(
                name: "User",
                address: "aukinternational@gmail.com");
            message.To.Add(to);

            message.Subject = "This is email subject";

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, true);
            client.Authenticate("salman1277@gmail.com", "$tsdDB2k20-20$2020");

            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
        }
    }
}
