using Dapper;
using Domain.Commands;
using Domain.Enums;
using Domain.Interfaces;
using System.Data.SqlClient;

namespace Infrastructure.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        string conexao = @"Server=(localdb)\mssqllocaldb;Database=AluguelVeiculos;Trusted_Connection=True;MultipleActiveResultSets=true";
        public async Task<string> PostAsync(VeiculoCommands command)
        {
            string queryInsert = @"
            INSERT INTO Veiculo(Placa, AnoFabricacao, TipoVeiculoId, Estado, MontadoraId)
            VALUES(@Placa,@AnoFabricacao , @TipoVeiculoId, @Estado, @MontadoraId)";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Execute(queryInsert, new
                {
                    Placa = command.Placa,
                    AnoFabricacao = command.AnodeFabricacao,
                    TipoVeiculoId = (int)command.TipoVeiculo,
                    Estado = command.Estado,
                    MontadoraId = (int)command.Montadora
                });

                return "Veiculo Cadastrado com sucesso";
            }
        }

        public void PostAsync()
        {

        }
        public void GetAsync()
        {

        }

        public async Task<IEnumerable<VeiculoCommands>> GetVeiculosDisponiveis()
        {
            string queryBuscarVeiculosDisponiveis = @"
               SELECT * FROM Veiculo WHERE ALUGADO = 0";
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                return conn.QueryAsync<VeiculoCommands>(
                    queryBuscarVeiculosDisponiveis).Result.ToList();
            }
        }
        public async Task<VeiculoprecoCommad> GetPrecoDiaria(EtipoVeiculo tipoVeiculo)
        {
            string queryGetPrecoDiaria = @"SELECT * FROM VeiculoPreco
                                           WHERE TIPOVEICULO = @TIPOVEICULO";

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                return conn.QueryAsync<VeiculoprecoCommad>(queryGetPrecoDiaria, new
                {
                    TipoVeiculo = tipoVeiculo
                }).Result.FirstOrDefault();

            }
        }
    }
}