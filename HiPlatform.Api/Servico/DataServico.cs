using Dapper;
using Npgsql;
using HiPlatform.Api.Dto;
using HiPlatform.Api.Excecoes;
using HiPlatform.Api.Servico.Interfaces;

namespace HiPlatform.Api.Servico;

public sealed class DataServico : IDataServico
{
    private readonly string _connectionString;

    public DataServico(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<List<DadosKitDTO>> RetornarLucroKitAsync()
    {
        using var connection = new NpgsqlConnection(_connectionString);

        try
        {
            await connection.OpenAsync();

            var query = $@"SELECT
                                pl.""Nome""  AS ""ProdutoLimpezaNome"",
                                a.""Nome""  AS ""AlimentoNome"",
                                ROUND((ee_pl.""Preco"" + ee_a.""Preco"" ) * 0.85, 2) AS ""PrecoKit"",
                                ROUND(((ee_pl.""Preco"" + ee_a.""Preco"") * 0.85) - (ee_pl.""Custo"" + ee_a.""Custo""), 2) AS ""LucroKit"",
                                to_char((a.""DataValidade"" AT TIME ZONE 'America/Sao_Paulo'), 'DD/MM/yyyy HH24:MI:SS') AS ""DataValidadeKit""
                            FROM ""Produto_Limpeza"" pl
                            JOIN ""Elemento_Estoque"" ee_pl ON pl.""ElementoEstoqueId"" = ee_pl.""Id"" 
                            JOIN ""Pesquisa_Mercado"" pm ON pm.""ProdutoLimpezaId"" = pl.""Id""
                            JOIN ""Alimento"" a ON DATE(a.""DataValidade"") <= DATE(NOW() + INTERVAL '5 days')
                            JOIN ""Elemento_Estoque"" ee_a ON a.""ElementoEstoqueId"" = ee_a.""Id"" 
                            WHERE (SELECT AVG(pm2.""Satisfacao"")
                                    FROM ""Pesquisa_Mercado"" pm2
                                    WHERE pm2.""ProdutoLimpezaId"" = pl.""Id"") > 70
                            ORDER BY ""LucroKit"" DESC;";

            return [.. (await connection.QueryAsync<DadosKitDTO>(query))];
        }
        catch (Exception)
        {
            throw new InvalidQueryException("A consulta de dados de kit não está disponivel no momento.");
        }
        finally
        {
            await connection.CloseAsync();
        }
    }
}