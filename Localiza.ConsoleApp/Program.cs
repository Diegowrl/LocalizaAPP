using Localiza.Domain;
using System;
using System.Linq;

namespace Localiza.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre com o valor:");

            string value = Console.ReadLine();
            Divisores(value);
        }

        public static void Divisores(string value)
        {
            var divisores = new Divisor(value);
            var primos = new Primos(value);

            if (divisores.Invalid)
            {
                Console.WriteLine(string.Join(",", divisores.Notifications.Select(x => x.Message.ToString()).ToArray()));
                return;
            }

            var result = divisores.Calculate();
            Console.WriteLine("Divisores: " + string.Join(",", result.Select(x => x.ToString()).ToArray()));

            var resultPrimo = primos.Calculate();
            Console.WriteLine("Divisores Primos: " + string.Join(",", resultPrimo.Select(x => x.ToString()).ToArray()));
        }
    }
}
