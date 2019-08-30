using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Infra.CrossCutting.Mail.Kernel;

namespace VirtusGo.Core.Infra.CrossCutting.Mail
{
    public class NovoBeneficiarioMail
    {
        public static void EnviarEmail(string toEmail, BeneficiarioViewModel model, string operador)
        {
            //const string assunto = "(NOME DE FANTASIA DE QUEM CADASTROU)QUER PRESENTEAR VOCÊ 🎁 )";
            const string assunto = "VIRTUS LOYALTY QUER PRESENTEAR VOCÊ 🎁";
            var corpo = TemplateEmails.NovoBeneficiario;

            var urlNomeBeneficiario = model.Nome;
            var urlNomeOperador = operador;

            var mail = new EmailManager();
            mail.Values.Add("{urlNomeBeneficiario}", urlNomeBeneficiario);
            mail.Values.Add("{urlNomeOperador}", urlNomeOperador);
            mail.EnviarEmailSes(assunto, corpo, toEmail);
        }
    }
}