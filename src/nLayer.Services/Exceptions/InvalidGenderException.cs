namespace nLayer.Services.Exceptions;

public class InvalidGenderException : ArgumentException
{
    public InvalidGenderException()
        : base("Invalid gender")
    { }
}
