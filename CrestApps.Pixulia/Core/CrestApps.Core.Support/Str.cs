using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace CrestApps.Core.Support
{
    public class Str
    {
        public static string TitleCase(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        public static string StudlyToSnake(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        }

        public static string Slug(string phrase, int maxLength = 100)
        {
            string str = phrase.RemoveAccent().ToLower();

            // invalid chars          
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");

            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();

            // cut and trim 
            str = str.Substring(0, str.Length <= maxLength ? str.Length : maxLength).Trim();

            // replace spaces with hyphens
            str = Regex.Replace(str, @"\s", "-");

            str = RemoveDuplicate(str, "--", "-").Trim('-');

            return str;
        }


        /// <summary>
        /// Gets a null if the giving string is null or whitespace or a trimmed string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="trimStart"></param>
        /// <param name="trimEnd"></param>
        /// <returns></returns>
        public static string NullOrString(string value, bool trimStart = true, bool trimEnd = true)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            if (trimStart)
            {
                value = value.TrimStart();
            }

            if (trimEnd)
            {
                value = value.TrimEnd();
            }

            return value;
        }

        /// <summary>
        /// Adds a space after each Capital Letter.
        /// "HelloWorldThisIsATest" would then be "Hello World This Is A Test"
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string AddSpacesToWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            return Regex.Replace(text, "([A-Z])([a-z]*)", " $1$2").Trim();
        }

        /// <summary>
        /// Add ordinal to a giving number
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string AddOrdinal(int num)
        {
            if (num <= 0)
            {
                return num.ToString();
            }

            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }

            switch (num % 10)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }

        }


        public static string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        public static string TrimEnd(string subject, string pattern)
        {
            return TrimEnd(subject, pattern, StringComparison.CurrentCulture);
        }

        public static string Merge(params string[] words)
        {
            List<string> valuable = new List<string>();

            foreach (string word in words ?? new string[] { })
            {
                if (string.IsNullOrWhiteSpace(word))
                {
                    continue;
                }

                valuable.Add(word.Trim());
            }

            string sentance = string.Join(" ", valuable);

            return sentance;
        }

        public static string Random(int length = 40)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwzyz";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string ToLower(string str, string defaultValue = "")
        {
            if (str != null)
            {
                return str.ToLower();
            }

            return defaultValue;
        }

        public static string TrimEnd(string subject, string pattern, StringComparison type)
        {
            if (string.IsNullOrWhiteSpace(subject) || subject == pattern)
            {
                return string.Empty;
            }

            if (!string.IsNullOrWhiteSpace(pattern) && subject.EndsWith(pattern, type))
            {
                int index = subject.Length - pattern.Length;

                return subject.Substring(0, index);
            }

            return subject;
        }


        public static int CountOccurrences(string text, string pattern)
        {
            int count = 0;

            int i = 0;

            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }

            return count;
        }

        public static string StringOrNull(string str, bool trim = true)
        {

            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }

            if (trim)
            {
                return str.Trim();
            }

            return str;
        }

        public static string UppercaseFirst(string word, bool lowercaseTheRest = true)
        {
            if (string.IsNullOrEmpty(word))
            {
                return word;
            }

            string final = char.ToUpper(word[0]).ToString();

            if (lowercaseTheRest)
            {
                return final + word.Substring(1).ToLower();
            }

            return final + word.Substring(1);
        }

        public static string AppendOnce(string orginal, string toAppend = "/")
        {
            if (orginal == null || orginal.EndsWith(toAppend))
            {
                return orginal;
            }

            return orginal + toAppend;
        }


        public static string PrependOnce(string orginal, string toAppend = "/")
        {
            if (orginal == null || orginal.StartsWith(toAppend))
            {
                return orginal;
            }

            return toAppend + orginal;
        }

        public static string TrimStart(string subject, string pattern)
        {
            return TrimStart(subject, pattern, StringComparison.CurrentCulture);
        }

        public static string TrimStart(string subject, string pattern, StringComparison type)
        {
            if (string.IsNullOrWhiteSpace(subject) || subject == pattern)
            {
                return string.Empty;
            }

            if (!string.IsNullOrWhiteSpace(pattern) && subject.StartsWith(pattern, type))
            {
                return subject.Substring(pattern.Length);
            }

            return subject;
        }

        public static string NumbersOnly(string input)
        {
            return new string(input.Where(c => char.IsDigit(c)).ToArray());
        }

        public static string SubstringUntil(string str, string until, bool trim = true)
        {
            string substring = str;


            if (str != null && !string.IsNullOrEmpty(until))
            {
                int index = str.IndexOf(until);

                if (index >= 0)
                {
                    substring = str.Substring(0, index);
                }
            }

            if (trim && substring != null)
            {
                substring = substring.Trim();
            }

            return substring;
        }

        public static string ConvertNewLinesToBr(string str, bool isHtml5 = true)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return "";
            }

            string newValue = isHtml5 ? "<br>" : "<br />";

            return str.Replace("\r\n", newValue)
                      .Replace("\n", newValue)
                      .Replace("\r", newValue);
        }

        public static string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        public static string ConvertSecondsToTimeSpan(double seconds)
        {
            var span = TimeSpan.FromSeconds(seconds);

            return span.ToString(@"hh\:mm\:ss\:ff");
        }

        public static string RemoveDuplicate(string subject, string pattern, string replaceWith)
        {
            if (string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(pattern))
            {
                return subject;
            }

            var sub = subject;

            while (sub.IndexOf(pattern) > -1)
            {
                sub = sub.Replace(pattern, replaceWith ?? string.Empty);
            }

            return sub;
        }
    }
}
