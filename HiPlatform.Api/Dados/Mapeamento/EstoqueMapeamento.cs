using HiPlatfromApi.Entidades;
using Microsoft.EntityFrameworkCore;
using HiPlatform.Api.Dados.Mapeamento.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HiPlatform.Api.Dados.Mapeamento
{
    public sealed class EstoqueMapeamento : ConfiguracaoEntidadeBase<Estoque>
    {
        public override void Configure(EntityTypeBuilder<Estoque> builder)
        {
            base.Configure(builder);

            builder.ToTable("Estoque");

            builder.Property(e => e.Quantidade).IsRequired();

            builder.HasOne(e => e.ElementoEstoque)
                   .WithMany(e => e.Estoques)
                   .HasForeignKey(e => e.ElementoEstoqueId);
        }
    }
}