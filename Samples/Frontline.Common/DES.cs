using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frontline.Common
{
    /// <summary> 
    /// DESEncrypt加密解密算法。 
    /// </summary> 
    public static class DES
    {        
        /// <summary> 
        /// DES加密 
        /// </summary> 
        /// <param name="encryptString"></param>
        /// <param name="key"></param>
        /// <returns></returns> 
        public static string DesEncrypt(string encryptString, string key)
        {
            var data = Encoding.UTF8.GetBytes(encryptString);
            byte[] keyBytes = Convert.FromBase64String(key);
            PaddedBufferedBlockCipher cipher = new PaddedBufferedBlockCipher(new DesEngine());
            cipher.Init(true, new DesParameters(keyBytes));
            var outData = cipher.DoFinal(data);
            string outStr = Encoding.UTF8.GetString(UrlBase64.Encode(outData));
            return outStr;
        }

        public static byte[] Encrypt(string encryptString, string key)
        {
            var data = Encoding.UTF8.GetBytes(encryptString);
            if (key == null)
            {
                return data;
            }
            byte[] keyBytes = Convert.FromBase64String(key);
            PaddedBufferedBlockCipher cipher = new PaddedBufferedBlockCipher(new DesEngine());
            cipher.Init(true, new DesParameters(keyBytes));
            var outData = cipher.DoFinal(data);
            return outData;
        }

        public static string Decrypt(byte[] data, string key)
        {
            byte[] keyBytes = Convert.FromBase64String(key);
            PaddedBufferedBlockCipher cipher = new PaddedBufferedBlockCipher(new DesEngine());
            cipher.Init(false, new DesParameters(keyBytes));
            var outData = cipher.DoFinal(data);
            string outStr = Encoding.UTF8.GetString(outData);
            return outStr;
        }

        /**/

        /// <summary> 
        /// DES解密 
        /// </summary> 
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <returns></returns> 
        public static string DesDecrypt(string text, string key)
        {
            var data = UrlBase64.Decode(Encoding.UTF8.GetBytes(text));
            byte[] keyBytes = Convert.FromBase64String(key);
            PaddedBufferedBlockCipher cipher = new PaddedBufferedBlockCipher(new DesEngine());
            cipher.Init(false, new DesParameters(keyBytes));
            var outData = cipher.DoFinal(data);
            string outStr = Encoding.UTF8.GetString(outData);
            return outStr;
        }        
    }
}
