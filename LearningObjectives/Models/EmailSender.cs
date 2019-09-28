using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LearningObjectives.Models
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var task = new Task(() =>
            {
                SmtpClient smtpClient = new SmtpClient("smtp.utah.edu",
                   25);
                MailMessage mail = new MailMessage();

                smtpClient.EnableSsl = true;
                // Email confirmation works if the username and password are provided.
                // Obviously, I'm not going to hard code them in.  Since there's no appararent 
                // solution, email validation only kind of works.
                smtpClient.Credentials = new NetworkCredential() {UserName="NA", Password="NA"};

                // WARNING: what email are you going to send to? germain@cs.utah.edu?

                mail.From = new MailAddress("u0867480@utah.edu", "LOT");
                mail.To.Add(new MailAddress(email));

                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;

                smtpClient.Send(mail);
            });
            task.Start();
            return task;
        }
    }
}
