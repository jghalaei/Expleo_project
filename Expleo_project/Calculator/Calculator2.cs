using Expleo.Calculator;
using Expleo.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expleo.Calculator
{
    public class Calculator2
    {
        public double Evaluate(string expr)
        {
            char[] oprs = { '+', '-', '*', '/' };
            char[] nums = "0123456789.".ToCharArray();
            string str = "";
            double num1 = 0, num2 = 0;
            char opr = ' ';

            if (string.IsNullOrWhiteSpace(expr))
                throw new InvalidExpression();
            foreach (char currentChar in expr.ToArray())
            {
                if (currentChar == ' ')
                    continue;
                if (oprs.Contains(currentChar))
                {
                    if (opr == ' ')
                        num1 = Calc.StrToNum(str);
                    else
                    {
                        num2 = Calc.StrToNum(str);
                        num1 = Calc.DoOperate(num1, num2, opr);
                    }
                    opr = currentChar;
                    str = "";
                }
                else
                {
                    if (!nums.Contains(currentChar))
                        throw new Exceptions.InvalidExpression();
                    str += currentChar;
                }
            }
            if (opr != ' ')
            {
                num2 = Calc.StrToNum(str);
                num1= Calc.DoOperate(num1, num2, opr);
            }
            return num1;
        }
 
    

    }
}
