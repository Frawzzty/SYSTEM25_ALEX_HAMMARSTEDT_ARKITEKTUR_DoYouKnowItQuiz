using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Application.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Makes all words first letter uppercase
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string WordsFirstUpper(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }
    }
}
