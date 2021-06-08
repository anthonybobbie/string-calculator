
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorAssignment.Models
{
    /// <summary>
    /// Delimeter for splitting strings 
    /// </summary>
    public class DelimeterService
    {
        /// <summary>
        /// Splits string by delimeter
        /// </summary>
        /// <param name="intStrings">String to split</param>
        /// <param name="delimeters">Additional delimeters to split string by</param>
        /// <returns></returns>
        public int[] Split(string intStrings)
        {
            
                string[] splitString = new string[] { };
                string[] defaultDelimeters = new string[] { ",", "\n" };
                if (!intStrings.Contains("["))
                {
                    splitString = intStrings.Split(defaultDelimeters, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string intItem in splitString)
                    if (!uint.TryParse(intItem, out uint castInt)) throw new Exception("negatives not allowed");
                }
                else
                {
                    List<string> stringDelimeters = new List<string>();
                    //get delimeter part of string
                    var inputStringSplit = intStrings.Split(new char[] { '\n' })[0];
                    //remove beginning part of square braces
                    var delimeterRemovedSquareBraces = inputStringSplit.Replace('[', ' ');
                    var delimeters = delimeterRemovedSquareBraces.Split("]", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim());

                    //stringDelimeters.AddRange(defaultDelimeters);
                    stringDelimeters.AddRange(delimeters);

                    var inputStringSplit2 = intStrings.Split(new char[] { '\n' })[1];
                    splitString = inputStringSplit2.Split(stringDelimeters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
                }
                return splitString.Select(x => int.Parse(x)).ToArray();
             
        }
    }
}
