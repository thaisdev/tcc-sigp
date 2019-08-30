using VirtusGo.Core.Infra.CrossCutting.Mail.Kernel;

namespace VirtusGo.Core.Infra.CrossCutting.Mail
{
    public class RecuperarSenhaMail
    {
        public static void EnviarEmail(string toEmail, string emailUsuario, string nomeUsuario, string link)
        {
            const string assunto = "Alguém pediu ajuda com a senha?";
            var corpo = TemplateEmails.RecuperarSenha;

            var urlLink = link;
            var urlUsuario = nomeUsuario;
            var urlEmail = emailUsuario;

            var mail = new EmailManager();
            mail.Values.Add("{UrlNomeUsuario}", urlUsuario);
            mail.Values.Add("{urlEmail}", urlEmail);
            mail.Values.Add("{urlLink}", urlLink);
            mail.EnviarEmailSes(assunto, corpo, toEmail);
        }
    }
}
