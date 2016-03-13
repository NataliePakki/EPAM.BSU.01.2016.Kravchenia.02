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
            if (formatProvider != null){
                var fmt = formatProvider.GetFormat(GetType()) as ICustomFormatter;
                if (fmt != null) { return fmt.Format(null, this, formatProvider); }
            }
             switch (format.ToLower()){
                 case "g":
                 case "name phone recenue":
                     return String.Format("Customer record: {0}, {1}, {2}", Name, ContactPhone, Recenue);
                 case "name":
                     return String.Format("Customer record: {0}", Name);
                 case "name phone":
                     return String.Format("Customer record: {0}, {1}", Name, ContactPhone);
                 case "phone":
                     return String.Format("Customer record: {0}", ContactPhone);
                 case "recenue":
                     return String.Format("Customer record: {0}", Recenue);
                 default:
                     throw new FormatException(String.Format("The '{0}' format string is not supported.", format));
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
