using System;

namespace DruidDotNet.Helpers
{
    public static class StringExtensions
    {
        public static string ToCamelCase(this string str)
        {
            if (string.IsNullOrWhiteSpace(str) || str.Length < 2)
            {
                return str;
            }

            return Char.ToLowerInvariant(str[0]) + str.Substring(1);
        }
    }
}
