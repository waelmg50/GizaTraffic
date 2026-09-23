namespace Utilities
{
    public static class ArabicNumbers
    {
        public static string ToArabicDigits(string? value)
        {
            if (string.IsNullOrEmpty(value))
                return value ?? string.Empty;

            return value
                .Replace('0', '٠')
                .Replace('1', '١')
                .Replace('2', '٢')
                .Replace('3', '٣')
                .Replace('4', '٤')
                .Replace('5', '٥')
                .Replace('6', '٦')
                .Replace('7', '٧')
                .Replace('8', '٨')
                .Replace('9', '٩');
        }

        public static string ToArabicDigits(int value)
        {
            return ToArabicDigits(value.ToString());
        }

        public static string ToArabicDigits(decimal value)
        {
            return ToArabicDigits(value.ToString());
        }
    }
}
