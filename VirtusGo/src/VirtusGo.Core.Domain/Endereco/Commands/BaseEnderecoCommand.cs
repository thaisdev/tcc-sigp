using VirtusGo.Core.Domain.Core.Command;

namespace VirtusGo.Core.Domain.Endereco.Commands
{
    public class BaseEnderecoCommand : Command
    {
        public int Id { get; protected set; }
        public string Logradouro { get; protected set; }
        public string Numero { get; protected set; }
        public string Bairro { get; protected set; }
        public int CidadeId { get; protected set; }
        public string Cep { get; protected set; }
    }
}