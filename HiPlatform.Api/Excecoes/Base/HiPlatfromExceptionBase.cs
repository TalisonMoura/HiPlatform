namespace HiPlatform.Api.Excecoes.Base
{
    public abstract class HiPlatfromExceptionBase : SystemException
    {
        protected HiPlatfromExceptionBase(string message) : base(message) { }
    }
}
