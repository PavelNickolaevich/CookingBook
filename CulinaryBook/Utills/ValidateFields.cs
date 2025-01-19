using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CulinaryBook.Utills
{
    internal static class ValidateFields
    {
        public static bool CheckIsValidEmail(string email)
        {
            const string pattern = "[a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\\.[a-zA-Z0-9_-]+";
            return Regex.IsMatch(email, pattern);
      
        }

        public static bool CheckIsValidPhoneNumber(string phoneNumber)
        {
            const string pattern = "^((8|\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10}$";
            return Regex.IsMatch(phoneNumber, pattern);
           
        }

    }
}
