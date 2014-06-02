    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Security.Cryptography;
    using System.Text;
    using System.Collections;

namespace awsmSeeSharpGame.Classes
{
    /// <summary>
    /// Skrevet av Dag Ivarsøy
    /// Dette er en Hashing klasse som tar seg av generering av Salt og kryptering av passord.
    /// </summary>
    static public class Hash
    {
        private static RNGCryptoServiceProvider randomGenerator = new RNGCryptoServiceProvider(); //En random generator for å genere salt

        /// <summary>
        /// Oppretter ett tileldig salt
        /// </summary>
        /// <returns>string salt</returns>
        static public string GetSalt()
        {
            UnicodeEncoding utf16 = new UnicodeEncoding(); // Utf-16 encoding som tegnset

            byte[] saltValue = new byte[20]; //Størrelsen på saltet
            randomGenerator.GetBytes(saltValue); //Generer saltet i et bytes array
            string salt = utf16.GetString(saltValue); // Konverterer saltet til en string
            return salt;
        }

        /// <summary>
        /// Generer et tilfeldig salt og hasher passordet sammen med saltet. Returnerer hashen og saltet
        /// </summary>
        /// <param name="passord"></param>
        /// <returns>Hashtable med has som nullte index og salt som første index</returns>
        static public Hashtable GetHashAndSalt(string passord)
        {
            UnicodeEncoding utf16 = new UnicodeEncoding();
            string salt = GetSalt();
            byte[] hashValue;
            byte[] passordByte = utf16.GetBytes(passord + salt);

            SHA512Managed hashString = new SHA512Managed();
            string hash = "";

            hashValue = hashString.ComputeHash(passordByte);
            foreach (byte x in hashValue)
            {
                hash += String.Format("{0:x2}", x);
            }
            Hashtable hashtable = new Hashtable();
            hashtable.Add("hash", hash);
            hashtable.Add("salt", salt);

            return hashtable;
        }

        /// <summary>
        /// Klasse som returnerer Hash når passord og salt er oppgitt.
        /// </summary>
        /// <param name="passord"></param>
        /// <param name="salt"></param>
        /// <returns>string Hash</returns>
        static public string GetHash(string passord, string salt)
        {
            UnicodeEncoding utf16 = new UnicodeEncoding();
            byte[] hashValue;
            byte[] passordByte = utf16.GetBytes(passord + salt);

            SHA512Managed hashString = new SHA512Managed();
            string hash = "";

            hashValue = hashString.ComputeHash(passordByte);
            foreach (byte x in hashValue)
            {
                hash += String.Format("{0:x2}", x);
            }

            return hash;
        }

        /// <summary>
        /// Sjekker om gitt passord er det samme som en gitt hash ved bruk av gitt salt
        /// Returnerer true eller false
        /// </summary>
        /// <param name="passord"></param>
        /// <param name="hash"></param>
        /// <param name="salt"></param>
        /// <returns>Bool</returns>
        static public bool CheckPassord(string passord, string hash, string salt)
        {
            string hash2 = GetHash(passord, salt);
            return hash.Equals(hash2);
        }
    }
}
