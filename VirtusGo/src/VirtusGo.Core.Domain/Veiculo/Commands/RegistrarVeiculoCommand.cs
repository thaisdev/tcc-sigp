namespace VirtusGo.Core.Domain.Veiculo.Commands
{
    public class RegistrarVeiculoCommand : BaseVeiculoCommand
    {
        public RegistrarVeiculoCommand(int id, string placa, string modelo, string cor, string marca, string renavam)
        {
            Id = id;
            Placa = placa;
            Modelo = modelo;
            Cor = cor;
            Marca = marca;
            Renavam = renavam;

            AggregateId = id;
        }
    }
}