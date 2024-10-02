using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lee_code
{
    public class Functii
    {

        /*Given a m x n matrix grid which is sorted in non-increasing order both row-wise and column-wise, return the number of negative numbers in grid.

 

Example 1:

Input: grid = [[4,3,2,-1],[3,2,1,-1],[1,1,-1,-2],[-1,-1,-2,-3]]
Output: 8
Explanation: There are 8 negatives number in the matrix.
Example 2:

Input: grid = [[3,2],[1,0]]
Output: 0
 */
        public int CountNegatives(int[][] grid)
        {
            int ct = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] < 0) ct++;
                }
            }

            return ct;
        }

        /*Given an array arr of integers, check if there exist two indices i and j such that :

i != j
0 <= i, j < arr.length
arr[i] == 2 * arr[j]
 

Example 1:

Input: arr = [10,2,5,3]
Output: true
Explanation: For i = 0 and j = 2, arr[i] == 10 == 2 * 5 == 2 * arr[j]
Example 2:

Input: arr = [3,1,7,11]
Output: false
Explanation: There is no i and j that satisfy the conditions.
 */
        public bool CheckIfExist(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for(int j=0;j<arr.Length; j++)
                {
                    if (i!=j && arr[i] == 2 * arr[j]) return true;
                }
            }

            return false;
        }

        /*Given two arrays of integers nums and index. Your task is to create target array under the following rules:

Initially target array is empty.
From left to right read nums[i] and index[i], insert at index index[i] the value nums[i] in target array.
Repeat the previous step until there are no elements to read in nums and index.
Return the target array.

It is guaranteed that the insertion operations will be valid.

 

Example 1:

Input: nums = [0,1,2,3,4], index = [0,1,2,2,1]
Output: [0,4,1,3,2]
Explanation:
nums       index     target
0            0        [0]
1            1        [0,1]
2            2        [0,1,2]
3            2        [0,1,3,2]
4            1        [0,4,1,3,2]
Example 2:

Input: nums = [1,2,3,4,0], index = [0,1,2,3,0]
Output: [0,1,2,3,4]
Explanation:
nums       index     target
1            0        [1]
2            1        [1,2]
3            2        [1,2,3]
4            3        [1,2,3,4]
0            0        [0,1,2,3,4]
Example 3:

Input: nums = [1], index = [0]
Output: [1]*/
        public void insert(int[] arr, int p)
        {
            for (int i = arr.Length-2; i >= p; i--) {
                arr[i+1] = arr[i];
            }
            arr[p] = -1;
        }
        public int[] CreateTargetArray(int[] nums, int[] index)
        {
            int[] nou = new int[nums.Length];
            Array.Fill(nou, -1);
            for(int i = 0; i < nums.Length; i++)
            {
                if (nou[index[i]] == -1)
                nou[index[i]] = nums[i];
                else
                {
                    insert(nou, index[i]);
                    nou[index[i]] = nums[i];
                }
            }

            return nou;
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
Output: 5
*/
        public int MinStartValue(int[] nums)
        {
            int startValue = 1;
            int minSum = 0;
            int currentSum = 0;

            foreach (int num in nums)
            {
                currentSum += num;
                minSum = Math.Min(minSum, currentSum);
            }

            if (minSum < 0)
            {
                startValue = Math.Abs(minSum) + 1;
            }

            return startValue;
        }

        /*Given the array nums, obtain a subsequence of the array whose sum of elements is strictly greater than the sum of the non included elements in such subsequence. 

If there are multiple solutions, return the subsequence with minimum size and if there still exist multiple solutions, return the subsequence with the maximum total sum of all its elements. A subsequence of an array can be obtained by erasing some (possibly zero) elements from the array. 

Note that the solution with the given constraints is guaranteed to be unique. Also return the answer sorted in non-increasing order.

 

Example 1:

Input: nums = [4,3,10,9,8]
Output: [10,9] 
Explanation: The subsequences [10,9] and [10,8] are minimal such that the sum of their elements is strictly greater than the sum of elements not included. However, the subsequence [10,9] has the maximum total sum of its elements. 
Example 2:

Input: nums = [4,4,7,6,7]
Output: [7,7,6] 
Explanation: The subsequence [7,7] has the sum of its elements equal to 14 which is not strictly greater than the sum of elements not included (14 = 4 + 4 + 6). Therefore, the subsequence [7,6,7] is the minimal satisfying the conditions. Note the subsequence has to be returned in non-increasing order.*/
        public List<int> MinSubsequence(int[] nums)
        {
            Array.Sort(nums, (a, b) => b - a);

            int totalSum = 0;
            foreach (int num in nums)
            {
                totalSum += num;
            }

            List<int> result = new List<int>();
            int s = 0;

            foreach (int num in nums)
            {
                s += num;
                result.Add(num);

                if (s > totalSum - s)
                {
                    break;
                }
            }

            return result;
        }

        /*Given an array of string words, return all strings in words that is a substring of another word. You can return the answer in any order.

A substring is a contiguous sequence of characters within a string

 

Example 1:

Input: words = ["mass","as","hero","superhero"]
Output: ["as","hero"]
Explanation: "as" is substring of "mass" and "hero" is substring of "superhero".
["hero","as"] is also a valid answer.
Example 2:

Input: words = ["leetcode","et","code"]
Output: ["et","code"]
Explanation: "et", "code" are substring of "leetcode".
Example 3:

Input: words = ["blue","green","bu"]
Output: []
Explanation: No string of words is substring of another string.
 */
        public List<string> StringMatching(string[] words)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    if (i != j && words[j].Contains(words[i]))
                    {
                        result.Add(words[i]);
                        break;
                    }
                }
            }

            return result;
        }

        /*You are given an alphanumeric string s. (Alphanumeric string is a string consisting of lowercase English letters and digits).

You have to find a permutation of the string where no letter is followed by another letter and no digit is followed by another digit. That is, no two adjacent characters have the same type.

Return the reformatted string or return an empty string if it is impossible to reformat the string.



Example 1:

Input: s = "a0b1c2"
Output: "0a1b2c"
Explanation: No two adjacent characters have the same type in "0a1b2c". "a0b1c2", "0a1b2c", "0c2a1b" are also valid permutations.
Example 2:

Input: s = "leetcode"
Output: ""
Explanation: "leetcode" has only characters so we cannot separate them by digits.
Example 3:

Input: s = "1229857369"
Output: ""
Explanation: "1229857369" has only digits so we cannot separate them by characters.*/
        public string Reformat(string s)
        {
            List<char> letters = new List<char>();
            List<char> digits = new List<char>();
            foreach (char c in s)
            {
                if (char.IsLetter(c))
                {
                    letters.Add(c);
                }
                else if (char.IsDigit(c))
                {
                    digits.Add(c);
                }
            }
            if (Math.Abs(letters.Count - digits.Count) > 1)
            {
                return "";
            }
            bool lettersFirst = letters.Count > digits.Count;

            List<char> result = new List<char>();
            int i = 0, j = 0;

            while (i < letters.Count || j < digits.Count)
            {
                if (lettersFirst && i < letters.Count)
                {
                    result.Add(letters[i++]);
                    lettersFirst = false;
                }
                else if (!lettersFirst && j < digits.Count)
                {
                    result.Add(digits[j++]);
                    lettersFirst = true;
                }
            }

            return new string(result.ToArray());
        }

        /*The power of the string is the maximum length of a non-empty substring that contains only one unique character.

Given a string s, return the power of s.

 

Example 1:

Input: s = "leetcode"
Output: 2
Explanation: The substring "ee" is of length 2 with the character 'e' only.
Example 2:

Input: s = "abbcccddddeeeeedcba"
Output: 5
Explanation: The substring "eeeee" is of length 5 with the character 'e' only.*/
        public int MaxPower(string s)
        {
            int maxPower = 1;
            int currentPower = 1;

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1])
                {
                    currentPower++;
                    maxPower = Math.Max(maxPower, currentPower);
                }
                else
                {
                    currentPower = 1;
                }
            }

            return maxPower;
        }

        /*You are given the array paths, where paths[i] = [cityAi, cityBi] means there exists a direct path going from cityAi to cityBi. Return the destination city, that is, the city without any path outgoing to another city.

It is guaranteed that the graph of paths forms a line without any loop, therefore, there will be exactly one destination city.

 

Example 1:

Input: paths = [["London","New York"],["New York","Lima"],["Lima","Sao Paulo"]]
Output: "Sao Paulo" 
Explanation: Starting at "London" city you will reach "Sao Paulo" city which is the destination city. Your trip consist of: "London" -> "New York" -> "Lima" -> "Sao Paulo".
Example 2:

Input: paths = [["B","C"],["D","B"],["C","A"]]
Output: "A"
Explanation: All possible trips are: 
"D" -> "B" -> "C" -> "A". 
"B" -> "C" -> "A". 
"C" -> "A". 
"A". 
Clearly the destination city is "A".
Example 3:

Input: paths = [["A","Z"]]
Output: "Z"
 */
        public string DestCity(List<List<string>> paths)
        {
            HashSet<string> startingCities = new HashSet<string>();

            foreach (var path in paths)
            {
                startingCities.Add(path[0]);
            }

            foreach (var path in paths)
            {
                if (!startingCities.Contains(path[1]))
                {
                    return path[1];
                }
            }

            return "";
        }

        /*Given a string s of zeros and ones, return the maximum score after splitting the string into two non-empty substrings (i.e. left substring and right substring).

The score after splitting a string is the number of zeros in the left substring plus the number of ones in the right substring.

 

Example 1:

Input: s = "011101"
Output: 5 
Explanation: 
All possible ways of splitting s into two non-empty substrings are:
left = "0" and right = "11101", score = 1 + 4 = 5 
left = "01" and right = "1101", score = 1 + 3 = 4 
left = "011" and right = "101", score = 1 + 2 = 3 
left = "0111" and right = "01", score = 1 + 1 = 2 
left = "01110" and right = "1", score = 2 + 1 = 3
Example 2:

Input: s = "00111"
Output: 5
Explanation: When left = "00" and right = "111", we get the maximum score = 2 + 3 = 5
Example 3:

Input: s = "1111"
Output: 3*/
        public int MaxScore(string s)
        {
            int maxScore = 0;

            for (int i = 1; i < s.Length; i++)
            {
                int leftScore = 0;
                int rightScore = 0;

                for (int j = 0; j < i; j++)
                {
                    if (s[j] == '0')
                    {
                        leftScore++;
                    }
                }

                for (int j = i; j < s.Length; j++)
                {
                    if (s[j] == '1')
                    {
                        rightScore++;
                    }
                }
                maxScore = Math.Max(maxScore, leftScore + rightScore);
            }

            return maxScore;
        }



    }
}
