using Expleo.Anagram;
using Expleo.Calculator;
using Expleo.WebPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expleo_project
{
    internal class Solutions
    {
        public static void ShowMenu()
        {
            int option = showList();
            switch (option)
            {
                case 1: RunAnagram(); break;
                case 2: RunWebLinks(); break;
                case 3: RunCalc1(); break;
                case 4: RunCalc2(); break;
                case 5: RunCalc3(); break;
                case 0: return;
                
            }
            ShowMenu();
        }

        private static void RunCalc3()
        {
            try
            {
                string expr;
                Console.WriteLine("Please enter the expression (multiple operators of different precedence):");
                expr = Console.ReadLine() ?? "";
                Calculator3 calc3 = new Calculator3();
                double result = calc3.Evaluate(expr);
                Console.WriteLine($"The Result is: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please Try again!");
                RunCalc3();
            }
        }

        private static void RunCalc2()
        {
            try
            {
                string expr;
                Console.WriteLine("Please enter the expression (multiple operators of the same precedence): ");
                expr = Console.ReadLine() ?? "";
                Calculator2 calc2 = new Calculator2();
                double result = calc2.Evaluate(expr);
                Console.WriteLine($"The Result is: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please Try again!");
                RunCalc2();
            }
        }

        private static void RunCalc1()
        {
            try
            {
                string expr;
                Console.WriteLine("Please enter the expression   (one operator, two parameters): ");
                expr = Console.ReadLine() ?? "";
                Calculator1 calc1 = new Calculator1();
                double result=calc1.Evaluate(expr);
                Console.WriteLine($"The Result is: {result}");
            }
            catch( Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please Try again!");
                RunCalc1();
            }
        }

        private static void RunWebLinks()
        {
            string url;
            Console.WriteLine("Please enter the URL: ");
            url = Console.ReadLine() ?? "";
            WebPageLinkFinder weblink = new WebPageLinkFinder();
            weblink.findLinks(url);
            return;
        }

        private static void RunAnagram()
        {
            string str1, str2;
            Console.WriteLine("Enter Text 1: ");
            str1 = Console.ReadLine() ?? "";
            Console.WriteLine("Enter Text 2: ");
            str2 = Console.ReadLine() ?? "";
            Anagram anagram = new();
            bool result = anagram.IsAnagram(str1, str2);
            if (result)
                Console.WriteLine("The given words are Anagram");
            else
                Console.WriteLine("The Given words are not Anagram");
            return;
        }

        private static int showList()
        {

            Console.WriteLine("\n1: Detect Anagram");
            Console.WriteLine("2: Find all links on a web page");
            Console.WriteLine("3: Calculator (one operator, two parameters)");
            Console.WriteLine("4: Calculator (multiple operators of the same precedence)");
            Console.WriteLine("5: Calculator (multiple operators of different precedence)");
            Console.WriteLine("0: Quit");
            Console.WriteLine("\nPlease enter the proper number : ");
            string? inputStr = Console.ReadLine();
            int selectedOption;

            if (String.IsNullOrEmpty(inputStr) || !int.TryParse(inputStr, out selectedOption))
            {
                Console.WriteLine("Please select a correct option");
                return showList();
            }
            return selectedOption;
        }
    }
}
