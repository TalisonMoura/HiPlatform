namespace HiPlatfromApi.Entidades.Base;

public abstract class EntidadeBase
{
    public Guid Id { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public DateTime? DataModificacao { get; private set; }

    protected EntidadeBase()
    {
        Id = Guid.NewGuid();
        DataCriacao = DateTime.UtcNow;
    }
}