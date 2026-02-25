namespace BestShop.Common.String;
public static class StringConvertor
{
    public static string DecorateStringForRoute(this string value)
    {
        return value.Replace(" ", "_");
    }

    public static string ShortenLongText(this string longText, int maxChar, int thresholdLimitChar, string suffixString="...")
    {
        return
            longText.Length < thresholdLimitChar
            ? longText
            : longText.Substring(0, maxChar) + suffixString;
    }

    public static string Normalize(this string value)
    {
	        var res = value.Trim().ToUpper();
	        return res;
    }
}
