using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace Se7en
{
    public static class Validator
    {
        private static readonly Regex _emailRegex = new Regex(@"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$");

        public static bool IsEmail(string value)
            => _emailRegex.IsMatch(value ?? string.Empty);

        public static bool IsPassword(string            value,                  
                                      int  minLength    = 8, int               maxLength         = 15, 
                                      bool alphanumeric = true,
                                      AlphanumericStyle style             = AlphanumericStyle.Both,
                                      bool              numbers           = true,
                                      bool              specialCharacters = true,
                                      bool              ranged            = true)
        {
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

        public static bool IsIp(string value, out IPAddress ip) 
            => IPAddress.TryParse(value ?? string.Empty, out ip);
        
    }
}
