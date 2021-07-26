using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaraokePayment.Helpers
{
    public static class StringHelper
    {
        public static string FirstCharToUpper(this string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            input = input.ToLower();
            return input.First().ToString().ToUpper() + input.Substring(1);            
        }  
        public static string StringCapitalization(this string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            string firstLetterOfEachWord =
            string.Join(" ", input.Split(' ').ToList()
                .ConvertAll(word =>
                        word.Substring(0, 1).ToUpper() + word.Substring(1)
                )
        );
            return firstLetterOfEachWord;
        }
    }
}
