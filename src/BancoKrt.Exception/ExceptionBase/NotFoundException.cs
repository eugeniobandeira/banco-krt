using System.Net;

namespace BancoKrt.Exception.ExceptionBase;

public class NotFoundException : BancoKrtException
{
    public NotFoundException(string message) : base(message) { }

    public override int StatusCode 
        => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        return new List<string>() { Message };
    }
}
