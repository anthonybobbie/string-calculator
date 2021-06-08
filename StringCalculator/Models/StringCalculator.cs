 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorAssignment.Models
{
    public class StringCalculator  
    {
        private readonly DelimeterService delimeterService;

        public StringCalculator(DelimeterService delimeterService)
        {
            this.delimeterService = delimeterService;
        }
        /// <summary>
        /// Adds numbers in a string which are delimited
        /// </summary>
        /// <param name="intStrings">string numbers</param>
        /// <returns>returns the sum of all the numbers in the string</returns>
        public int Add(string intStrings)
        {
            try
            {
                if (intStrings.Length == 0) return 0;
                //check if custom delimeters are added to string
                if (!intStrings.Contains("["))
                {
                    //negatives not allowed


                    //string hasn't got any custom delimeters, fallback to default delimeters
                    var splitInt = this.delimeterService.Split(intStrings);
                    return splitInt.Where(x=>x<=1000).Sum();
                }
                else
                {
                    //number of opening square braces must match the number of closing square braces
                    if (intStrings.Where(x => x == '[').Count() != intStrings.Where(x => x == ']').Count())
                    {
                        throw new Exception("A square bracket is not a valid delimiter.");
                    }


                    var splitInt = this.delimeterService.Split(intStrings);
                    return splitInt.Where(x => x <= 1000).Sum();

                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

     }
}
