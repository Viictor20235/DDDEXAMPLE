using Domain.Commands;
using Domain.Enums;
using Domain.Interfaces;
using Domain.ViewModel;

namespace Service.Services
{
    public class VeiculoService : IVeiculoService
    {
        //Injeção de dependencia

        private readonly IVeiculoRepository _repository;

        public int PeriodoMaximoAluguel { get; private set; } 

        public VeiculoService(IVeiculoRepository repository)
        {
            _repository = repository;
        }
        public void GetAsync()
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
        public async Task<IEnumerable<VeiculoCommands>> GetVeiculosDisponiveis()
        {
            return await _repository.GetVeiculosDisponiveis();
        }

        public async Task<SimularVeiculoAluguelViewModel> SimularVeiculoAluguel(int totalDiasSimulado, EtipoVeiculo tipoVeiculo)
        {
            var VeiculoPreco = await _repository.GetPrecoDiaria(tipoVeiculo);
            double taxaEstadual = 10.50;
            double taxafederal = 3.5;
            double taxaMunicipal = 13.5;

            var simulacao = new SimularVeiculoAluguelViewModel();
            simulacao.TotalDiasSimulado = totalDiasSimulado;
            simulacao.Taxas = (decimal) (taxaMunicipal + taxaEstadual + taxafederal);
            simulacao.TipoVeiculo= tipoVeiculo;
            simulacao.valordiaria = VeiculoPreco.Preco;

            return simulacao;

            // no servicce, colocar duas validações, se o total de dias simulado for maior que o periodo maximo, deve retorna nuul;

            if (totalDiasSimulado > PeriodoMaximoAluguel) 

            return null;
        }

    }
}
