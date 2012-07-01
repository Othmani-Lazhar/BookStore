namespace BookStore.Core.Utils
{
    using System.Security.Cryptography;

    public class Cryptography
    {
        public static string GetMD5Hash(string input)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
            bs = md5.ComputeHash(bs);
            System.Text.StringBuilder builder = new System.Text.StringBuilder();

            foreach (var b in bs)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
