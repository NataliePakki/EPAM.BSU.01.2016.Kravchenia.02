using System;
using System.Globalization;

namespace Task4 {
    public class Customer:IFormattable {
        public string Name {get; set;}
        public string ContactPhone {get; set;}
        public decimal Recenue { get; set; }

        public Customer(string name, string phone, decimal rec) {
            Name = name;
            ContactPhone = phone;
            Recenue = rec;
        }
        public override string ToString() {
            return ToString("g",new  CultureInfo("en-US"));
        }
        
        public string ToString(string format, IFormatProvider formatProvider) {
            if (String.IsNullOrEmpty(format)) format = "g";
            if(formatProvider == null) {
                formatProvider = new CultureInfo("en-US");
            }
           
            switch (format.ToLowerInvariant()){
                case "nrp":
                if(formatProvider is CustomerFormatProvider)
                    return string.Format(formatProvider, "{0:N}, {1:R}, {2:P}", Name, Recenue, ContactPhone);
                return string.Format(formatProvider, "{0}, {1:C}, {2}", Name, Recenue, ContactPhone);
                case "g":
                case "npr":
                if(formatProvider is CustomerFormatProvider)
                    return string.Format(formatProvider, "{0:N}, {1:P}, {2:R} ", Name, ContactPhone, Recenue);
                return string.Format(formatProvider, "{0}, {1}, {2:C}", Name, ContactPhone, Recenue);
                case "nr":
                if(formatProvider is CustomerFormatProvider)
                    return string.Format(formatProvider, "{0:N}, {1:R}", Name, Recenue);
                return string.Format(formatProvider, "{0}, {1:C}", Name, Recenue);
                case "r":
                if(formatProvider is CustomerFormatProvider)
                    return string.Format(formatProvider, "{0:R}", Recenue);
                return string.Format(formatProvider, "{0:C}", Recenue);
                default:
                throw new FormatException($"The {format} format string is not supported.");

            }
        }
        public string ToString(IFormatProvider formatProvider) {
            return ToString(null, formatProvider);
        }
        public string ToString(string format) {
            return ToString(format, null);
        }
    }
}
