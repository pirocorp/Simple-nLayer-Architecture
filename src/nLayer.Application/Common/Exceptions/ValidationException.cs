namespace nLayer.Application.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationException()
        : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(string propertyName, params string[] messages)
        : this()
    {
        Errors.Add(propertyName, messages);
    }

    public IDictionary<string, string[]> Errors { get; }
}
