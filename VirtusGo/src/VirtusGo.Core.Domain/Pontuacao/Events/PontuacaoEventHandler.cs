using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Events;

namespace VirtusGo.Core.Domain.Pontuacao.Events
{
    public class PontuacaoEventHandler : IHandler<PontuacaoRegistradaEvent>, IHandler<PontuacaoAtualizadaEvent>, IHandler<PontuacaoExcluidaEvent>, IHandler<PontuacaoDesativadaEvent>
    {
        public void Handle(PontuacaoRegistradaEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pontuação Registrada com sucesso");
        }

        public void Handle(PontuacaoAtualizadaEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pontuação Atualizada com sucesso");
        }

        public void Handle(PontuacaoExcluidaEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pontuação Excluída com sucesso");
        }

        public void Handle(PontuacaoDesativadaEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pontuação Desativada com sucesso");
        }
    }
}
