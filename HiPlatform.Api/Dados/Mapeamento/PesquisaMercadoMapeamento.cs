using HiPlatfromApi.Entidades;
using Microsoft.EntityFrameworkCore;
using HiPlatform.Api.Dados.Mapeamento.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HiPlatform.Api.Dados.Mapeamento
{
    public sealed class PesquisaMercadoMapeamento : ConfiguracaoEntidadeBase<PesquisaMercado>
    {
        public override void Configure(EntityTypeBuilder<PesquisaMercado> builder)
        {
            base.Configure(builder);

            builder.ToTable("Pesquisa_Mercado");

            builder.Property(p => p.Satisfacao).IsRequired();
            builder.Property(p => p.InstitutoPesquisa).HasMaxLength(200).IsRequired();

            builder.HasOne(p => p.ProdutoLimpeza)
                   .WithMany(pl => pl.Pesquisas)
                   .HasForeignKey(p => p.ProdutoLimpezaId);
        }
    }
}