using System;
using System.Globalization;

namespace Task4
{
    public class CustomerFormatProvider : IFormatProvider, ICustomFormatter {
        private readonly IFormatProvider _parent;
        public CustomerFormatProvider(): this(new  CultureInfo("en-US")) { }
        public CustomerFormatProvider(IFormatProvider parent) {
            _parent = parent;
        }
        public string Format(string format, object arg, IFormatProvider formatProvider){
            if(format == null)
                return arg.ToString();
            switch(format.ToUpper()) {
                case "N":
                return "Name: " + arg;
                case "P":
                return "Contact phone: " + arg;
                case "R":
                return "Recenue: " + string.Format(_parent, "{0:C}", arg);
                default:
                return string.Format(_parent, "{0:" + format + "}", arg);
            }
        }
        
        
        public object GetFormat(Type formatType) {
            return (formatType == typeof(ICustomFormatter)) ? this : null;
        }
    }
}
