using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace OdamOlsun.Utilities
{
    public static class PhoneNumberFormatter
    {
         public static string FormatPhoneNumber(string phoneNumber)
    {
        // Telefon numarasını temizle
        var cleaned = Regex.Replace(phoneNumber, @"\D", "");

        // Uzunluk kontrolü
        if (cleaned.Length == 11 && cleaned.StartsWith("0"))
        {
            cleaned = cleaned.Substring(1);
        }
        else if (cleaned.Length != 10)
        {
            throw new ArgumentException("Geçersiz telefon numarası formatı.");
        }

        // Telefon numarasını formatla
        var formattedNumber = $"({cleaned.Substring(0, 3)}) {cleaned.Substring(3, 3)} {cleaned.Substring(6, 2)} {cleaned.Substring(8, 2)}";

        return formattedNumber;
    }
    }
}