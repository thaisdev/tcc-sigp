using System;
using VirtusGo.Core.Domain.Core.Events;

namespace VirtusGo.Core.Domain.Parametro.Event
{
    public class ParametroEvenHandler : IHandler<ParametroRegistradoEvent>, IHandler<ParametroAtualizadoEvent>, IHandler<ParametroDesativadoEvent>
    {
        public void Handle(ParametroRegistradoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Parâmetro Registrado com sucesso");
        }

        public void Handle(ParametroAtualizadoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Parâmetro Atualizado com sucesso");
        }

        public void Handle(ParametroDesativadoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Parâmetro Desativado com sucesso");
        }
    }
}