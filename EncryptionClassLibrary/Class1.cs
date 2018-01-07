using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace EncryptionClassLibrary
{
    public class Class1
    {
        byte[] seed = ASCIIEncoding.ASCII.GetBytes("cse44598"); // A seed from a binary array for encryption. We could encrypt the seed to make it even more secure.
        public string Encrypt(string plainString)
        { // encryption using DES 
            if (String.IsNullOrEmpty(plainString))
            {
                throw new ArgumentNullException("The input cannot be empty or null!");
            }
            SymmetricAlgorithm saProvider = DES.Create();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream,
                saProvider.CreateEncryptor(seed, seed), CryptoStreamMode.Write);
            StreamWriter sWriter = new StreamWriter(cStream);
            sWriter.Write(plainString);
            sWriter.Flush(); // Buffer flush is necessary when switching writing modes
            cStream.FlushFinalBlock();
            return Convert.ToBase64String(mStream.GetBuffer(), 0, (int)mStream.Length);
        }
        public string Decrypt(string encryptedString)
        { // decryption using DES 
            if (String.IsNullOrEmpty(encryptedString))
            {
                throw new ArgumentNullException("The string cannot be empty or null!");
            }
            SymmetricAlgorithm saProvider = DES.Create();
            MemoryStream memStream = new MemoryStream
                    (Convert.FromBase64String(encryptedString));
            CryptoStream cStream = new CryptoStream(memStream,
                saProvider.CreateDecryptor(seed, seed), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cStream);
            return reader.ReadLine();
        }
    }
}
