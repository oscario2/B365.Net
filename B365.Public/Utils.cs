using System;
using System.Linq;

namespace B365.Public
{
    public static class PublicUtils
    {
        /// <summary>
        /// decrypt odds field
        /// </summary>
        /// <returns></returns>
        public static string XorDecrypt(string odds, string key)
        {
            if (key.Length == 0) return odds;
            
            var xor = (char)(key[0] ^ key[1]);
            
            var conv = new char[odds.Length];
            for (var i = 0; i < odds.Length; i++)
            {
                conv[i] = (char)(odds[i] ^ xor);
            }

            return new string(conv);
        }

        /// <summary>
        /// convert fraction odds to decimal
        /// </summary>
        /// <param name="odds"></param>
        /// <returns></returns>
        public static double FractionToDecimal(string odds)
        {
            if (odds == "0/0") return 0.0;
            var split = odds.Split('/').Select(Convert.ToDouble).ToList();
            return (split[0] / split[1]) + 1.0;
        }
    }
}