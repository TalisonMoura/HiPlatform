using HiPlatfromApi.Entidades.Base;

namespace HiPlatfromApi.Entidades;

public class Alimento : EntidadeBase
{
    public string Nome { get; private set; }
    public decimal Peso { get; private set; }
    public DateTime DataValidade { get; private set; }
    public Guid ElementoEstoqueId { get; private set; }

    #region Propriedades de Navegação
    public ElementoEstoque ElementoEstoque { get; private set; }
    #endregion

    protected Alimento() { }

    public Alimento(string nome, decimal peso, DateTime dataValidade, Guid elementoEstoqueId)
    {
        Nome = nome;
        Peso = peso;
        DataValidade = dataValidade;
        ElementoEstoqueId = elementoEstoqueId;
    }
}