using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Main
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> numMap = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                if (numMap.ContainsKey(complement))
                {
                    return new int[] { numMap[complement], i };
                }
                if (!numMap.ContainsKey(nums[i]))
                {
                    numMap[nums[i]] = i;
                }
            }
            return new int[0];

        }
    }
}
