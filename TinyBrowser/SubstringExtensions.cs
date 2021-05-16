namespace TinyBrowser
{
    static class SubstringExtensions
    {
        /// <summary>
        /// Get string value between [first] a and [last] b.
        /// </summary>
        public static string Between(this string value, string a, string b)
        {
            int posA = value.IndexOf(a);
            int posB = value.LastIndexOf(b);
            if (posA == -1)
            {
                return value;
            }

            if (posB == -1)
            {
                return value;
            }

            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= posB)
            {
                return value;
            }

            return value.Substring(adjustedPosA, posB - adjustedPosA);
        }

    }
}