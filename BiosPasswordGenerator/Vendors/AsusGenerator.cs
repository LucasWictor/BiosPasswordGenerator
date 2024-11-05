using System.Text;

namespace BiosPasswordGenerator.Vendors
{
    public class AsusGenerator
    {
        private static readonly int[] AsusTable = InitTable();

        // Generate the ASUS BIOS password based on year, month, and day
        public static string GeneratePassword(int year, int month, int day)
        {
            string dateString = $"{year:D4}{month:D2}{day:D2}";
            int checksum = int.Parse(dateString, System.Globalization.NumberStyles.HexNumber);
            StringBuilder password = new StringBuilder();

            for (int i = 0; i < 8; i++)
            {
                checksum = unchecked(33676 * checksum + 12345);
                int index = (checksum >> 16) & 31;
                int passwordChar = AsusTable[index] % 36;

                if (passwordChar > 9)
                {
                    // Convert to letters
                    password.Append((char)(passwordChar + 'A' - 10));
                }
                else
                {
                    // Convert to numbers
                    password.Append((char)(passwordChar + '0'));
                }
            }

            return password.ToString();
        }

        private static int[] InitTable(int a1 = 11, int a2 = 19, int a3 = 6)
        {
            int[] table = new int[32];
            int zeroCode = '0';

            table[0] = a1 + zeroCode;
            table[1] = a2 + zeroCode;
            table[2] = a3 + zeroCode;
            table[3] = '6';
            table[4] = '7';
            table[5] = '8';
            table[6] = '9';

            int checksum = 0;
            for (int i = 0; i < 7; i++) checksum += table[i];

            for (int i = 7; i < 32; i++)
            {
                checksum = unchecked(33676 * checksum + 12345);
                table[i] = ((checksum >> 16) & 0x7FFF) % 43 + zeroCode;
            }

            int v3 = a1 * a2;
            int v4 = Shuffle1((a1 - 1) * (a2 - 1), a3);

            for (int i = 0; i < table.Length; i++)
            {
                table[i] = Shuffle2(table[i] - zeroCode, v4, v3);
            }

            return table;
        }

        private static int Shuffle1(int a1, int a2)
        {
            int v3 = 2;
            for (int i = 0; i < a2; i++)
            {
                int v4 = v3;
                int v5 = a1;
                while (v5 > 0)
                {
                    if (v5 < v4)
                    {
                        (v5, v4) = (v4, v5);
                    }
                    v5 %= v4;
                }
                if (v4 != 1)
                {
                    v3++;
                }
            }
            return v3;
        }

        private static int Shuffle2(int a1, int a2, int a3)
        {
            if (a1 >= a3)
            {
                a1 %= a3;
            }

            int result = a1;
            if (a2 != 1)
            {
                for (int i = 0; i < a2 - 1; i++)
                {
                    result = (a1 * result) % a3;
                }
            }
            return result;
        }
    }
}