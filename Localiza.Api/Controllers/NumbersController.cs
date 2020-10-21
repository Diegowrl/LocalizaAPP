using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Localiza.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Localiza.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumbersController : ControllerBase
    {

        [HttpGet]
        [Route("{value}")]
        public List<dynamic> Getint(string value)
        {
            var primos = new Primos(value);
            var divisores = new Divisor(value);

            if (primos.Invalid)
            {
                throw new ArgumentException(string.Join(",", primos.Notifications.Select(x => x.Message.ToString()).ToArray()));
            }
            
            if (divisores.Invalid)
            {
                throw new ArgumentException(string.Join(",", divisores.Notifications.Select(x => x.Message.ToString()).ToArray()));
            }

            return new List<dynamic> { new { divisores = divisores.Calculate(), primos = primos.Calculate() } };
        }

        [HttpGet]
        [Route("divisores/{value}")]
        public List<int> GetDivisores(string value)
        {
            var divisores = new Divisor(value);

            if (divisores.Invalid)
            {
                throw new ArgumentException(string.Join(",", divisores.Notifications.Select(x => x.Message.ToString()).ToArray()));
            }

            return divisores.Calculate();
        }

        [HttpGet]
        [Route("numerosPrimos/{value}")]
        public List<int> GetNumerosPrimos(string value)
        {

            var primos = new Primos(value);

            if (primos.Invalid)
            {
                throw new ArgumentException(string.Join(",", primos.Notifications.Select(x => x.Message.ToString()).ToArray()));
            }

            return primos.Calculate();
        }
    }
}
