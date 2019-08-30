using VirtusGo.Core.Infra.CrossCutting.Mail.Kernel;

namespace VirtusGo.Core.Infra.CrossCutting.Mail
{
    public class NovoUsuarioMail
    {
        public static void EnviarEmail(string toEmail, string emailUsuario, string nomeUsuario, string senha)
        {
            //const string assunto = "(NOME DE FANTASIA DE QUEM CADASTROU)QUER PRESENTEAR VOCÊ 🎁 )";
            const string assunto = "Preparado para a Decolagem com a Virtus?";
            var corpo = TemplateEmails.NovoUsuario;

            var urlSenha = senha;
            var urlUsuario = nomeUsuario;
            var urlEmail = emailUsuario;

            var mail = new EmailManager();
            mail.Values.Add("{UrlNomeUsuario}", urlUsuario);
            mail.Values.Add("{urlEmail}", urlEmail);
            mail.Values.Add("{urlPassword}", urlSenha);
            mail.EnviarEmailSes(assunto, corpo, toEmail);
        }
    }
}
