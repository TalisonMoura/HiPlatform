using HiPlatfromApi.Entidades.Base;

namespace HiPlatfromApi.Entidades;

public class ProdutoLimpeza : EntidadeBase
{
    public string Nome { get; private set; }
    public decimal Volume { get; private set; }
    public DateTime DataValidade { get; private set; }
    public Guid ElementoEstoqueId { get; private set; }

    #region Propriedades de Navegação
    public ElementoEstoque ElementoEstoque { get; private set; }
    public ICollection<PesquisaMercado> Pesquisas { get; private set; }
    #endregion

    protected ProdutoLimpeza() { }

    public ProdutoLimpeza(string nome, decimal volume, DateTime dataValidade, Guid elementoEstoqueId)
    {
        Nome = nome;
        Volume = volume;
        DataValidade = dataValidade;
        ElementoEstoqueId = elementoEstoqueId;
    }
}