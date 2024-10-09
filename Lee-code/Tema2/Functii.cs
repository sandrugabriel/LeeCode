using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema2
{
    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
     }
    public class Functii
    {

        /*Given two integer arrays arr1 and arr2, and the integer d, return the distance value between the two arrays.

The distance value is defined as the number of elements arr1[i] such that there is not any element arr2[j] where |arr1[i]-arr2[j]| <= d.

 

Example 1:

Input: arr1 = [4,5,8], arr2 = [10,9,1,8], d = 2
Output: 2
Explanation: 
For arr1[0]=4 we have: 
|4-10|=6 > d=2 
|4-9|=5 > d=2 
|4-1|=3 > d=2 
|4-8|=4 > d=2 
For arr1[1]=5 we have: 
|5-10|=5 > d=2 
|5-9|=4 > d=2 
|5-1|=4 > d=2 
|5-8|=3 > d=2
For arr1[2]=8 we have:
|8-10|=2 <= d=2
|8-9|=1 <= d=2
|8-1|=7 > d=2
|8-8|=0 <= d=2
Example 2:

Input: arr1 = [1,4,2,3], arr2 = [-4,-3,6,10,20,30], d = 3
Output: 2
Example 3:

Input: arr1 = [2,1,100,3], arr2 = [-5,-2,10,-3,7], d = 6
Output: 1*/
        public int FindDistanceValue(int[] a1, int[] a2, int d)
        {
            int count = 0;
            foreach (int x in a1)
            {
                bool found = false;
                foreach (int y in a2)
                {
                    if (Math.Abs(x - y) <= d)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    count++;
                }
            }
            return count;
        }

        /*Given an integer n, return a string with n characters such that each character in such string occurs an odd number of times.

The returned string must contain only lowercase English letters. If there are multiples valid strings, return any of them.  

 

Example 1:

Input: n = 4
Output: "pppz"
Explanation: "pppz" is a valid string since the character 'p' occurs three times and the character 'z' occurs once. Note that there are many other valid strings such as "ohhh" and "love".
Example 2:

Input: n = 2
Output: "xy"
Explanation: "xy" is a valid string since the characters 'x' and 'y' occur once. Note that there are many other valid strings such as "ag" and "ur".
Example 3:

Input: n = 7
Output: "holasss"*/
        public string GenerateString(int n)
        {
            char[] result = new char[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = (char)('a' + (i % 26));
            }

            if (n % 2 == 0)
            {
                result[n - 1] = result[n - 2];
            }

            return new string(result);
        }

        /*Given an m x n matrix of distinct numbers, return all lucky numbers in the matrix in any order.

A lucky number is an element of the matrix such that it is the minimum element in its row and maximum in its column.

 

Example 1:

Input: matrix = [[3,7,8],[9,11,13],[15,16,17]]
Output: [15]
Explanation: 15 is the only lucky number since it is the minimum in its row and the maximum in its column.
Example 2:

Input: matrix = [[1,10,4,2],[9,3,8,7],[15,16,17,12]]
Output: [12]
Explanation: 12 is the only lucky number since it is the minimum in its row and the maximum in its column.
Example 3:

Input: matrix = [[7,8],[1,2]]
Output: [7]
Explanation: 7 is the only lucky number since it is the minimum in its row and the maximum in its column.*/
        public IList<int> LuckyNumbers(int[][] matrix)
        {
            List<int> luckyNums = new List<int>();
            int m = matrix.Length;
            int n = matrix[0].Length;

            for (int i = 0; i < m; i++)
            {
                int minIdx = 0;
                int minVal = matrix[i][0];

                for (int j = 1; j < n; j++)
                {
                    if (matrix[i][j] < minVal)
                    {
                        minVal = matrix[i][j];
                        minIdx = j;
                    }
                }

                bool isLucky = true;
                for (int k = 0; k < m; k++)
                {
                    if (matrix[k][minIdx] > minVal)
                    {
                        isLucky = false;
                        break;
                    }
                }

                if (isLucky)
                {
                    luckyNums.Add(minVal);
                }
            }

            return luckyNums;
        }

        /*Given two binary trees original and cloned and given a reference to a node target in the original tree.

The cloned tree is a copy of the original tree.

Return a reference to the same node in the cloned tree.

Note that you are not allowed to change any of the two trees or the target node and the answer must be a reference to a node in the cloned tree.

 

Example 1:


Input: tree = [7,4,3,null,null,6,19], target = 3
Output: 3
Explanation: In all examples the original and cloned trees are shown. The target node is a green node from the original tree. The answer is the yellow node from the cloned tree.
Example 2:


Input: tree = [7], target =  7
Output: 7
Example 3:


Input: tree = [8,null,6,null,5,null,4,null,3,null,2,null,1], target = 4
Output: 4
 */
        public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {
            if (cloned == null) return null;

            if (cloned.val == target.val)
            {
                return cloned;
            }

            TreeNode leftResult = GetTargetCopy(original, cloned.left, target);
            if (leftResult != null) return leftResult;

            return GetTargetCopy(original, cloned.right, target);
        }

        /*You are given an integer n.

Each number from 1 to n is grouped according to the sum of its digits.

Return the number of groups that have the largest size.



Example 1:

Input: n = 13
Output: 4
Explanation: There are 9 groups in total, they are grouped according sum of its digits of numbers from 1 to 13:
[1,10], [2,11], [3,12], [4,13], [5], [6], [7], [8], [9].
There are 4 groups with largest size.
Example 2:

Input: n = 2
Output: 2
Explanation: There are 2 groups [1], [2] of size 1.*/
        public int CountLargestGroup(int n)
        {
            Dictionary<int, int> groupSize = new Dictionary<int, int>();
            int maxSize = 0;

            for (int i = 1; i <= n; i++)
            {
                int sum = DigitSum(i);
                if (groupSize.ContainsKey(sum))
                {
                    groupSize[sum]++;
                }
                else
                {
                    groupSize[sum] = 1;
                }
                maxSize = Math.Max(maxSize, groupSize[sum]);
            }

            int count = 0;
            foreach (var size in groupSize.Values)
            {
                if (size == maxSize)
                {
                    count++;
                }
            }

            return count;
        }
        private int DigitSum(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }

        /*Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.

Return the largest lucky integer in the array. If there is no lucky integer return -1.

 

Example 1:

Input: arr = [2,2,3,4]
Output: 2
Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
Example 2:

Input: arr = [1,2,2,3,3,3]
Output: 3
Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.
Example 3:

Input: arr = [2,2,2,3,3]
Output: -1
Explanation: There are no lucky numbers in the array.*/
        public int FindLucky(int[] arr)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            int largestLucky = -1;

            foreach (int num in arr)
            {
                if (freq.ContainsKey(num))
                {
                    freq[num]++;
                }
                else
                {
                    freq[num] = 1;
                }
            }

            foreach (var kv in freq)
            {
                if (kv.Key == kv.Value && kv.Key > largestLucky)
                {
                    largestLucky = kv.Key;
                }
            }

            return largestLucky;
        }

        /*Given an array of integers nums, you start with an initial positive value startValue.

In each iteration, you calculate the step by step sum of startValue plus elements in nums (from left to right).

Return the minimum positive value of startValue such that the step by step sum is never less than 1.

 

Example 1:

Input: nums = [-3,2,-3,4,2]
Output: 5
Explanation: If you choose startValue = 4, in the third iteration your step by step sum is less than 1.
step by step sum
startValue = 4 | startValue = 5 | nums
  (4 -3 ) = 1  | (5 -3 ) = 2    |  -3
  (1 +2 ) = 3  | (2 +2 ) = 4    |   2
  (3 -3 ) = 0  | (4 -3 ) = 1    |  -3
  (0 +4 ) = 4  | (1 +4 ) = 5    |   4
  (4 +2 ) = 6  | (5 +2 ) = 7    |   2
Example 2:

Input: nums = [1,2]
Output: 1
Explanation: Minimum start value should be positive. 
Example 3:

Input: nums = [1,-2,-3]
Output: 5*/
        public int MinStartValue(int[] nums)
        {
            int minSum = 0;
            int currentSum = 0;

            foreach (int num in nums)
            {
                currentSum += num;
                minSum = Math.Min(minSum, currentSum);
            }

            return 1 - minSum > 0 ? 1 - minSum : 1;
        }

        /*There are n kids with candies. You are given an integer array candies, where each candies[i] represents the number of candies the ith kid has, and an integer extraCandies, denoting the number of extra candies that you have.

Return a boolean array result of length n, where result[i] is true if, after giving the ith kid all the extraCandies, they will have the greatest number of candies among all the kids, or false otherwise.

Note that multiple kids can have the greatest number of candies.

 

Example 1:

Input: candies = [2,3,5,1,3], extraCandies = 3
Output: [true,true,true,false,true] 
Explanation: If you give all extraCandies to:
- Kid 1, they will have 2 + 3 = 5 candies, which is the greatest among the kids.
- Kid 2, they will have 3 + 3 = 6 candies, which is the greatest among the kids.
- Kid 3, they will have 5 + 3 = 8 candies, which is the greatest among the kids.
- Kid 4, they will have 1 + 3 = 4 candies, which is not the greatest among the kids.
- Kid 5, they will have 3 + 3 = 6 candies, which is the greatest among the kids.
Example 2:

Input: candies = [4,2,1,1,2], extraCandies = 1
Output: [true,false,false,false,false] 
Explanation: There is only 1 extra candy.
Kid 1 will always have the greatest number of candies, even if a different kid is given the extra candy.
Example 3:

Input: candies = [12,1,12], extraCandies = 10
Output: [true,false,true]
 */
        public bool[] KidsWithCandies(int[] candies, int extraCandies)
        {
            int maxCandies = 0;
            int n = candies.Length;

            for (int i = 0; i < n; i++)
            {
                if (candies[i] > maxCandies)
                {
                    maxCandies = candies[i];
                }
            }

            bool[] result = new bool[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = (candies[i] + extraCandies >= maxCandies);
            }

            return result;
        }

        /*Given an binary array nums and an integer k, return true if all 1's are at least k places away from each other, otherwise return false.

 

Example 1:


Input: nums = [1,0,0,0,1,0,0,1], k = 2
Output: true
Explanation: Each of the 1s are at least 2 places away from each other.
Example 2:


Input: nums = [1,0,0,1,0,1], k = 2
Output: false
Explanation: The second 1 and third 1 are only one apart from each other.*/
        public bool KLengthApart(int[] nums, int k)
        {
            int lastPos = -1;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    if (lastPos != -1 && i - lastPos <= k)
                    {
                        return false;
                    }
                    lastPos = i;
                }
            }

            return true;
        }

        /*You are given two integer arrays of equal length target and arr. In one step, you can select any non-empty subarray of arr and reverse it. You are allowed to make any number of steps.

Return true if you can make arr equal to target or false otherwise.

 

Example 1:

Input: target = [1,2,3,4], arr = [2,4,1,3]
Output: true
Explanation: You can follow the next steps to convert arr to target:
1- Reverse subarray [2,4,1], arr becomes [1,4,2,3]
2- Reverse subarray [4,2], arr becomes [1,2,4,3]
3- Reverse subarray [4,3], arr becomes [1,2,3,4]
There are multiple ways to convert arr to target, this is not the only way to do so.
Example 2:

Input: target = [7], arr = [7]
Output: true
Explanation: arr is equal to target without any reverses.
Example 3:

Input: target = [3,7,9], arr = [3,7,11]
Output: false
Explanation: arr does not have value 9 and it can never be converted to target.*/
        public bool CanBeEqual(int[] target, int[] arr)
        {
            Array.Sort(target);
            Array.Sort(arr);

            return target.SequenceEqual(arr);
        }



























    }
}
