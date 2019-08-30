using System;
using VirtusGo.Core.Domain.Core.Events;

namespace VirtusGo.Core.Domain.Faixas.Events
{
    public class FaixaEventHandler : Event, IHandler<FaixaRegistradaEvent>, IHandler<FaixaAtualizadaEvent>, IHandler<FaixaExcluidaEvent>
    {
        public void Handle(FaixaRegistradaEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Faixa Registrada com sucesso");
        }

        public void Handle(FaixaAtualizadaEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Faixa Atualizada com sucesso");
        }

        public void Handle(FaixaExcluidaEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Faixa Excluida com sucesso");
        }
    }
}