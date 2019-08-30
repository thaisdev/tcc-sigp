using System.Net;
using System.Net.Mail;

namespace VirtusGo.Core.Infra.CrossCutting.Mail.Kernel
{
    public class MailHelper
    {
        public MailHelper()
        {
            Message = new MailMessage { IsBodyHtml = true };
        }

        public MailHelper(string toAddress)
            : this()
        {
            var emails = toAddress.Trim().Split(',');
            foreach (var email in emails)
            {
                Message.To.Add(new MailAddress(email));
            }

            Message.From = new MailAddress("nao-responder@focovirtual.com",
               "Paulo Carpegiani da Virtus");
        }

        public MailMessage Message { get; set; }

        //public void SendMail()
        //{   
        //    //smtp
        //    var smtpServer = ConfigurationManager.AppSettings["SmtpServerSes"];
        //    var smtpUser = ConfigurationManager.AppSettings["SmtpUserSes"];
        //    var smtpPass = ConfigurationManager.AppSettings["SmtpPassSes"];
        //    var smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPortSes"]);
        //    var credential = new NetworkCredential(smtpUser, smtpPass);

        //    var smtp = new SmtpClient(smtpServer, smtpPort) { Credentials = credential, EnableSsl = false };

        //    smtp.Send(Message);
        //}

        public void SendMailSes()
        {
            //smtp
            const string smtpServer = "email-smtp.us-east-1.amazonaws.com";
            const string smtpUser = "AKIAINXFUSSRMMORJRPQ";
            const string smtpPass = "ApvSewjoeqvAYq5R9lRhogStkFDTOKMlDBVGH3G6TxcX";
            var smtpPort = int.Parse("587");
            var credential = new NetworkCredential(smtpUser, smtpPass);

            var smtp = new SmtpClient(smtpServer, smtpPort) { Credentials = credential, EnableSsl = true };

            smtp.Send(Message);
        }

        public void SendMailSync()
        {
            var c = new SmtpClient();
            c.Send(Message);
        }
    }
}