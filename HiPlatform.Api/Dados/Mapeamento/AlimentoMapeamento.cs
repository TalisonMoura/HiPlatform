using HiPlatform.Api.Dados.Mapeamento.Base;
using HiPlatfromApi.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace HiPlatform.Api.Dados.Mapeamento
{
    public sealed class AlimentoMapeamento : ConfiguracaoEntidadeBase<Alimento>
    {
        public override void Configure(EntityTypeBuilder<Alimento> builder)
        {
            base.Configure(builder);

            builder.ToTable("Alimento");

            builder.Property(a => a.DataValidade).IsRequired();
            builder.Property(a => a.Nome).HasMaxLength(200).IsRequired();
            builder.Property(a => a.Peso).HasColumnType("decimal(18,2)").IsRequired();

            builder.HasOne(a => a.ElementoEstoque)
                   .WithMany(e => e.Alimentos)
                   .HasForeignKey(a => a.ElementoEstoqueId);
        }
    }
}