namespace Application.Extensions
{
    public static class StringExtensions
    {
        public static int ToInt(this string value, int defaultIntValue = 0)
        {
            int parsedInt;
            if (int.TryParse(value, out parsedInt))
            {
                return parsedInt;
            }

            return defaultIntValue;
        }

        public static int? ToNullableInt(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            return value.ToInt();
        }
    }
}
