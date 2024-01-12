using Domain.Commands;
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

        Task<IEnumerable<VeiculoCommands>> GetVeiculosAlugadosAsync();
    }
}
