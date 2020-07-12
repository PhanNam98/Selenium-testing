using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace Generate_TestCase_Selenium_Web.Models.Mail
{
    public class SendMail
    {
        private SendMail() { }
        public static void sendMail(string Message, string email, string subject)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Automation Generate TestCase Web Service", "nguoithichduajoker1@gmail.com"));
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
            //message.From.Add(new MailboxAddress("Generate_Testcase_Web Service", "nguoithichduajoker1@gmail.com"));
            message.From.Add(new MailboxAddress("Automation Generate TestCase Web Service", "nguoithichduajoker1@gmail.com"));
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
        public static async Task SendMailWithFile(string Message, string email, string subject,string path)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Automation Generate TestCase Web Service", "nguoithichduajoker1@gmail.com"));
            message.To.Add(new MailboxAddress(email));
            message.Subject = subject;
            
            var body = new TextPart("html")
            {
                Text = Message
            };

            var attachment = new MimePart("application", "gif")
            {
                Content = new MimeContent(File.OpenRead(path)),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = Path.GetFileName(path)
            };

            // now create the multipart/mixed container to hold the message text and the

            var multipart = new Multipart("mixed");
            multipart.Add(body);
            multipart.Add(attachment);

            // now set the multipart/mixed as the message body
            message.Body = multipart;
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
            try
            {
                // Check if file exists with its full path    
                if ((System.IO.File.Exists(path)))
                {
                    System.IO.File.Delete(path);
                }
                //else Console.WriteLine("File not found");
            }
            catch (IOException ioExp)
            {
                string mes = ioExp.Message;
            }
        }
    }
}
