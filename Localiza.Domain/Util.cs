using System;
using System.Collections.Generic;
using System.Text;

namespace Localiza.Domain
{
    public class Util
    {
        public static int ConvertStringToDecimalAndRound(string input)
        {
            if (input.Contains("."))
            {
                var inputString = input.Replace(".", ",");
                var decimalString = Convert.ToDecimal(inputString);

                return (int)Decimal.Round(decimalString);
            }

            return (int)Decimal.Round(Convert.ToDecimal(input));
        }

    }
}
