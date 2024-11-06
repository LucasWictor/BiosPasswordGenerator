using System;
using System.Text;
using BiosPasswordGenerator.Utilities;

namespace PhoenixGenerator
{
    public static class HpPhoenixPasswordGenerator
    {
        private static readonly int[] SeedArray = { 7, 3, 9, 2, 5 }; 
        private static readonly int[] Factors = { 13, 7, 11, 3, 17 };
        
        public static string GeneratePassword(string hashCode)
        {
            if (hashCode.Length != 5 || !int.TryParse(hashCode, out _))
                throw new ArgumentException("Hash code must be a 5-digit numeric string.");

            var passwordBuilder = new StringBuilder();

            for (int i = 0; i < hashCode.Length; i++)
            {
                int digit = hashCode[i] - '0';
                int transformedDigit = TransformDigit(digit, i);
                passwordBuilder.Append(transformedDigit);
            }

            return PasswordUtilities.PostProcessPassword(passwordBuilder.ToString());
        }
        
        private static int TransformDigit(int digit, int position)
        {
            int transformed = (digit + SeedArray[position]) * Factors[position];
            transformed = (transformed * 3 + 7) % 10;  
            transformed = (transformed + position) % 10; 
            return transformed;
        }
    }
}