namespace SalesPro.Helpers;

public static class DateTimeHelper
{
    public static DateTime GetDateTime(double timestamp)
    {
        return DateTime.UnixEpoch.AddSeconds(timestamp).ToUniversalTime();
    }

    public static double GetTimeStamp(DateTime dateTime)
    {
        return (int)dateTime.Subtract(DateTime.UnixEpoch).TotalSeconds;
    }
}