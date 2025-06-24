using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DigitsProduct
{
    public class MaximumProduct
    {
        /// <summary>
        /// Calculates the maximum product of k consecutive digits in a numeric string.
        /// </summary>
        /// <param name="str">The input string containing digits.</param>
        /// <param name="k">The number of consecutive digits to consider.</param>
        /// <returns>The maximum product found.</returns>
        public static long MaxProductOfConsecutiveDigits(string str, int k)
        {
            try
            {
                if (string.IsNullOrEmpty(str) || k <= 0 || k > str.Length)
                {
                    throw new ArgumentException("Invalid input string or window size.");
                }

                if (!Regex.IsMatch(str, @"^\d+$"))
                {
                    throw new ArgumentException("Input string must contain only digits.");
                }

                int[] digits = str.Select(c => c - '0').ToArray();
                long maxProduct = 0;
                long currentProduct = 1;
                int zeroCount = 0;

                for (int i = 0; i < k; i++)
                {
                    if (digits[i] == 0)
                    {
                        zeroCount++;
                    }
                    else
                    {
                        //calculate product only when digits[i] is not zero
                        currentProduct *= digits[i];
                    }
                }
                //set maxProduct only when zeroCount is 0
                if (zeroCount == 0)
                {
                    maxProduct = currentProduct;
                }

                for (int i = k; i < digits.Length; i++)
                {
                    int left = digits[i - k];
                    int right = digits[i];

                    if (left == 0)
                    {
                        zeroCount--;
                    }
                    else
                    {
                        //recalculate product only when left is not zero
                        currentProduct /= left;
                    }

                    if (right == 0)
                    {
                        zeroCount++;
                    }
                    else
                    {
                        //calculate product only when right is not zero
                        currentProduct *= right;
                    }

                    if (zeroCount == 0)
                    {
                        maxProduct = Math.Max(maxProduct, currentProduct);
                    }
                }

                return maxProduct;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return long.MinValue;
            }
        }
    }
}
