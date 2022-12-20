namespace nLayer.Services.DateTime;

using DateTime = System.DateTime;

public interface IDateTimeService
{
    DateTime Now { get; }
}
