namespace BiosPasswordGenerator.Utilities
{
    public class InputParser
    {
        public (int Year, int Month, int Day) ParseDateInput(string input)
        {
            var dateParts = input.Split('-');
            if (dateParts.Length != 3 ||
                !int.TryParse(dateParts[0], out int year) ||
                !int.TryParse(dateParts[1], out int month) ||
                !int.TryParse(dateParts[2], out int day))
            {
                throw new ArgumentException("Invalid date format. Expected format: YYYY-MM-DD.");
            }

            return (year, month, day);
        }

        public string ParseServiceTagInput(string input)
        {
            if (string.IsNullOrEmpty(input) || !input.Contains("-"))
            {
                throw new ArgumentException("Invalid service tag format. Expected format: 1234567-595B.");
            }

            return input.Trim();
        }

        public int Parse5DigitHash(string input)
        {
            if (input.Length != 5 || !int.TryParse(input, out int hashCode))
            {
                throw new ArgumentException("Invalid hash code. Expected a 5-digit numeric string.");
            }

            return hashCode;
        }
    }
}
