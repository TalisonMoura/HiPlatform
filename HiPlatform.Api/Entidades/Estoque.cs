using HiPlatfromApi.Entidades.Base;

namespace HiPlatfromApi.Entidades;

public class Estoque : EntidadeBase
{
    public int Quantidade { get; private set; }
    public Guid ElementoEstoqueId { get; private set; }

    #region Propriedades de Navegação
    public ElementoEstoque ElementoEstoque { get; private set; }
    #endregion

    protected Estoque() { }

    public Estoque(int quantidade, Guid elementoEstoqueId)
    {
        Quantidade = quantidade;
        ElementoEstoqueId = elementoEstoqueId;
    }
}