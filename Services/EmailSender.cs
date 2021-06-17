using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Survey.Services
{
    public class EmailSender :IEmailSender
    {
        public EmailSender() :base()
        { 
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress(email));
                message.From = new MailAddress("gurgen.ohanyan.1999@gmail.com", "Survey");
                message.Subject = subject;
                message.Body = htmlMessage;
                message.IsBodyHtml = true;
                using (var client = new SmtpClient("smtp.gmail.com"))
                {
                    client.Port = 587;
                    client.UseDefaultCredentials = true;
                    client.Credentials = new NetworkCredential("gurgen.ohanyan.1999@gmail.com", "ASDF123-asdf");
                    client.EnableSsl = true;
                    client.Send(message);
                }
            }
        }
    }
}

