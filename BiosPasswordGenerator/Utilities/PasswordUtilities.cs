using System.Text;

namespace BiosPasswordGenerator.Utilities
{
    public static class PasswordUtilities
    {
        public static string PostProcessPassword(string partialPassword)
        {
            var finalPassword = new StringBuilder();
            
            for (int i = 0; i < partialPassword.Length; i++)
            {
                int digit = partialPassword[i] - '0';
                char newChar;

                if (i % 2 == 0)
                {
                    newChar = (char)('A' + (digit + i) % 26); 
                }
                else
                {
                    newChar = (char)('0' + digit); 
                }

                finalPassword.Append(newChar);
            }

            return ShufflePassword(finalPassword.ToString());
        }

        private static string ShufflePassword(string password)
        {
            var charArray = password.ToCharArray();
            var rng = new Random();

            for (int i = charArray.Length - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (charArray[i], charArray[j]) = (charArray[j], charArray[i]);
            }

            return new string(charArray);
        }
    }
}
