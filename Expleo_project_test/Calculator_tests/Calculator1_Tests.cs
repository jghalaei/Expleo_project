
using Expleo.Calculator;
using Expleo.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Expleo_Tests.Calculator_tests
{
    public class Calculator1_Tests
    {
        Calculator1 calc;
        public Calculator1_Tests()
        {
            calc = new Calculator1();
        }

        [Theory]

        [InlineData("2+30", 32)] // returns 32
        [InlineData("2 * 3", 6)] // returns 6
        [InlineData("2 -3", -1)] // returns -1
        [InlineData("2 / 3", 0.6666666)] // returns 0.6666666...
        public void Evaluate_success(string expr, double expectedResult)
        {
            double result = calc.Evaluate(expr);
            Assert.Equal(Math.Round(result, 6), Math.Round(expectedResult, 6));
        }


        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("+")]
        [InlineData("+ 10 5")]
        [InlineData("10 5 +")]
        [InlineData("10 % 5")]
        public void Evaluate_failue_InvalidData(string expr)
        {
            Assert.Throws<InvalidExpression>(() => calc.Evaluate(expr));
        }

        [Fact]
        public void Evaluate_failue_DivisionByZero()
        {
            Assert.Throws<DivideByZeroException>(() => calc.Evaluate("5 / 0"));
        }

    }
}
