using System.Text;
using System.Text.RegularExpressions;

namespace CloudAwesome.Pbi.SourceControl
{
    public static class ExtensionMethods
    {
        public static string ToValidFileName(this string inputString)
        {
            var validNameChars = new Regex("[A-Z0-9_-]", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            var result = new StringBuilder();
            foreach (var match in validNameChars.Matches(inputString))
            {
                result.Append(match);
            }

            return result.ToString().Trim();
        }
    }
}
