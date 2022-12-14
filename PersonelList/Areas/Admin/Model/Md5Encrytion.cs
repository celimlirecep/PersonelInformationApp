using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace PersonelList.Areas.Admin.Model
{
    public static class Md5Encrytion
    {

        private static string hash = "aidlcLKJds.pYsJl";
        public static string Encrypt(string text)
        {
            byte[] data = Encoding.Default.GetBytes(text);
            using (MD5CryptoServiceProvider md5=new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(Encoding.Default.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDES=new TripleDESCryptoServiceProvider() { Key=keys,Mode=CipherMode.ECB,Padding=PaddingMode.PKCS7})
                {
                    ICryptoTransform transform = tripleDES.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data,0,data.Length);
                    return Convert.ToBase64String(results,0,results.Length);
                }
            }
        }
        public static string Descrypt(string text)
        {
            byte[] data = Convert.FromBase64String(text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(Encoding.Default.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripleDES.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Encoding.Default.GetString(results);
                }
            }
        }

    }
}