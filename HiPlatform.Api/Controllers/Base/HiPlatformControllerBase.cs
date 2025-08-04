using Microsoft.AspNetCore.Mvc;

namespace HiPlatform.Api.Controllers.Base;

[ApiController]
[Route("api/[controller]")]
[Consumes("application/json")]
[Produces("application/json")]
public abstract class HiPlatformControllerBase : ControllerBase
{
}