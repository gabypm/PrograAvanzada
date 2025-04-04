using System;

namespace AdvancedProgramming.Architecture.Extensions
{
    public static class StringExtensions
    {
        public static DateTime ToDateTime(this string value)
        {
            return DateTime.Parse(value);
        }
    }
}
