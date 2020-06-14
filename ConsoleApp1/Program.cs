using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Solution();
            var result = a.TwoSum2(new int[] { -1, -2, -3, -4, -5 }, -8);
            //  var result = a.TwoSum(new int[] { 2, 7, 11, 15 }, 9);
            Console.WriteLine(String.Join(',', result));
        }
    }

    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            int j = nums.Length - 1;
            int sum;
            for (int i = 0; i < nums.Length && j > 0;)
            {
                sum = nums[i] + nums[j];
                if (sum == target)
                {
                    return new int[] { i, j };
                }
                if (sum < target)
                {
                    i++;
                }
                else if (sum > target)
                {
                    j--;
                }
            }
            return Array.Empty<int>();
        }
        public int[] TwoSum2(int[] nums, int target)
        {
            var elements = nums.Select((el, index) => new Tuple<int, int>(el, index)).OrderBy(x => x.Item1).ToList();
            int j = elements.Count() - 1;
            int sum;
            int firstIndex = -1;
            int secondIndex = -1;
            for (int i = 0; i < elements.Count() && j > 0;)
            {
                sum = elements[i].Item1 + elements[j].Item1;
                if (sum == target)
                {
                    firstIndex = elements[i].Item2;
                    secondIndex = elements[j].Item2;
                    break;
                }
                if (sum < target)
                {
                    i++;
                }
                else if (sum > target)
                {
                    j--;
                }
            }
            if (firstIndex < 0)
            {
                return Array.Empty<int>();
            }
            return new int[] { firstIndex, secondIndex };
        }
    }
}
