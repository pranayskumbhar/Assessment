using System.Text;

namespace Assessment_18_07_2024.Common
{
    public static class Protect
    {
        private static string key = "Alphanso";
        public static string ToEncrypt(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            else
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(value += key));
            }
        }



        public static string ToDecrypt(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            else
            {
                var encryptedstring = Encoding.UTF8.GetString(Convert.FromBase64String(value));
                return encryptedstring.Substring(0, encryptedstring.Length - value.Length);
            }
        }
    }
}
