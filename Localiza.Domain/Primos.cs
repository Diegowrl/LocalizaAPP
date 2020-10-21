using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Localiza.Domain
{
    public class Primos : Notifiable
    {
        public Primos(string value)
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
            var listNumerosPrimos = new List<int>();
            var divisores = new Divisor(Value);

            var resultDivisores = divisores.Calculate();

            foreach (var count in resultDivisores)
            {

                var divisoresPrimos = 0;
                for (var aux = 1; aux <= count; aux++)
                    if (count % aux == 0)
                        divisoresPrimos++;

                if (divisoresPrimos == 2)
                    listNumerosPrimos.Add(count);

            }

            return listNumerosPrimos;
        }
        public string Value { get; set; }
    }
}
