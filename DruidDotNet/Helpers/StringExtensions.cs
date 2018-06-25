using System;
using System.Linq;

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

        public static string ToSnakeCase(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        }
    }
}
