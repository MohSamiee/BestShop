using System.Globalization;
namespace BestShop.Common.Converter;
public static class DateConverter
{
	public static string ToPersianDate(this DateTime value, string dateDelimeter = "/")
	{
		PersianCalendar pc = new ();
		var persianDate = 
			pc.GetYear(value) + dateDelimeter + 
			pc.GetMonth(value).ToString("00") + dateDelimeter + 
			pc.GetDayOfMonth(value).ToString("00");

		return persianDate;
	}

	public static string ToPersianDateWithTime(this DateTime value, string dateDelimeter = "/")
	{
		var persianDate = value.ToPersianDate();
		var time =
			value.Hour.ToString("00") + ":" +
			value.Minute.ToString("00");

		var longTime = persianDate + " - " + time;
		return longTime;
	}
}
