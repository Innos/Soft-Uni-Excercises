using System;
using System.Text;

namespace Extensions
{
    public static class StringbuilderExtensions
    {
        public static string Substring(this StringBuilder str, int start, int length)
        {
            StringBuilder substring = new StringBuilder();
            for (int i = start; i <start + length; i++)
            {
                substring.Append(str[i]);
            }
            return substring.ToString();
        }
    }
}
