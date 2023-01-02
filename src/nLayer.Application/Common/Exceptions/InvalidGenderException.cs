namespace nLayer.Application.Common.Exceptions;

public class InvalidGenderException : ValidationException
{
    public InvalidGenderException(string propertyName)
        : base(propertyName, "Invalid gender")
    { }
}
