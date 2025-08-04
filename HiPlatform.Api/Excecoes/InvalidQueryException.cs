using HiPlatform.Api.Excecoes.Base;

namespace HiPlatform.Api.Excecoes;

public sealed class InvalidQueryException : HiPlatfromExceptionBase
{
    public InvalidQueryException(string message) : base(message)
    {
    }
}