using Microsoft.AspNetCore.Mvc;
using HiPlatform.Api.Controllers.Base;
using HiPlatform.Api.Servico.Interfaces;

namespace HiPlatform.Api.Controllers;

public sealed class LucroKit : HiPlatformControllerBase
{
    private readonly IDataServico _dataServico;

    public LucroKit(IDataServico dataServico)
    {
        _dataServico = dataServico;
    }

    [HttpGet("listar")]
    public async Task<IActionResult> ListarLucroKitAsync()
    {
        var resultado = await _dataServico.RetornarLucroKitAsync();
        return Ok(resultado);
    }
}