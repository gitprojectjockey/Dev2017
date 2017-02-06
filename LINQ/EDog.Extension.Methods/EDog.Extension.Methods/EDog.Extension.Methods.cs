using System;
using System.Collections.Generic;
using System.Linq;

namespace EDog.Extension.Methods
{
    public static class NumericsExt
    {
        public static bool IsBetween(this int value, int min, int max)
        {
            return value >= min && value <= max;
        }

        public static bool IsBetween(this double value, double min, double max)
        {
            return value >= min && value <= max;
        }

        public static bool IsBetween(this short value, short min, short max)
        {
            return value >= min && value <= max;
        }

        public static bool IsBetween(this long value, long min, long max)
        {
            return value >= min && value <= max;
        }

    }

    public static class StringExt
    {
        public static string UppercaseFirstLetter(this string value)
        {
            if (value.Length > 0)
            {
                char[] array = value.ToCharArray();
                array[0] = char.ToUpper(array[0]);
                return new string(array);
            }
            return value;
        }
    }

    public static class DateExt
    {
        public static int GetDaysBetweenDates(this string firstDate, string secondDate)
        {
            DateTime returnValue;
            DateTime start = DateTime.TryParse(firstDate, out returnValue)
                ? DateTime.Parse(firstDate)
                : returnValue;

            DateTime end = DateTime.TryParse(secondDate, out returnValue)
                ? DateTime.Parse(secondDate)
                : returnValue;

            return end.Subtract(start).Days;
        }
    }


    public static class QueryClause
    {
        public static IEnumerable<t> DistinctBy<t>(this IEnumerable<t> list, Func<t, object> propertySelector)
        {
            return list.GroupBy(propertySelector).Select(x => x.First());
        }
    }
}


