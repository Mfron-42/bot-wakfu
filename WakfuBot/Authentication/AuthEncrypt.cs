
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using PacketEditor.WakfuBot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WakfuBot.Authentication
{
    public static class AuthEncrypt
    {
        public static byte[] AuthData(string loginStr, string passwordStr, long salt, byte[] publicKey)
        {
            byte[] login = Encoding.UTF8.GetBytes(loginStr);
            byte loginLength = (byte)login.Length;
            byte[] password = Encoding.UTF8.GetBytes(passwordStr);
            byte passwordLength = (byte)password.Length;
            var data = salt.GetBytes().Concat(loginLength).Concat(login).Concat(passwordLength).Concat(password).ToArray();
            return PublicKeyEncrypt(data, publicKey);
        }

        public static byte[] PublicKeyEncrypt(byte[] data, byte[] publickey)
        {
            var rsaKeyParameters = (RsaKeyParameters)PublicKeyFactory.CreateKey(new MemoryStream(publickey, false));
            var rsaParameters = new RSAParameters();
            rsaParameters.Modulus = rsaKeyParameters.Modulus.ToByteArrayUnsigned();
            rsaParameters.Exponent = rsaKeyParameters.Exponent.ToByteArrayUnsigned();
            var rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(rsaParameters);
            return rsa.Encrypt(data, false);
        }
    }
}
