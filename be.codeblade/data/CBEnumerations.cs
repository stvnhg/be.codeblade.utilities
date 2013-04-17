
namespace be.codeblade.data
{
    /// <summary>Choose one of the enumerations</summary>
    public static class CBEnumerations
    {
        /// <summary>Select one of the languages</summary>
        public enum Language
        {
            /// <summary>Dutch (Belgium)</summary>
            nl_BE,

            /// <summary>French (Belgium)</summary>
            fr_BE,

            /// <summary>English (United States)</summary>
            en_US,

            /// <summary>German (Germany)</summary>
            de_DE
        }

        public enum OGoneEnvironmentType
        {
            TEST,
            PROD
        }

        public enum OGoneOperations 
        {
            RES,
            SAL,
            RFD
        }
    }
}
