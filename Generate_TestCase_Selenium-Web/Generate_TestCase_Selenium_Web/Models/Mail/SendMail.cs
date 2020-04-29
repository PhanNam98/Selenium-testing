using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading;

namespace Generate_TestCase_Selenium_Web.Models.Mail
{
    public class SendMail
    {
        private SendMail() { }
        public static void sendMail(string Message, string email, string subject)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Generate_Testcase_Web Service", "nguoithichduajoker1@gmail.com"));
            message.To.Add(new MailboxAddress(email));
            message.Subject = subject;
            message.Body = new TextPart("html")
            {
                Text = Message
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("nguoithichduajoker1@gmail.com", "yccuenfqgfdxsnbu");

                client.Send(message);

                client.Disconnect(true);
            }


        }
        public static async Task SendMailASync(string Message, string email, string subject)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Generate_Testcase_Web Service", "nguoithichduajoker1@gmail.com"));
            message.To.Add(new MailboxAddress(email));
            message.Subject = subject;
            message.Body = new TextPart("html")
            {
                Text = Message
            };

            using (var client = new SmtpClient())
            {

                await Task.Run(() =>
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("nguoithichduajoker1@gmail.com", "yccuenfqgfdxsnbu");

                    client.Send(message);

                    client.Disconnect(true);
                    Console.WriteLine("Send Mail successfully");
                });
            }

        }
    }
}
