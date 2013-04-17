using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using be.codeblade.data;
using System.Globalization;
using be.codeblade.services;

namespace be.codeblade.extensions
{
    public static class CBDateTimeMethods
    {
        /// <summary>Returns the date in the specified format and language</summary>
        /// <param name="date">The date you need formatted</param>
        /// <param name="format">The format of the date</param>
        /// <param name="lang">The language of the date</param>
        /// <returns>Formatted string of the date</returns>
        public static string ToString(this DateTime date, string format, CBEnumerations.Language lang)
        {
            CultureInfo ci = new CultureInfo(CBLanguageManager.toInt32(lang));
            return date.ToString(format, ci);
        }
    }
}
