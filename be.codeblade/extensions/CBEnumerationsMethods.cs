using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using be.codeblade.data;
using be.codeblade.services;

namespace be.codeblade.extensions
{
    public static class CBEnumerationsMethods
    {
        public static string toString(this CBEnumerations.Language lang)
        {
            return CBLanguageManager.toString(lang);
        }
    }
}
