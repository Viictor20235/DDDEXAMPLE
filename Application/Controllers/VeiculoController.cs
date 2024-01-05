using Domain.Commands;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;
        public VeiculoController (IVeiculoService veiculoService) 
        {
             _veiculoService = veiculoService;
        }
        [HttpPost]
        [Route("CadastrarVeiculo")]
        public Async Task<IActionResult> PostAsy ([FromBody] VeiculoCommands commad)
        {
            await _veiculoService.PostAsync(commad);

            return Ok();

        }
        [HttpGet]
        [Route("SimularAluguel")]
        public IActionResult  GetAsync()
        {
            return Ok();

        }
        [HttpPost]
        [Route("Alugar")]
        public IActionResult PostAsync()
        {
            return Ok();

        }
    }
}
