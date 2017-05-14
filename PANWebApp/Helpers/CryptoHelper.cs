using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PANWebApp.Helpers
{
    public static class CryptoHelper
    {
        public static string CalulateHash(string input)
        {
            MD5 hashAlgo = new MD5CryptoServiceProvider();

            byte[] source = UTF8Encoding.UTF8.GetBytes(input);
            byte[] hash = hashAlgo.ComputeHash(source);

            return UTF8Encoding.UTF8.GetString(hash);
        }
    }
}