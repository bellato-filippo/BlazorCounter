
using System.Text.RegularExpressions;

namespace BlazorCounter.Client.Pages;
public static class String
{
    public static string ConvertToLineBreaks(this string inputString)
    {
        Regex regEx = new Regex(@"(\\n|\\r)+");
        return regEx.Replace(inputString, "");
    }
}
