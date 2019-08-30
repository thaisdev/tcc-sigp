using System;
using VirtusGo.Core.Domain.Core.Events;

namespace VirtusGo.Core.Domain.Beneficiarios.Events
{
    public class BeneficiarioEventHandler : IHandler<BeneficiarioRegistradoEvent>,
        IHandler<BeneficiarioExcluidoEvent>, IHandler<BeneficiarioAtualizadoEvent>, IHandler<BeneficiarioDesativadoEvent>, IHandler<BeneficiarioReativadoEvent>
    {
        public void Handle(BeneficiarioRegistradoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Beneficiario Registrado com sucesso");
        }

        public void Handle(BeneficiarioExcluidoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Beneficiario Excluído com sucesso");
        }

        public void Handle(BeneficiarioAtualizadoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Beneficiario Atualizado com sucesso");
        }

        public void Handle(BeneficiarioDesativadoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Beneficiario Desativado com sucesso");
        }

        public void Handle(BeneficiarioReativadoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Beneficiario Reativado com sucesso");
        }
    }
}