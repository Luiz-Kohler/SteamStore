using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Shared.Hash
{
    public static class HashUtils
    {
        public static string HashString(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static bool CompareHash(string password, string hash)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                password = HashString(password);
                return password == hash;
            }
        }
    }
}
