using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TaobaoKe.Util
{
    public class SecurityUtil
    {
        public static readonly byte[] AES_IV = { 33, 122, 91, 231, 198, 243, 251, 56, 41, 177, 121, 12, 241, 108, 61, 45 };
        public static readonly byte[] AES_KEY_128 = { 15, 8, 50, 14, 25, 113, 88, 80, 74, 66, 26, 62, 13, 35, 98, 109 };


        /// <summary>
        /// 自定义加密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static string EncryptAES(string input, byte[] key, byte[] iv)
        {
            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(input);
                        }
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
        }

        /// <summary>
        /// 指定私钥解密
        /// </summary>
        /// <param name="decryptStr"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static string DecryptAES(string decryptStr, byte[] key, byte[] iv)
        {
            string plaintext = null;

            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;
                byte[] cipherBytes = Convert.FromBase64String(decryptStr);

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;
        }

        /// <summary>
        /// 获取文件的md5编码
        /// </summary>
        /// <param name="stream">文件流</param>
        /// <returns>md5编码</returns>
        public static string GetFileMd5(Stream stream)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(stream);
            StringBuilder fileMd5 = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                fileMd5.Append(retVal[i].ToString("x2"));
            }

            return fileMd5.ToString();
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <returns>加密后字符串</returns>
        public static string GetMD5Hash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] bs = Encoding.UTF8.GetBytes(input);
            byte[] hs = md5.ComputeHash(bs);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hs)
            {
                // 以十六进制格式格式化
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }


        const string ENCRYPT_KEYFIELD_TAG = "|E|";
        const int ENCRYPT_KEYFIELD_INT = 0x151212;

        /// <summary>
        /// 加密关键字段的值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String EncryptKeyFieldValue(String value)
        {
            if (value == null || value == "") return value;
            //已经加密的不要再加密
            int iLen = ENCRYPT_KEYFIELD_TAG.Length;
            if (value.Length > iLen && value.Substring(0, iLen).Equals(ENCRYPT_KEYFIELD_TAG, StringComparison.Ordinal))
            {
                return value;
            }
            else
            {
                String result = EncryptAES(value, AES_KEY_128, AES_IV);
                return ENCRYPT_KEYFIELD_TAG + result;
            }
        }

        /// <summary>
        /// 加密关键字段的值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String DecryptKeyFieldValue(String value)
        {
            if (value == null || value == "") return value;
            int iLen = ENCRYPT_KEYFIELD_TAG.Length;
            if (value.Length > iLen && value.Substring(0, iLen).Equals(ENCRYPT_KEYFIELD_TAG, StringComparison.Ordinal))
            {
                return DecryptAES(value.Substring(iLen), AES_KEY_128, AES_IV);
            }
            else
            {
                return value;
            }
        }


        /// <summary>
        /// 加密关键字段的值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long EncryptUint(long value)
        {
            //yyyyMMdd
            Byte[] b4 = BitConverter.GetBytes(value);
            Byte b = b4[0];
            b4[0] = b4[1];
            b4[1] = b4[2];
            b4[2] = b;
            value = BitConverter.ToUInt32(b4, 0);
            return (uint)(value ^ ENCRYPT_KEYFIELD_INT | 0xE0000000);
        }

        /// <summary>
        /// 加密关键字段的值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long DecryptUint(long value)
        {
            if (value < 99999999) return value;
            value = (value & 0x0FFFFFFF) ^ ENCRYPT_KEYFIELD_INT;
            Byte[] b4 = BitConverter.GetBytes(value);
            Byte b = b4[2];
            b4[2] = b4[1];
            b4[1] = b4[0];
            b4[0] = b;
            value = BitConverter.ToUInt32(b4, 0);
            return value;
        }

    }


}
