using Expleo.Calculator;
using Expleo.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Expleo_Tests.Calculator_tests
{
    public class Calculator3_Tests
    {
        private Calculator3 calc;
        public Calculator3_Tests()
        {
            calc = new Calculator3();
        }

        [Theory]

        [InlineData("2+3*40", 122)]
        [InlineData("2 * 3 + 4", 10)] 
        [InlineData("2 / 3 + 4 - 1", 3.6666666)]
        [InlineData("2 - 3 * 4", -10)] 
        public void Evaluate_success(string expr, double expectedResult)
        {
            Calculator3 calc = new();
            double result = calc.Evaluate(expr);
            Assert.Equal(Math.Round(expectedResult,6), Math.Round(result,6));
        }

        [Theory]
        [InlineData("2+30++4")]
        [InlineData("2 - 3 +")]
        [InlineData("* 2 * 3 * 4")]
        [InlineData("2 * 3 % 4 * 20")]
        [InlineData("+ 1")]
        [InlineData("")]
        [InlineData(" ")]
        public void Evaluate_failure_InvalidExpression(string expr)
        {
            Assert.Throws<InvalidExpression>(() => calc.Evaluate(expr));
        }

        [Theory]
        [InlineData("2 * 3 * 4 / 0")]
        [InlineData("2 * 3 / 0 + 2")]
        [InlineData("2  / 0 * 3 * 2")]
        public void Evaluate_failure_divisionByZero(string expr)
        {
            Assert.Throws<DivideByZeroException>(() => calc.Evaluate(expr));

        }
    }
}
