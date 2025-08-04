namespace HiPlatform.Api.Dto
{
    public record DadosKitDTO
    {
        public string ProdutoLimpezaNome { get; set; }
        public string AlimentoNome { get; set; }
        public decimal PrecoKit { get; set; }
        public decimal LucroKit { get; set; }
        public string DataValidadeKit { get; set; }
    }
}