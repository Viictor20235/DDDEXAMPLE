using Domain.Commands;
using Domain.Enums;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
     public interface IVeiculoService 
     { 
        Task <string> PostAsync(VeiculoCommands commad);

        void PostAsync();

        void GetAsync();

        Task<IEnumerable<VeiculoCommands>> GetVeiculosDisponiveis();
        Task<SimularVeiculoAluguelViewModel> SimularVeiculoAluguel(int TotalDiasSimulado, EtipoVeiculo TipoVeiculo);
    }
}

