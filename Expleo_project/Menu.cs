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
    internal class Menu
    {
        int selectedOption = 0;
        public  void ShowMenu()
        {
            if (selectedOption != 0)
            {
                Console.WriteLine("\n------------------------------------------\n");
                Console.WriteLine("Do you want to return to menu (y/n)? ");
                string opt = Console.ReadLine() ?? "";
                if (opt.ToLower() != "y" && opt.ToLower() != "n")
                {
                    Console.WriteLine("Please select a correct option (y/n)?");
                    ShowMenu();
                }
                else if (opt.ToLower() == "y")
                {
                    selectedOption = 0;
                }

            }
            if (selectedOption == 0)
            {
                selectedOption = showList();
            }

            switch (selectedOption)
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

        private void RunCalc3()
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

        private  void RunCalc2()
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

        private  void RunCalc1()
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

        private  void RunWebLinks()
        {
            string url;
            Console.WriteLine("Please enter the URL: ");
            url = Console.ReadLine() ?? "";
            WebLink weblink = new WebLink();

            try
            {
                string result = weblink.FindLinks(url);
            Console.WriteLine(result);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please enter a valid URL...");
                RunWebLinks();
            }
        }

        private void RunAnagram()
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

      
        private int showList()
        {
            int option;
            Console.WriteLine("\n1: Detect Anagram");
            Console.WriteLine("2: Find all links on a web page");
            Console.WriteLine("3: Calculator (one operator, two parameters)");
            Console.WriteLine("4: Calculator (multiple operators of the same precedence)");
            Console.WriteLine("5: Calculator (multiple operators of different precedence)");
            Console.WriteLine("0: Quit");
            Console.WriteLine("\nPlease enter the proper number : ");
            string? inputStr = Console.ReadLine();


            if (String.IsNullOrEmpty(inputStr) || !int.TryParse(inputStr, out option))
            {
                Console.WriteLine("Please select a correct option");
                return showList();
            }
            return option;
        }
    }
}
