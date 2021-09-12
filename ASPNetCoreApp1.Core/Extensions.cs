using System;

namespace ASPNetCore1.Data
{
    public static class Extensions
    {
        public static bool Contains(this string src, string toCheck, StringComparison comp)
        {
            return src.IndexOf(toCheck, comp) >= 0;
        }
    }
}
