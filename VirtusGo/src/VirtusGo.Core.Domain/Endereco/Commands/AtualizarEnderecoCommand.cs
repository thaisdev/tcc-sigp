namespace VirtusGo.Core.Domain.Endereco.Commands
{
    public class AtualizarEnderecoCommand : BaseEnderecoCommand
    {
        public AtualizarEnderecoCommand(int id, string logradouro, string numero, string bairro, int cidadeId,
            string cep)
        {
            Id = id;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            CidadeId = cidadeId;
            Cep = cep;
        }
    }
}