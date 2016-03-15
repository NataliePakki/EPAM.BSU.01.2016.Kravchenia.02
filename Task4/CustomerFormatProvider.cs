using System;
using System.Globalization;

namespace Task4
{
    public class CustomerFormatProvider : IFormatProvider, ICustomFormatter {
        private IFormatProvider _parent;
        public CustomerFormatProvider(): this(CultureInfo.CurrentCulture) { }
        public CustomerFormatProvider(IFormatProvider parent) {
            _parent = parent;
        }
        public string Format(string format, object arg, IFormatProvider formatProvider){
           Customer t = arg as Customer;
           if(t == null) { return arg.ToString(); }
           return "Customer record: " + t.ContactPhone + ", " + t.Name + ", " + t.Recenue;
        }

        public object GetFormat(Type formatType) {
            return (formatType == typeof(Customer)) ? this : null;
        }
    }
}
