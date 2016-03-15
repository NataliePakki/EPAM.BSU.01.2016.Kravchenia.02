using System;

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
            return ToString("g",null);
        }
        
        public string ToString(string format, IFormatProvider formatProvider) {
            if (String.IsNullOrEmpty(format)) format = "g";
            var fmt = formatProvider?.GetFormat(GetType()) as ICustomFormatter;
            if (fmt != null) { return fmt.Format(null, this, formatProvider); }
            switch (format.ToLower()){
                 case "g":
                 case "name phone recenue":
                     return $"Customer record: {Name}, {ContactPhone}, {Recenue}";
                 case "name":
                     return $"Customer record: {Name}";
                 case "name phone":
                     return $"Customer record: {Name}, {ContactPhone}";
                 case "phone":
                     return $"Customer record: {ContactPhone}";
                 case "recenue":
                     return $"Customer record: {Recenue}";
                 default:
                     throw new FormatException($"The '{format}' format string is not supported.");
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
