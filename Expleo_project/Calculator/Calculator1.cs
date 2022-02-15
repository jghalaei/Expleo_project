using Expleo.Calculator;
using Expleo.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expleo.Calculator
{
    public class Calculator1
    {
        public double Evaluate(string expr)
        {
            double num1 = 0, num2 = 0;
            char opr = ' ';
            string str = "";
            char[] operators = { '+', '-', '*', '/' };

            if (String.IsNullOrWhiteSpace(expr))
                throw new InvalidExpression();

            for (int i = 0; i < expr.Length; i++)
            {
                if (operators.Contains(expr[i]))
                {
                    num1 = Calc.StrToNum(str);
                    str = "";
                    opr = expr[i];
                    continue;
                }
                else if (expr[i] != ' ')
                {
                    str += expr[i];
                }

            }
            num2 = Calc.StrToNum(str);
            return Calc.DoOperate(num1, num2, opr);
        }


    }
}
