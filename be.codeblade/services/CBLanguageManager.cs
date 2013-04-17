using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using be.codeblade.data;

namespace be.codeblade.services
{
    public static class CBLanguageManager
    {
        public static int toInt32(CBEnumerations.Language lang)
        {
            return Convert.ToInt32(CBLanguageManager.toInt64(lang));
        }

        public static long toInt64(CBEnumerations.Language lang)
        {
            switch (lang)
            {
                case CBEnumerations.Language.nl_BE:
                    return 2067;
                case CBEnumerations.Language.fr_BE:
                    return 2060;
                case CBEnumerations.Language.de_DE:
                    return 1031;
                case CBEnumerations.Language.en_US:
                    return 1033;
                default:
                    return 1033;
            }
        }

        public static string toString(CBEnumerations.Language lang)
        {
            switch (lang)
            {
                case CBEnumerations.Language.nl_BE:
                    return "nl-BE";
                case CBEnumerations.Language.fr_BE:
                    return "fr-BE";
                case CBEnumerations.Language.de_DE:
                    return "de-DE";
                case CBEnumerations.Language.en_US:
                    return "en-US";
                default:
                    return "en-US";
            }
        }

        public static CBEnumerations.Language toEnum(long lang)
        {
            switch (lang)
            {
                case 2067:
                    return CBEnumerations.Language.nl_BE;
                case 2060:
                    return CBEnumerations.Language.fr_BE;
                case 1031:
                    return CBEnumerations.Language.de_DE;
                case 1033:
                    return CBEnumerations.Language.en_US;
                default:
                    return CBEnumerations.Language.en_US;
            }
        }

        public static CBEnumerations.Language toEnum(string lang)
        {
            switch (lang.ToLower())
            {
                case "nl-BE":
                case "nl_BE":
                    return CBEnumerations.Language.nl_BE;
                case "fr-BE":
                case "fr_BE":
                    return CBEnumerations.Language.fr_BE;
                case "en-US":
                case "en_US":
                    return CBEnumerations.Language.en_US;
                case "de-DE":
                case "de_DE":
                    return CBEnumerations.Language.de_DE;
                default:
                    return CBEnumerations.Language.en_US;
            }
        }
    }
}
