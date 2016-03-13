using System;

namespace Task3 {
    public static class IntExtension {

        public static string ToHexString(this int number) {
            bool isNegative = false;
            const string digits = "0123456789ABCDEF";
            if (number == 0) return "0";
            if (number < 0) {
                isNegative = true;
                number = Math.Abs(number);
            }
            string hex = "";
            while (number > 0)
            {
                int digit = number % 16; 
                hex = digits[digit] + hex; 
                number = number / 16;
            }
            if (isNegative)
                hex = "-" + hex;
            return hex;
        }
    }
}
