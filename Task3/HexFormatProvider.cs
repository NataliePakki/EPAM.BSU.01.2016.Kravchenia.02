using System;
using System.Globalization;

namespace Task3 {

    public class HexFormatProvider : IFormatProvider, ICustomFormatter {
        private readonly IFormatProvider _parent;
        public HexFormatProvider(): this(CultureInfo.CurrentCulture) { }
        public HexFormatProvider(IFormatProvider parent){
            _parent = parent;
        }
        public object GetFormat(Type formatType) {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider) {
            if(arg == null) {
                return string.Format(_parent,"{0:"+ format + "}",arg);
            }
            if(arg is int) {
                return ToHexString((int)arg);
            }
            throw new ArgumentException($"{nameof(arg)} argument type: {arg.GetType()} is not supported");
        }

        private static string ToHexString(int number) {
            bool isNegative = false;
            const string digits = "0123456789ABCDEF";
            if(number == 0)
                return "0";
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
            if(isNegative)
                hex = "-" + hex;
            return hex;
        }

    }
}
