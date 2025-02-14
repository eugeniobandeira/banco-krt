using System.Net;

namespace BancoKrt.Exception.ExceptionBase;

public class BadRequestException : BancoKrtException
{

    public BadRequestException(string message) : base(message) { }

    public override int StatusCode
        => (int)HttpStatusCode.BadRequest;

    public override List<string> GetErrors()
    {
        return new List<string>() { Message };
    }
}
