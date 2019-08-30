using System;
using VirtusGo.Core.Domain.Core.Events;

namespace VirtusGo.Core.Domain.CotacaoPontos.Events
{
    public class CotacaoPontosEventHandler : IHandler<CotacaoPontosRegistradoEvent>, IHandler<CotacaoPontosAtualizadaEvent>, IHandler<CotacaoPontosExcluidoEvent>, IHandler<CotacaoDesativadaEvent>
    {
        public void Handle(CotacaoPontosRegistradoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cotação Registrada com sucesso");
        }

        public void Handle(CotacaoPontosAtualizadaEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cotação Atualizada com sucesso");
        }

        public void Handle(CotacaoPontosExcluidoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cotação Excluída com sucesso");
        }

        public void Handle(CotacaoDesativadaEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cotação Desativada com sucesso");
        }
    }
}