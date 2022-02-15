using Expleo.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expleo.Calculator
{
    internal class Calc
    {
        internal static double DoOperate(double num1, double num2, char opr)
        {
            switch (opr)
            {
                case '+': return num1 + num2;
                case '-': return num1 - num2;
                case '*': return num1 * num2;
                case '/':
                    if (num2 == 0)
                        throw new DivideByZeroException();
                    return num1 / num2;
            }
            throw new InvalidExpression();
        }

        internal static double StrToNum(string str)
        {
            double num;
            if (!double.TryParse(str, out num))
                throw new Exceptions.InvalidExpression();
            return num;
        }
    }
}
