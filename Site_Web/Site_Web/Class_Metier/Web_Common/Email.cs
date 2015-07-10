using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace Site_Web.Class_Metier.Web_Common
{
    /// <summary>
    /// Classe utilitaire contenant des fonction statique lié au Email
    /// </summary>
    public class Email
    {

        /// <summary>
        /// Fonction de test pour l'envoie d'email d'une adresse définie a une autre adresse déjà définie
        /// </summary>
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

        /// <summary>
        /// Fonction d'envoie d'email définissant déjà le serveur d'envoie comme "smtp.gmail.com"
        /// </summary>
        /// <param name="sender">Messagerie d'envoie appartenant au domainde de google</param>
        /// <param name="mdp">Le mot de passe de la messagerie d'envoie</param>
        /// <param name="receiver">L'adresse e-mail du receveur</param>
        /// <param name="subject">L'objet du mail</param>
        /// <param name="body">Le corps du mail acceptant l'HTML</param>
        public static void SendEmail(string sender,string mdp, string receiver,string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(sender);
                mail.To.Add(receiver);
                mail.Subject = subject;

                mail.IsBodyHtml = true;
                string htmlBody;

                htmlBody = body;

                mail.Body = htmlBody;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(sender, mdp);
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