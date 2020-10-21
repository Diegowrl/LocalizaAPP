using Localiza.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Localiza.Test.Domain
{
    public class PrimosTest
    {
        [Theory]
        [InlineData("diego")]
        [InlineData("d1")]
        public void DecimaisInvalidos(string value)
        {
            var divisor = new Divisor(value);
            Assert.True(divisor.Invalid);
        }

        [Fact]
        public void DecimaisValido()
        {
            var divisor = new Divisor("10");
            Assert.True(divisor.Valid);
        }
    }
}
