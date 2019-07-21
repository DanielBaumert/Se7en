using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Se7en {
    public static class Validator {
        
        private static readonly Regex _emailRegex = new Regex(@"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$");
        private static readonly Regex _ipRegex = new Regex(@"^((25[0-5]|2[0-4]\d|[0-1]?\d\d?)\.){3}(25[0-5]|2[0-4]\d|[0-1]?\d\d?)$");
        private static readonly Regex _ip6Regex = new Regex(@"^\s*((([0-9A-Fa-f]{1,4}:){7}([0-9A-Fa-f]{1,4}|:))|(([0-9A-Fa-f]{1,4}:){6}(:[0-9A-Fa-f]{1,4}|((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){5}(((:[0-9A-Fa-f]{1,4}){1,2})|:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){4}(((:[0-9A-Fa-f]{1,4}){1,3})|((:[0-9A-Fa-f]{1,4})?:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){3}(((:[0-9A-Fa-f]{1,4}){1,4})|((:[0-9A-Fa-f]{1,4}){0,2}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){2}(((:[0-9A-Fa-f]{1,4}){1,5})|((:[0-9A-Fa-f]{1,4}){0,3}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){1}(((:[0-9A-Fa-f]{1,4}){1,6})|((:[0-9A-Fa-f]{1,4}){0,4}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:))|(:(((:[0-9A-Fa-f]{1,4}){1,7})|((:[0-9A-Fa-f]{1,4}){0,5}:((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}))|:)))(%.+)?\s*$");
        private static readonly Regex _portRegex = new Regex(@"^(\d{1,4}|[1-5]\d{4}|6[0-4][0-9]{3}|65[0-4]\d]{2}|655[0-2]\d|6553[0-5])$");
        private static readonly Regex _isDomain = new Regex(@"^(?:https?:\/\/)?((?!\_|\-)(?:[a-z0-9](?:[a-z0-9-]{0,61}[a-z0-9])?\.)+[a-z0-9][a-z0-9-]{0,61}[a-z0-9])");
        public static bool IsEmail(string value)
            => _emailRegex.IsMatch(value ?? string.Empty);

        public static bool IsPassword(string value,
                                      int minLength = 8, int maxLength = 15,
                                      bool alphanumeric = true,
                                      AlphanumericStyle style = AlphanumericStyle.Both,
                                      bool numbers = true,
                                      bool specialCharacters = true,
                                      bool ranged = true) {
            StringBuilder patterStringBuilder = new StringBuilder("[");

            if (alphanumeric)
                patterStringBuilder.Append(
                    style switch
                    {
                        AlphanumericStyle.UpperCase => "A-Z",
                        AlphanumericStyle.LowerCase => "a-z",
                        AlphanumericStyle.Both => "a-zA-Z",
                        _ => throw new ArgumentException("style")
                    });

            if (numbers)
                patterStringBuilder.Append("0-9");

            if (specialCharacters)
                patterStringBuilder.Append(@"\s!""#$%&'()*+,-./:;<=>?@[\]^_`{|}~");
            
            if (ranged)
                patterStringBuilder.Append($"]{{{minLength},{maxLength}}}");
            else
                patterStringBuilder.Append("]+");

            return IsPassword(value, patterStringBuilder.ToString());
        }

        public static bool IsPassword(string value, string patter)
            => Regex.IsMatch(value ?? string.Empty, patter);

        public static bool IsIp(string value)
            => _ipRegex.IsMatch(value);
        public static bool IsIp6(string value)
            => _ip6Regex.IsMatch(value);

        public static bool IsPort(string value)
            => _portRegex.IsMatch(value);
        public static bool IsDomain(string value)
            => _isDomain.IsMatch(value); 
    }
}
