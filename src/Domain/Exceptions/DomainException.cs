using System.Net;
using System.Runtime.Serialization;

namespace Domain.Exceptions;

[Serializable]
public class DomainException : Exception
{
    public int StatusCode { get; set; }
    public ICollection<int>? ErrorCodes { get; set; }
    public IDictionary<string, string[]>? Errors { get; }


    public DomainException() { }

    public DomainException(string message, IDictionary<string, string[]>? errors, ICollection<int>? errorCodes = null, int statusCode = (int)HttpStatusCode.BadRequest) : base(message)
    {
        StatusCode = statusCode;
        ErrorCodes = errorCodes;
        Errors = errors;
    }

    public DomainException(string message, Exception innerException) : base(message, innerException) { }

    protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
