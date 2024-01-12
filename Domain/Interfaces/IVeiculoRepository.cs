using Domain.Commands;

namespace Domain.Interfaces
{
    public interface IVeiculoRepository
    {
        Task<string> PostAsync(VeiculoCommands command);
        void PostAsync();
        void GetAsync();
    }
}
