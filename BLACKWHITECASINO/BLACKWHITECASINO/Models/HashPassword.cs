using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLACKWHITECASINO.Models
{
    public class HashPassword
    {
        public static string Hash(string text)
        {
            MD5 md5 = MD5.Create();

            byte[] b = Encoding.ASCII.GetBytes(text);
            byte[] hash = md5.ComputeHash(b);

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var a in hash)
                stringBuilder.Append(a.ToString("X2"));

            return stringBuilder.ToString();
        }
    }
}