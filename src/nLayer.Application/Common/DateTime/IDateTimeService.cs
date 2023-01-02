namespace nLayer.Application.Common.DateTime;

using DateTime = System.DateTime;

public interface IDateTimeService
{
    DateTime Now { get; }
}
