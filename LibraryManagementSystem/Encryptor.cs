using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace LibraryManagementSystem
{
    /*
        Taken from in class sourcecodes  
    */

    public class Encryptor
    {
        public static string EncryptText(string plainText)
        {
            // declare the required objects
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            UnicodeEncoding text = new UnicodeEncoding();
            StringBuilder str = new StringBuilder();

            // encrypt the plain text
            byte[] hash = md5.ComputeHash(text.GetBytes(plainText));

            // repeat the encryption for 100 times
            for (int i = 0; i < 100; i++)
            {
                hash = md5.ComputeHash(hash);
            }

            // loop through the hash and convert each encrypted character to hexadecimal
            // and append it to the string builder object
            for (int i = 0; i < hash.Length; i++)
            {
                str.Append(hash[i].ToString("X2"));
            }

            return str.ToString();
        }
    }
}