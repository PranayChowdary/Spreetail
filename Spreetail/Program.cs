using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MultiValueDictionary
{
    public class Program
    {

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write(">");
                string input = Console.ReadLine();
                string command = input.Split(' ')[0].ToUpper();

                string arguments = input.Substring(input.IndexOf(' ') + 1);
                string[] values = arguments.Split(' ');
                DictionaryExtensionHelper.DictionaryFunctionality(command, values);
            }
        }

       
        
    }
}


