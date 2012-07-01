namespace BookStore.Core.Utils
{
    using System;
    using System.IO;
    using System.Web.Util;
    using Microsoft.Security.Application;

    public class AntiXssEncoder : HttpEncoder
    {
        public AntiXssEncoder() 
        {
        }

        protected override void HtmlEncode(string value, TextWriter output)
        {
            output.Write(AntiXss.HtmlEncode(value));
        }

        protected override void HtmlAttributeEncode(string value, TextWriter output)
        {
            output.Write(AntiXss.HtmlAttributeEncode(value));
        }

        protected override void HtmlDecode(string value, TextWriter output)
        {
            base.HtmlDecode(value, output);
        }

        protected override byte[] UrlEncode(byte[] bytes, int offset, int count)
        {
            int cSpaces = 0;
            int cUnsafe = 0;

            for (int i = 0; i < count; i++)
            {
                char ch = (char)bytes[offset + i];

                if (ch == ' ')
                    cSpaces++;
                else if (!IsUrlSafeChar(ch))
                    cUnsafe++;
            }

            if (cSpaces == 0 && cUnsafe == 0)
                return bytes;

            byte[] expandedBytes = new byte[count + cUnsafe * 2];
            int pos = 0;

            for (int i = 0; i < count; i++)
            {
                byte b = bytes[offset + i];
                char ch = (char)b;

                if (IsUrlSafeChar(ch))
                {
                    expandedBytes[pos++] = b;
                }
                else if (ch == ' ')
                {
                    expandedBytes[pos++] = (byte)'+';
                }
                else
                {
                    expandedBytes[pos++] = (byte)'%';
                    expandedBytes[pos++] = (byte)IntToHex((b >> 4) & 0xf);
                    expandedBytes[pos++] = (byte)IntToHex(b & 0x0f);
                }
            }

            return expandedBytes;


        }

        protected override string UrlPathEncode(string value)
        {
            string[] parts = value.Split("?".ToCharArray());
            string originalPath = parts[0];

            string originalQueryString = null;
            if (parts.Length == 2)
                originalQueryString = "?" + parts[1];

            string[] pathSegments = originalPath.Split("/".ToCharArray());

            for (int i = 0; i < pathSegments.Length; i++)
            {
                pathSegments[i] = AntiXss.UrlEncode(pathSegments[i]);  
            }

            return String.Join("/", pathSegments) + originalQueryString;
        }

        private bool IsUrlSafeChar(char ch)
        {
            if (ch >= 'a' && ch <= 'z' || ch >= 'A' && ch <= 'Z' || ch >= '0' && ch <= '9')
                return true;

            switch (ch)
            {

                //case '-':
                //case '_':
                //case '.':
                //case '!':
                //case '*':
                //case '\'':
                //case '(':
                //case ')':
                //    return true;

                case '-':
                case '_':
                case '.':
                    return true;
            }

            return false;
        }

        private char IntToHex(int n)
        {
            if (n <= 9)
                return (char)(n + (int)'0');
            else
                return (char)(n - 10 + (int)'a');
        }
    }
}
