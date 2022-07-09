namespace LeetCode
{
    /*
        1. Two Sum - https://leetcode.com/problems/two-sum/

        Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        You may assume that each input would have exactly one solution, and you may not use the same element twice.
        You can return the answer in any order.

        Example 1:
        Input: nums = [2,7,11,15], target = 9
        Output: [0,1]
        Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

        Example 2:
        Input: nums = [3,2,4], target = 6
        Output: [1,2]

        Example 3:
        Input: nums = [3,3], target = 6
        Output: [0,1]
    */
    internal class _1_Two_Sum
    {
        /*
            Two loops iterate through the array and test the sums of all the elements until they find the satisfying pair
        */
        static int[]? FirstSolution(int[] nums, int target)
        {
            for (int i = 0; i < nums.Count(); i++)
            {
                for (int j = i + 1; j < nums.Count(); j++)
                {
                    if (nums[i] + nums[j] == target)    // If the sum is equal to the target - the pair has been found
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return null;
        }

        /*
            We iterate through the array and for each element we enter key-value pairs in the Dictionary:
                Key: Difference between the value of this element and the Target value (Element Key = Target value - Element value)
                Val: Index of this element

            Now we keep iterating and adding to the Dictionary, until we reach the element whose value matches the Key
            of another element already in the Dictionary (i.e. matches it's remainder to the Target value).
        */
        static int[]? SecondSolution(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))  // If the element's value matches the Key of another element in the Dictionary - the pair has been found
                    return new int[] { dict[nums[i]], i };
                dict[target - nums[i]] = i; // Add the element to the Dictionary
            }

            return null;
        }

        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("1 - Two Sum\n");

            Console.WriteLine("Test -> Input=[2,7,4], Target=9, expected result: [0,1]");
            int[]? Result_First = FirstSolution(new int[] { 2, 7, 4 }, 9);
            int[]? Result_Second = SecondSolution(new int[] { 2, 7, 4 }, 9);

            if (Result_First is not null)
                Console.WriteLine($"First solution: [{Result_First[0]},{Result_First[1]}]");
            else
                Console.WriteLine("The result of the first solution is null!");

            if (Result_Second is not null)
                Console.WriteLine($"Second solution: [{Result_Second[0]},{Result_Second[1]}]");
            else
                Console.WriteLine("The result of the second solution is null!");
        }
    }
}
