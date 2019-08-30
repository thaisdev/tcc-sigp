using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Infra.CrossCutting.Mail.Kernel;

namespace VirtusGo.Core.Infra.CrossCutting.Mail
{
    public class LancamentoPontosMail
    {
        public static void EnviarEmail(string toEmail, string beneficiado, string parceiro)
        {
            //const string assunto = "(NOME DE FANTASIA DE QUEM CADASTROU)QUER PRESENTEAR VOCÊ 🎁 )";
            string assunto = parceiro + " Patrocinou VIRTUS|Coins para você! 💴";
            var corpo = TemplateEmails.LancamentoPontos;

            var urlNomeBeneficiario = beneficiado;
            var urlParceiro = parceiro;

            var mail = new EmailManager();
            mail.Values.Add("{urlParceiro}", urlParceiro);
            mail.Values.Add("{urlNomeBeneficiado}", urlNomeBeneficiario);
            mail.EnviarEmailSes(assunto, corpo, toEmail);
        }
    }
}