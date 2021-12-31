using System;
using System.Globalization;

namespace Yalikh.Utils.Text
{
    /// <summary>
    /// Contains extensions for string comparing like StartsWith, Endswith, etc
    /// </summary>
    public static class StringCompareHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="culture"></param>
        /// <param name="subStrings"></param>
        /// <returns></returns>
        public static bool EndsWith(this string self, bool ignoreCase, CultureInfo? culture , params string[] subStrings)
        {
            foreach (var substr in subStrings)
            {
                if (self.EndsWith(substr, ignoreCase, culture))
                    return true;
            }

            return false;
        }

        public static bool EndsWith(this string self, StringComparison comparisonType, params string[] subStrings)
        {
            foreach (var substr in subStrings)
            {
                if (self.EndsWith(substr, comparisonType))
                    return true;
            }

            return false;
        }

        public static bool EndsWith(this string self, params string[] subStrings)
        {
            foreach (var substr in subStrings)
            {
                if (self.EndsWith(substr))
                    return true;
            }

            return false;
        }

        public static bool EndsWith(this string self, params char[] chars)
        {
            foreach (var chr in chars)
            {
                if (self.EndsWith(chr))
                    return true;
            }

            return false;
        }

        public static bool StartsWith(this string self, bool ignoreCase, CultureInfo? culture, params string[] subStrings)
        {
            foreach (var substr in subStrings)
            {
                if (self.StartsWith(substr, ignoreCase, culture))
                    return true;
            }

            return false;
        }

        public static bool StartsWith(this string self, StringComparison comparisonType, params string[] subStrings)
        {
            foreach (var substr in subStrings)
            {
                if (self.StartsWith(substr, comparisonType))
                    return true;
            }

            return false;
        }

        public static bool StartsWith(this string self, params string[] subStrings)
        {
            foreach (var substr in subStrings)
            {
                if (self.StartsWith(substr))
                    return true;
            }

            return false;
        }

        public static bool StartsWith(this string self, params char[] chars)
        {
            foreach (var chr in chars)
            {
                if (self.StartsWith(chr))
                    return true;
            }

            return false;
        }

    }
}
