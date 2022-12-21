namespace nLayer.Application.Exceptions;

public class InvalidGenderException : ArgumentException
{
    public InvalidGenderException()
        : base("Invalid gender")
    { }
}
