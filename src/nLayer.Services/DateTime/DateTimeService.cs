﻿namespace nLayer.Services.DateTime;

using DateTime = System.DateTime;

public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.Now;
}