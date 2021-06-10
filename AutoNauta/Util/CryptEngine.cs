using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Effortless.Net.Encryption;

namespace AutoNauta.Util
{
    class CryptEngine
    {
        public static string Encrypt(string input)
        {
            return Strings.Encrypt(input, null, null);
        }
        public static string Decrypt(string input)
        {
            return Strings.Decrypt(input, null, null);
        }
    }
}
