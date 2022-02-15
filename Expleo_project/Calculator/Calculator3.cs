using Expleo.Calculator;
using Expleo.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expleo.Calculator
{
    public class Calculator3
    {
        Stack<double> stNumbers = new Stack<double>();
        Stack<char> stOperators = new Stack<char>();


        public double Evaluate(string expr)
        {
            char[] oprs = { '+', '-', '/', '*' };
            char[] nums = "0123456789.".ToCharArray();
            string str = "";

            foreach (char currentChar in expr.ToCharArray())
            {
                if (currentChar == ' ')
                    continue;
                if (oprs.Contains(currentChar))
                {
                    stNumbers.Push(Calc.StrToNum(str));
                    operateHigherPriorities(currentChar);
                    stOperators.Push(currentChar);
                    str = "";
                }
                else
                {
                    if (!nums.Contains(currentChar))
                        throw new Exceptions.InvalidExpression();
                    str += currentChar;
                }
            }
            stNumbers.Push(Calc.StrToNum(str));
            operateHigherPriorities('=');
            return stNumbers.Pop();
        }
        private void operateHigherPriorities(char currentChar)
        {
            double num1, num2;
            char opr;
            while (stOperators.Count > 0 && getPriority(stOperators.Peek()) >= getPriority(currentChar))
            {
                num2 = stNumbers.Pop();
                num1 = stNumbers.Pop();
                opr = stOperators.Pop();
                stNumbers.Push(Calc.DoOperate(num1, num2, opr));
            }

        }

        private int getPriority(char opr)
        {
            switch (opr)
            {
                case '=': return 0;
                case '+':
                case '-': return 1;
                case '*':
                case '/': return 2;
            }
            return 0;
        }

    }
}
