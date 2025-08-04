using Microsoft.EntityFrameworkCore;

namespace HiPlatform.Api.Dados
{
    public static class ConfiguracaoContexto
    {
        public static async Task AtualizarBancoDeDadosAsync(this IApplicationBuilder app, IHostEnvironment environment)
        {
            if (!environment.IsProduction())
            {
                using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
                using var contexto = serviceScope?.ServiceProvider.GetService<AplicacaoDbContexto>();
                await contexto?.Database.MigrateAsync();
            }
        }
    }
}