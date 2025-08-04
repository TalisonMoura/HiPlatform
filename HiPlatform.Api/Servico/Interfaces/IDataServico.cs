using HiPlatform.Api.Dto;

namespace HiPlatform.Api.Servico.Interfaces
{
    public interface IDataServico
    {
        Task<List<DadosKitDTO>> RetornarLucroKitAsync();
    }
}