using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Localiza.Domain
{
    public class Divisor: Notifiable
    {
        public Divisor(string value)
        {
            Value = value;

            Validation();
        }

        private void Validation()
        {
            if (Regex.Matches(Value, @"[a-zA-Z]").Count >= 1)
                AddNotification(Value, "O valor inserido possui caracteres literais, ");

            if (Regex.Matches(Value, @"[!@#$%^&*(),.?:{}|<>+-]").Count >= 1)
                AddNotification(Value, "O valor inserido possui caracteres especiais, ");

            if (Regex.Matches(Value, @"[ ]").Count >= 1)
                AddNotification(Value, "O valor inserido possui espaços em branco");

        }

        public List<int> Calculate()
        {
            var listDivisores = new List<int>();
            int valueInt = Util.ConvertStringToDecimalAndRound(Value);

            for (int i = 1; i <= valueInt; i++)
            {
                if (valueInt % i == 0)
                    listDivisores.Add(i);

            }

            return listDivisores;
        }

        public string Value { get; set; }
    }
}
