using System;
using VirtusGo.Core.Domain.Core.Events;

namespace VirtusGo.Core.Domain.Unidades.Events
{
    public class UnidadeEventHandler : IHandler<UnidadeRegistradaEvent>,IHandler<UnidadeAtualizadaEvent>, IHandler<UnidadeExcluidaEvent>, IHandler<UnidadeDesativadaEvent>, IHandler<UnidadeReativadaEvent>
    {
        public void Handle(UnidadeRegistradaEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Unidade Registrada com sucesso");
        }

        public void Handle(UnidadeAtualizadaEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Unidade Registrada com sucesso");
        }

        public void Handle(UnidadeExcluidaEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Unidade Registrada com sucesso");
        }

        public void Handle(UnidadeDesativadaEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Unidade Desativada com sucesso");
        }

        public void Handle(UnidadeReativadaEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Unidade Reativada com sucesso");
        }
    }
}