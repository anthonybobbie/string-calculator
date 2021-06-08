using Ninject;
 using StringCalculatorAssignment.Models;
using System;

namespace StringCalculatorAssignment
{
   public class Program
    {
        private static IKernel Kernel;
        static void Main(string[] args)
        {
            Kernel = new StandardKernel(new Container());
            var stringCalculator = Kernel.Get<StringCalculator>();
            StartStringAdditions(stringCalculator);

        }

        public static void StartStringAdditions(StringCalculator stringCalculator)
        {
            var answer = stringCalculator.Add("");
            Console.WriteLine($"zero length input returns {answer}");
            Console.WriteLine($"1 add 2 returns {stringCalculator.Add("1,2")}");

        }

        
    }
}
