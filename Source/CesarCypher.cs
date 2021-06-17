using System;
using System.Text.RegularExpressions;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        public char Encode (char l, int key = 3)
        {
            if(!char.IsLetter(l))
            {
                return l;
            }
            return (char)((((char.ToLower(l) + key) - 'a') % 26) + 'a');
        }
        
        public string Crypt(string message)
        {
            string codedMessage = string.Empty;
            var acceptedCharsRegex = new Regex("^[a-zA-Z0-9 ]*$");
            if (message == null)
            {
                throw new ArgumentNullException();
            }
            if (!acceptedCharsRegex.IsMatch(message))
            {
                throw new ArgumentOutOfRangeException();
            }
            foreach (char letter in message)
            {
                codedMessage += Encode(letter);
            }
            return codedMessage;
        }

        public string Decrypt(string cryptedMessage)
        {
          string decodedMessage = string.Empty;
            int decryptKey = 26 - 3;
            var acceptedCharsRegex = new Regex("^[a-zA-Z0-9 ]*$");
            if (cryptedMessage == null)
            {
                throw new ArgumentNullException();
            }
            if (!acceptedCharsRegex.IsMatch(cryptedMessage))
            {
                throw new ArgumentOutOfRangeException();
            }
            foreach (char letter in cryptedMessage)
            {
                decodedMessage += Encode(letter, decryptKey);
            }
            return decodedMessage;
        }
    }
}
