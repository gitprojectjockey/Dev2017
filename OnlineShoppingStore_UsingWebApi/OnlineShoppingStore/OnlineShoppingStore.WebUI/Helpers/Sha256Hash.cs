using System;
using System.Security.Cryptography;
using System.Text;

namespace OnlineShoppingStore.WebUI.Helpers
{
    public static class Sha256Crypto
    {
        public static string EncryptSha256(string value)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            SHA256Managed sha256hasher = new SHA256Managed();
            byte[] hashedDataBytes = sha256hasher.ComputeHash(encoder.GetBytes(value));
            return Convert.ToBase64String(hashedDataBytes);
        }
    }
}