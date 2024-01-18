using Domain.Commands;
using Domain.Enums;

namespace Domain.Interfaces
{
    public interface IVeiculoRepository
    {
        Task<string> PostAsync(VeiculoCommands command);
        void PostAsync();
        void GetAsync();
        Task<IEnumerable<VeiculoCommands>> GetVeiculosDisponiveis();
        Task<VeiculoprecoCommad> GetPrecoDiaria(EtipoVeiculo TipoVeiculo);

    }

}
