using System;
using System.Globalization;

namespace Task3 {

    public class HexFormatProvider : IFormatProvider, ICustomFormatter {
        private readonly IFormatProvider _parent;
        public HexFormatProvider() : this(CultureInfo.CurrentCulture) { }
        public HexFormatProvider(IFormatProvider parent) {
            _parent = parent;
        }
        public object GetFormat(Type formatType) {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider) {
            if (format.ToLowerInvariant() == "h") {
                if(arg is int)
                    return ToHexString((int)arg);
              throw new ArgumentException("Argument can be integer");
            }
            if (arg is IFormattable)
                return ((IFormattable) arg).ToString(format, _parent);
             return arg != null ? arg.ToString() : string.Empty;
        }

        private static string ToHexString(int number) {
            bool isNegative = false;
            const string digits = "0123456789ABCDEF";
            if(number == 0)
                return "0x0";
            if(number < 0) {
                isNegative = true;
                number = Math.Abs(number);
            }
            string hex = "";
            while(number > 0) {
                int digit = number % 16;
                hex = digits[digit] + hex;
                number = number / 16;
            }
            hex = "0x" + hex;
            if(isNegative)
                hex = "-" + hex;
            return hex;
        }

    }
}
