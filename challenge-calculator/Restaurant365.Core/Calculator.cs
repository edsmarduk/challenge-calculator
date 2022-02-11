﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Restaurant365.Core
{
    public class Calculator
    {
        private readonly ILogger _logger;
        private readonly List<string> _delimiters;

        public Calculator(ILogger logger)
        {
            if (logger == null) throw new ArgumentNullException(nameof(logger));

            _logger = logger;
            _delimiters = new List<string>();
        }

        /// <summary>
        /// List of delimiters
        /// </summary>
        public List<string> Delimiters
        {
            get { return _delimiters; }
        }

        /// <summary>
        /// Gets or sets whether to allow negative numbers
        /// </summary>
        public bool DenyNegativeNumber { get; set; }

        /// <summary>
        /// Delimits an input into an array of strings
        /// </summary>
        /// <param name="input">Input to be delimited</param>
        /// <returns>Array of strings</returns>
        /// <exception cref="ArgumentNullException">Input is required</exception>
        private string[] DelimitInput(string input)
        {
            string pattern = String.Join("|",_delimiters.ToArray());

            if (string.IsNullOrEmpty(input)) throw new ArgumentNullException(nameof(input));
            if (string.IsNullOrEmpty(pattern)) throw new ArgumentNullException(nameof(pattern));

            _logger.WriteLine("Delimiter:" + pattern);

            return Regex.Split(input, pattern);

        }

        /// <summary>
        /// Takes a string and delimits it into an array of ints
        /// </summary>
        /// <param name="input">The string to be delimited</param>
        /// <returns>array of integers</returns>
        private int[] DelimitInputToInt(string input)
        {
            string[] values = DelimitInput(input);
            int[] result = new int[values.Length];
            
            for (int i = 0; i < values.Length; i++)
            {
                string value = values[i];

                //if the value isnt an int then we will push 0 into the array.
                int.TryParse(value, out result[i]);
                
            }

            return result;
        }

        /// <summary>
        /// Add numbers in input by seperating the input by the delimiter
        /// </summary>
        /// <param name="input">input to be parsed</param>
        /// <returns>returns the value of the added inputs</returns>
        /// <exception cref="ArgumentException">Exception thrown when more than 2 inputs are given</exception>
        public int Add(string input)
        {
            _logger.WriteLine("Input:" + input);

            StringBuilder formula = new StringBuilder();
            int result = 0;

            int[] values = DelimitInputToInt(input);

            //Removed the requirement for maximum constraint


            //loop through all of the values that were parsed
            for(int i = 0; i < values.Length; i++)
            {
                int value = values[i];

                if (DenyNegativeNumber && value < 0)
                    throw  new ArgumentOutOfRangeException("value", "Values cannot be negative when DenyNegativeNumber is set to true.");

                //add the parsed value to the formula
                formula.Append(value);

                //if this is not the last item, add the plus sign
                if (i < values.Length - 1)
                    formula.Append('+');

                //add the value to the result
                result += value;
            }

            

            //log the formula used
            _logger.WriteLine("Formula:" + formula.ToString());

            //return the result
            return result;
        }

    }
}
