namespace BancoKrt.Exception.ExceptionBase;

public abstract class BancoKrtException(string message) : SystemException(message)
{
    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();

}
