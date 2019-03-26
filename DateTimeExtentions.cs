using System;

namespace Extentions
{
    /// <summary>
    /// Класс расширения для конвертации типа DateTime в double
    /// </summary>
    public static class DateTimeExtentions
	{
        /// <summary>
        /// Возвращает дату-время как число double
        /// Например: 25.03.2019 9:14:17 => 20190325091417
        /// </summary>
        /// <param name="value">Дата-время</param>
        /// <returns>Число типа double</returns>
		public static double ConvertDateTimeToDouble(this DateTime value)
		{
			double res = value.Year * Math.Pow(10, 10);
			res += value.Month * Math.Pow(10, 8);
			res += value.Day * Math.Pow(10, 6);
			res += value.Hour * Math.Pow(10, 4);
			res += value.Minute * Math.Pow(10, 2);
			res += value.Second;
			return res;
		}

        /// <summary>
        /// Возвращает тип DateTime из числа типа double
        /// Например: 20190325091417 =>  25.03.2019 9:14:17
        /// </summary>
        /// <param name="value">Число</param>
        /// <returns>Дата-время</returns>
		public static DateTime ConvertDateTimeFromDouble(this double value)
		{
            try
            {
                string str = value.ToString();
                var res = new DateTime(
                    int.Parse(str.Substring(0, 4)),
                    int.Parse(str.Substring(4, 2)),
                    int.Parse(str.Substring(6, 2)),
                    int.Parse(str.Substring(8, 2)),
                    int.Parse(str.Substring(10, 2)),
                    int.Parse(str.Substring(12, 2)));
                return res;
            }
            catch
            {
                throw new DateTimeFormatException(value);
            }
		}

	}

    /// <summary>
    /// Класс ошибки преобразования
    /// </summary>
    public class DateTimeFormatException : Exception
    {
        /// <summary>
        /// Значение
        /// </summary>
        public double DateTimeValue { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="value">Значение дата-время в виде числа с типом double</param>
        public DateTimeFormatException(double value)
            => DateTimeValue = value;

        /// <summary>
        /// Получает сообщение, описывающее текущее исключение.
        /// </summary>
        public override string Message
        {
            get
            {
                return $"Unknown date-time format: {DateTimeValue}";
            }
        }
    }
}