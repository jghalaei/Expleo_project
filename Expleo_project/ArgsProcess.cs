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
    internal class ArgsProcess
    {

        private static string prompt = "please use following format:\ndotnet run (-a|-l|-c1|-c2|-c3) param1 [param2]";

        public static void Run(string[] args)
        {
            string result;
            switch (args[0])
            {
                case "-a":
                    runAnagram(args);
                    break;
                case "-l":
                    runWebLink(args);
                    break;
                case "-c1":
                    runCalc1(args);
                    break;
                case "-c2":
                    runCalc2(args);
                    break;
                case "-c3":
                    runCalc3(args);
                    break;
                default:
                    Console.WriteLine(prompt);
                    break;

            }
        }

        private static void runAnagram(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine(prompt);
                return;
            }
            Anagram anagram = new();
            if (anagram.IsAnagram(args[1], args[2]))
                Console.Write($"{args[1]} and {args[2]} are Anagram");
            else
                Console.WriteLine($"{args[1]} and {args[2]} are Not Anagram");
        }
        private static void runWebLink(string[] args)
        {
            if (args.Length!=2)
            {
                Console.WriteLine(prompt);
                return;
            }
            WebLink webLink = new();
            string result = webLink.FindLinks(args[1]);
            Console.WriteLine($">{result}");

        }
        private static void runCalc1(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine(prompt);
                return;
            }
            Calculator1 calc1 = new();
            var result = calc1.Evaluate(args[1]);
            Console.WriteLine(result);

        }
        private static void runCalc2(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine(prompt);
                return;
            }
            Calculator2 calc2 = new();
            var result = calc2.Evaluate(args[1]);
            Console.WriteLine(result);
        }
        private static void runCalc3(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine(prompt);
                return;
            }
            Calculator3 calc3 = new();
            var result = calc3.Evaluate(args[1]);
            Console.WriteLine(result);
        }



 
    }
}
