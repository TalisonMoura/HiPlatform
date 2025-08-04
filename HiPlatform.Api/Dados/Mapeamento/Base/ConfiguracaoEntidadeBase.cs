using HiPlatfromApi.Entidades.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HiPlatform.Api.Dados.Mapeamento.Base
{
    public abstract class ConfiguracaoEntidadeBase<T> : IEntityTypeConfiguration<T> where T : EntidadeBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.DataCriacao)
                       .HasDefaultValueSql("now()")
                       .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
        }
    }
}