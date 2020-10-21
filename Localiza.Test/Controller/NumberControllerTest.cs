using Localiza.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Localiza.Test.Controller
{
    public class NumberControllerTest
    {
        [Fact]
        public void NumberController()
        {
            var x = new NumbersController();
            var teste = x.GetDivisores("10");

            Assert.Equal(4, teste.Count);
        }

        [Fact]
        public void NumberPrimoController()
        {
            var x = new NumbersController();
            var teste = x.GetNumerosPrimos("10");

            Assert.Equal(2, teste.Count);
        }

    }
}
