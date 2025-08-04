using HiPlatfromApi.Entidades.Base;

namespace HiPlatfromApi.Entidades;

public class ElementoEstoque : EntidadeBase
{
    public decimal Preco { get; private set; }
    public decimal Custo { get; private set; }
    public string CnpjFabricante { get; private set; }

    #region Propriedades de Navegação
    public ICollection<Estoque> Estoques { get; private set; }
    public ICollection<Alimento> Alimentos { get; private set; }
    public ICollection<ProdutoLimpeza> ProdutosLimpeza { get; private set; }
    #endregion

    protected ElementoEstoque() { }

    public ElementoEstoque(decimal preco, string cnpjFabricante, decimal custo)
    {
        Preco = preco;
        Custo = custo;
        CnpjFabricante = cnpjFabricante;
    }
}