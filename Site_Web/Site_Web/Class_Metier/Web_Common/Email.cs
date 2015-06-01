using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace Site_Web.Class_Metier.Web_Common
{
    public class Email
    {


        public static void SendEmail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("thonnat.bastien@gmail.com");
                mail.To.Add("thonnat.bastien@gmail.com");
                mail.Subject = "Test Mail - 1";

                mail.IsBodyHtml = true;
                string htmlBody;

                htmlBody = "Write some HTML code here";

                mail.Body = htmlBody;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("thonnat.bastien@gmail.com", "");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}