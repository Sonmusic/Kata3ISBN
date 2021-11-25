using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata3
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static bool Validate(string isbn)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(isbn))
            {
                switch (isbn.Length)
                {
                    case 10:
                        result = ValidISBN10(isbn);
                        break;
                    case 13:
                        result = ValidISBN13(isbn);
                        break;
                    default:
                        result = false;
                        break;
                }
            }
            return result;
        }

        public static bool ValidISBN10(string isbn)
        {
            int n = isbn.Length;
            if (n != 10)
                return false;

            int sum = 0;
            for(int i = 0; i < 9; i++)
            {
                int digit = isbn[i] - '0';
                if (0 > digit || 9 < digit)
                    return false;

                sum += (digit * (10 - i));
            }

            char last = isbn[9];
            if (last != 'X' && (last < '0'
                || last > '9'))
                return false;

            sum += ((last == 'X') ? 10 :
                (last - '0'));

            return (sum % 11 == 0);
        }

        public static bool ValidISBN13(string isbn)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(isbn))
            {
                long j;
                if (isbn.Contains('-')) isbn = isbn.Replace("-", "");

                if (!Int64.TryParse(isbn, out j))
                    result = false;

                int sum = 0;
                for(int i = 0; i < 12; i++)
                {
                    sum += Int32.Parse(isbn[i].ToString()) * (i % 2 == 1 ? 3 : 1);
                }

                int preresult = sum % 10;
                int checkDigit = 10 - preresult;
                if (checkDigit == 10) checkDigit = 0;

                result = (checkDigit == int.Parse(isbn[12].ToString()));

            }
            return result;
        }
    }
}
