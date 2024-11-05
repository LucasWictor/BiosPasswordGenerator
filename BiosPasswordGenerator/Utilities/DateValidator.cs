namespace BiosPasswordGenerator.Utilities
{
    public static class DateValidator
    {
        public static bool IsValidDate(int year, int month, int day)
        {
            if (year < 0)
                return false;

            if (month < 1 || month > 12)
                return false;

            if (day < 1 || day > DaysInMonth(year, month))
                return false;

            return true;
        }

        private static int DaysInMonth(int year, int month)
        {
            return month switch
            {
                1 or 3 or 5 or 7 or 8 or 10 or 12 => 31,
                4 or 6 or 9 or 11 => 30,
                2 => IsLeapYear(year) ? 29 : 28,
                _ => throw new ArgumentOutOfRangeException(nameof(month), "Month must be between 1 and 12")
            };
        }

        private static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }
    }
}
