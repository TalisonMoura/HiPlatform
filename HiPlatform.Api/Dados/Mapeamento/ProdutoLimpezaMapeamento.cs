using HiPlatfromApi.Entidades;
using Microsoft.EntityFrameworkCore;
using HiPlatform.Api.Dados.Mapeamento.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HiPlatform.Api.Dados.Mapeamento
{
    public sealed class ProdutoLimpezaMapeamento : ConfiguracaoEntidadeBase<ProdutoLimpeza>
    {
        public override void Configure(EntityTypeBuilder<ProdutoLimpeza> builder)
        {
            base.Configure(builder);

            builder.ToTable("Produto_Limpeza");

            builder.Property(p => p.DataValidade).IsRequired();
            builder.Property(p => p.Nome).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Volume).HasColumnType("decimal(18,2)").IsRequired();

            builder.HasOne(p => p.ElementoEstoque)
                   .WithMany(e => e.ProdutosLimpeza)
                   .HasForeignKey(p => p.ElementoEstoqueId);
        }
    }
}