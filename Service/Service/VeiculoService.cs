using Domain.Commands;
using Domain.Enums;
using Domain.Interfaces;

namespace Service.Services
{
    public class VeiculoService : IVeiculoService
    {
        //Injeção de dependencia

        private readonly IVeiculoRepository _repository;

        public VeiculoService(IVeiculoRepository repository)
        {
            _repository = repository;
        }
        public void GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VeiculoCommands>> GetVeiculosAlugadosAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> PostAsync(VeiculoCommands command)
        {
            if (command == null)
                return "Todos os Campos são Obrigatórios";

            int anoAtual = DateTime.Now.Year;
            if (anoAtual - command.AnodeFabricacao > 5)
                return "O Ano do veículo é menor que o permitido";

            if (command.TipoVeiculo != EtipoVeiculo.SUV
               && command.TipoVeiculo != EtipoVeiculo.Hatch
               && command.TipoVeiculo != EtipoVeiculo.Sedan
            )
                return "O Tipo de Veículo não pe permitido";

            return await _repository.PostAsync(command);
        }

        public void PostAsync()
        {
            throw new NotImplementedException();
        }
    }
}
