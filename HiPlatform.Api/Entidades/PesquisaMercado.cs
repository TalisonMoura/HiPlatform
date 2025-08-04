using HiPlatfromApi.Entidades.Base;

namespace HiPlatfromApi.Entidades;

public class PesquisaMercado : EntidadeBase
{
    public int Satisfacao { get; private set; }
    public string InstitutoPesquisa { get; private set; }
    public Guid ProdutoLimpezaId { get; private set; }

    #region Propriedades de Navegação
    public ProdutoLimpeza ProdutoLimpeza { get; private set; }
    #endregion

    protected PesquisaMercado() { }

    public PesquisaMercado(int satisfacao, string institutoPesquisa, Guid produtoLimpezaId)
    {
        Satisfacao = satisfacao;
        InstitutoPesquisa = institutoPesquisa;
        ProdutoLimpezaId = produtoLimpezaId;
    }
}