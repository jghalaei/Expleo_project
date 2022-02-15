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
   
    public class Calculator2_Tests
    {
        Calculator2 calc;
        public Calculator2_Tests()
        {
            calc = new Calculator2();
        }
        [Theory]

        [InlineData("2+30+4", 36)] // returns 36
        [InlineData("2 - 3 + 4 + 15", 18)] // returns 18
        [InlineData("2 * 3 * 4", 24)] // returns 24
        [InlineData("2 * 3 / 4 * 20", 30)] // returns 30
        [InlineData("2 * 3 / 4 * 20/2*3 + 1", 46)] // returns 30
        public void Evaluate_success(string expr, double expectedResult)
        {
            double result = calc.Evaluate(expr);
            Assert.Equal(expectedResult, result);
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
