using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace LibraryFile
{
    public static class PasswordSalt
    {
        public static KeyValuePair<string, string> SaltEncrypt(string password)
        {

            byte[] byteSalt =new byte[16];
            string encryptedResult = string.Empty;
            string encryptedSalt = string.Empty;

            RandomNumberGenerator.Fill(byteSalt);


            encryptedResult = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: password,
                    salt: byteSalt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 1000,
                    numBytesRequested: 16
            ));

            encryptedSalt = Convert.ToBase64String(byteSalt);

            return new KeyValuePair<string, string>(encryptedResult, encryptedSalt);
        }

        public static bool encrypted(string encryptedSalt, string encryptedResult, string inputPassword)
        {
            byte[] decryptSalt = Convert.FromBase64String(encryptedSalt);
            

            string decryptedResult = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: inputPassword,
                    salt: decryptSalt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 1000,
                    numBytesRequested: 16));

            return decryptedResult.Equals(encryptedResult);
        }
    }
}
