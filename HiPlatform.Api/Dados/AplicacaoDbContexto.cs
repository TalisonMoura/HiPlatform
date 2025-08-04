using HiPlatfromApi.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace HiPlatform.Api.Dados
{
    public sealed class AplicacaoDbContexto : DbContext
    {
        private readonly string _connectionString;

        public AplicacaoDbContexto(DbContextOptions<AplicacaoDbContexto> options, IConfiguration configuration) : base(options)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseNpgsql(_connectionString, ctxOptsBuilder => ctxOptsBuilder.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(5), errorCodesToAdd: null));

            GerarSeedBanco(optionsBuilder);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AplicacaoDbContexto).Assembly);
        }

        private static void GerarSeedBanco(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseAsyncSeeding(async (contexto, _, cancellationToken) =>
            {
                if((await contexto.Set<ElementoEstoque>().FirstOrDefaultAsync(cancellationToken)) is null)
                {
                    var elementosEstoque = new List<ElementoEstoque>()
                    {
                        new(15.87m, 8.49m, "24523310000179"),
                        new(11.57m, 10.26m, "44344809000134"),
                        new(6.11m, 4.18m, "43235937000195"),
                        new(5.44m, 3.61m, "23644097000189"),
                        new(8.99m, 6.73m, "14817090000147"),
                        new(19.63m, 10.99m, "42565704000131"),
                        new(10.17m, 8.42m, "92204434000180"),
                        new(16.00m, 13.51m, "64749308000193"),
                        new(8.83m, 4.95m, "10926865000172"),
                        new( 15.08m, 8.05m, "96792370000152")
                    };
                    await contexto.Set<ElementoEstoque>().AddRangeAsync(elementosEstoque, cancellationToken);


                    await contexto.Set<Estoque>().AddRangeAsync(new Estoque(38, elementosEstoque[0].Id),
                                                                new Estoque(101, elementosEstoque[1].Id),
                                                                new Estoque(39, elementosEstoque[2].Id),
                                                                new Estoque(72, elementosEstoque[3].Id),
                                                                new Estoque(101, elementosEstoque[4].Id),
                                                                new Estoque(50, elementosEstoque[5].Id),
                                                                new Estoque(34, elementosEstoque[6].Id),
                                                                new Estoque(195, elementosEstoque[7].Id),
                                                                new Estoque(27, elementosEstoque[8].Id),
                                                                new Estoque(82, elementosEstoque[9].Id));

                    await contexto.Set<Alimento>().AddRangeAsync(new Alimento("Alimento 1", 1.22m, DateTime.UtcNow.AddDays(15), elementosEstoque[0].Id),
                                                                 new Alimento("Alimento 3", 0.93m, DateTime.UtcNow.AddDays(3), elementosEstoque[2].Id),
                                                                 new Alimento("Alimento 5", 1.05m, DateTime.UtcNow.AddDays(3), elementosEstoque[4].Id),
                                                                 new Alimento("Alimento 7", 0.96m, DateTime.UtcNow.AddDays(3), elementosEstoque[6].Id),
                                                                 new Alimento("Alimento 9", 1.0m, DateTime.UtcNow.AddDays(4), elementosEstoque[8].Id));

                    var produtosLimpeza = new List<ProdutoLimpeza>()
                    {
                        new("Produto Limpeza 2", 1.07m, DateTime.UtcNow.AddDays(133), elementosEstoque[1].Id),
                        new("Produto Limpeza 4", 2.79m, DateTime.UtcNow.AddDays(135), elementosEstoque[3].Id),
                        new("Produto Limpeza 6", 0.65m, DateTime.UtcNow.AddDays(35), elementosEstoque[5].Id),
                        new("Produto Limpeza 8", 2.34m, DateTime.UtcNow.AddDays(139), elementosEstoque[7].Id),
                        new("Produto Limpeza 10", 1.88m, DateTime.UtcNow.AddDays(149), elementosEstoque[9].Id)
                    };
                    await contexto.Set<ProdutoLimpeza>().AddRangeAsync(produtosLimpeza, cancellationToken);

                    await contexto.Set<PesquisaMercado>().AddRangeAsync(new PesquisaMercado(65, "IBR", produtosLimpeza[0].Id),
                                                                        new PesquisaMercado(72, "IBR", produtosLimpeza[0].Id),
                                                                        new PesquisaMercado(77, "Datafolha", produtosLimpeza[1].Id),
                                                                        new PesquisaMercado(67, "IBOPE", produtosLimpeza[1].Id),
                                                                        new PesquisaMercado(61, "XP Research", produtosLimpeza[2].Id),
                                                                        new PesquisaMercado(88, "Datafolha", produtosLimpeza[2].Id),
                                                                        new PesquisaMercado(60, "Datafolha", produtosLimpeza[3].Id),
                                                                        new PesquisaMercado(76, "Datafolha", produtosLimpeza[3].Id),
                                                                        new PesquisaMercado(86, "Datafolha", produtosLimpeza[4].Id),
                                                                        new PesquisaMercado(65, "IBR", produtosLimpeza[4].Id));

                    await contexto.SaveChangesAsync(cancellationToken);
                }
            });
        }
    }
}