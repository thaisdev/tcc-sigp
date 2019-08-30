using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace VirtusGo.Core.Infra.CrossCutting.Mail.Kernel
{
    public class EmailManager
    {
        /// <summary>
        /// Chave e valor dos campos de email
        /// </summary>
        public Dictionary<string, string> Values;

        /// <summary>
        /// Anexos
        /// </summary>
        //public AttachmentCollection Attachments { get; set; }

        public List<Attachment> Attachments { get; set; }


        public EmailManager()
        {
            Values = new Dictionary<string, string>();
        }

        /// <summary>
        /// Envia email
        /// </summary>
        /// <param name="assunto"></param>
        /// <param name="corpoEmail"></param>
        /// <param name="emailPara">Para enviar e-mail para mais de um destinatário separar com virgula</param>
        //public void EnviarEmail(string assunto, string corpoEmail, string emailPara)
        //{
        //    foreach (var field in Values)
        //    {
        //        corpoEmail = corpoEmail.Replace(field.Key, field.Value);
        //        assunto = assunto.Replace(field.Key, field.Value);
        //    }

        //    var mail = new MailHelper(emailPara) { Message = { Subject = assunto, Body = corpoEmail } };

        //    if (Attachments != null && Attachments.Count > 0) // Adiciona anexos se não nulo
        //        foreach (var attachment in this.Attachments)
        //            mail.Message.Attachments.Add(attachment);

        //    mail.SendMail();// Assync

        //    this.Values.Clear();
        //}

        /// <summary>
        /// Envia email
        /// </summary>
        /// <param name="assunto"></param>
        /// <param name="corpoEmail"></param>
        /// <param name="emailPara">Para enviar e-mail para mais de um destinatário separar com virgula</param>
        public void EnviarEmailSes(string assunto, string corpoEmail, string emailPara)
        {
            if (corpoEmail == null) throw new ArgumentNullException(nameof(corpoEmail));

            foreach (var field in Values)
            {
                corpoEmail = corpoEmail.Replace(field.Key, field.Value);
                assunto = assunto.Replace(field.Key, field.Value);
            }

            var mail = new MailHelper(emailPara) { Message = { Subject = assunto, Body = corpoEmail } };

            if (Attachments != null && Attachments.Count > 0) // Adiciona anexos se não nulo
                foreach (var attachment in this.Attachments)
                    mail.Message.Attachments.Add(attachment);

            mail.SendMailSes();// Assync

            this.Values.Clear();
        }
    }
}