using System;

namespace InterviewTest
{
    /**
     * This small app gets array of numbers and returns same size array,
     * but with the products of all numbers except number that was on this index in input array
     *
     * You can pass parameters as program arguments or enter in console 
     */
    class Program
    {
        static void Main(string[] _args)
        {
            var input = ConvertInput(_args);
            var productOfAllNumbers = MultiplyAllNums(input);
            var result = CalculateAll(productOfAllNumbers, input);
            
            Console.WriteLine("Here is your result:");
            Console.WriteLine(string.Join(", ", result));
            Console.ReadKey();
        }

        /// <summary>
        /// Gets program arguments and if it`s not empty, converts them to int array,
        /// otherwise asks user to enter numbers in console 
        /// </summary>
        /// <param name="_array">program args</param>
        /// <returns>user input as array of ints</returns>
        private static int[] ConvertInput(string[] _array)
        {
            if (_array.Length == 0)
            {
                Console.WriteLine("Hi! Please enter your numbers dividing it with space");
                var input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    _array = input.Split(" ");
                }
                else
                {
                    Console.WriteLine("Please enter valid numbers");
                }
            }

            var result = new int[_array.Length];
            
            for (var i = 0; i < _array.Length; i++)
            {
                int.TryParse(_array[i], out result[i]);
            }
            
            return result;
        }

        /// <summary>
        /// Multiplies all numbers except zeros
        /// </summary>
        /// <param name="_array">Input array of ints</param>
        /// <returns>Product of all numbers</returns>
        private static int MultiplyAllNums(int[] _array)
        {
            var result = 1;
            foreach (var number in _array)
            {
                if(number != 0)
                    result *= number;
            }

            return result;
        }
        
        /// <summary>
        /// Divides product of all numbers by each input number and stores it array,
        /// using same index as number from input array.
        /// </summary>
        /// <param name="_product">Product of all numbers</param>
        /// <param name="_array">Input array</param>
        /// <returns>Array of results of multiplication all numbers except number
        /// that was on this index in input array</returns>
        private static string[] CalculateAll(int _product, int[] _array)
        {
            var result = new string[_array.Length];
            for (var j = 0; j < _array.Length; j++)
            {
                if (_array[j] != 0)
                    result[j] = (_product / _array[j]).ToString();
                else
                {
                    result[j] = _product.ToString();
                }
            }

            return result;
        }
    }
}