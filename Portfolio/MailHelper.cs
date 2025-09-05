using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Portfolio
{
    public class MailHelper
    {
        public static void mailSender(string fullname, string email, string message)
        {
            try
            {
                //  Email to Admin
                MailMessage adminMail = new MailMessage();
                adminMail.To.Add("himel19242@gmail.com");   // myadmin email address
                adminMail.From = new MailAddress("mdhimelhossain512@gmail.com");
                adminMail.Subject = "New Contact Message from " + fullname;
                adminMail.Body = $"<b>Name:</b> {fullname}<br/><b>Email:</b> {email}<br/><b>Message:</b><br/>{message}";
                adminMail.IsBodyHtml = true;

                // Auto-reply to User
                MailMessage userMail = new MailMessage();
                userMail.To.Add(email);
                userMail.From = new MailAddress("mdhimelhossain512@gmail.com");
                userMail.Subject = "Thanks for contacting us!";
                userMail.Body = $"Dear {fullname},<br/><br/>Thanks for reaching out. We will get back to you soon.<br/><br/>Regards,<br/>Portfolio Team";
                userMail.IsBodyHtml = true;

               
                SmtpClient smtp = new SmtpClient();
                smtp.Send(adminMail);
                smtp.Send(userMail);
            }
            catch (Exception ex)
            {
                throw new Exception("Mail sending failed: " + ex.Message);
            }
        }
    }
}