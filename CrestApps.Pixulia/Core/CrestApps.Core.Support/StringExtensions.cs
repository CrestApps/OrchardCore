using System;
using System.Text.RegularExpressions;

namespace CrestApps.Core.Support
{
    public static class StringExtensions
    {
        public static string RemoveAccent(this string txt)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);

            return System.Text.Encoding.ASCII.GetString(bytes);
        }

        public static bool Like(this string toSearch, string toFind)
        {
            var match = new Regex(@"\.|\$|\^|\{|\[|\(|\||\)|\*|\+|\?|\\").Replace(toFind, ch => @"\" + ch)
                                                                         .Replace('_', '.')
                                                                         .Replace("%", ".*");

            return new Regex(@"\A" + match + @"\z", RegexOptions.Singleline).IsMatch(toSearch);
        }

        public static bool Like(this string toSearch, string toFind, StringComparison comparison)
        {
            if (comparison == StringComparison.CurrentCultureIgnoreCase || comparison == StringComparison.OrdinalIgnoreCase || comparison == StringComparison.InvariantCultureIgnoreCase)
            {
                return Like(toSearch.ToLower(), toFind.ToLower());
            }

            return Like(toSearch, toFind);
        }
    }
}
