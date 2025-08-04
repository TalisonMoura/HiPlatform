using HiPlatfromApi.Entidades;
using Microsoft.EntityFrameworkCore;
using HiPlatform.Api.Dados.Mapeamento.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HiPlatform.Api.Dados.Mapeamento
{
    public sealed class ElementoEstoqueMapeamento : ConfiguracaoEntidadeBase<ElementoEstoque>
    {
        public override void Configure(EntityTypeBuilder<ElementoEstoque> builder)
        {
            base.Configure(builder);

            builder.ToTable("Elemento_Estoque");

            builder.Property(e => e.Preco).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(e => e.Custo).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(e => e.CnpjFabricante).HasMaxLength(14).IsRequired();
        }
    }
}