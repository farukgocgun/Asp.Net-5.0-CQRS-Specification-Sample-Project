namespace OFG.CqrsSample.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static bool HasValue(this string s)
        {
            return !string.IsNullOrEmpty(s) && !string.IsNullOrWhiteSpace(s);
        }
    }
}
