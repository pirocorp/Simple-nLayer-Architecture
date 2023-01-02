namespace nLayer.Application.Exceptions;

public class ValidationException : Exception
{
    public ValidationException()
        : base("One or more validation failures have occurred.")
    {
        this.Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(string propertyName, params string[] messages)
        : this()
    {
        this.Errors.Add(propertyName, messages);
    }

    public IDictionary<string, string[]> Errors { get; }
}
