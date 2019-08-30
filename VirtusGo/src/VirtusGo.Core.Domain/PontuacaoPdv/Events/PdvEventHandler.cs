using System;
using VirtusGo.Core.Domain.Core.Events;

namespace VirtusGo.Core.Domain.PontuacaoPdv.Events
{
    public class PdvEventHandler : IHandler<PdvExcluidoEvent>, IHandler<PdvAprovadoEvent>
    {
        public void Handle(PdvExcluidoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pontuacao PDV Excluído com sucesso");
        }

        public void Handle(PdvAprovadoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pontuacao PDV Aprovado com sucesso");
        }
    }
}