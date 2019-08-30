using System;
using VirtusGo.Core.Domain.Core.Events;

namespace VirtusGo.Core.Domain.Empresa.Events
{
    public class EmpresaEventHandler : IHandler<EmpresaRegistradaEvent>, IHandler<EmpresaAtualizadaEvent>, IHandler<EmpresaExcluidaEvent>, IHandler<EmpresaDesativadaEvent>, IHandler<EmpresaReativadaEvent>
    {
        public void Handle(EmpresaRegistradaEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Empresa Registrada com sucesso");
        }

        public void Handle(EmpresaAtualizadaEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Empresa Atualizada com sucesso");
        }

        public void Handle(EmpresaExcluidaEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Empresa Excluída com sucesso");
        }

        public void Handle(EmpresaDesativadaEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Empresa Desativada com sucesso");
        }

        public void Handle(EmpresaReativadaEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Empresa Reativada com sucesso");
        }
    }
}