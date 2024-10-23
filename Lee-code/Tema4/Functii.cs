using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema4
{
    public class Functii
    {

        /*There are numBottles water bottles that are initially full of water. You can exchange numExchange empty water bottles from the market with one full water bottle.

The operation of drinking a full water bottle turns it into an empty bottle.

Given the two integers numBottles and numExchange, return the maximum number of water bottles you can drink.

 

Example 1:


Input: numBottles = 9, numExchange = 3
Output: 13
Explanation: You can exchange 3 empty bottles to get 1 full water bottle.
Number of water bottles you can drink: 9 + 3 + 1 = 13.
Example 2:


Input: numBottles = 15, numExchange = 4
Output: 19
Explanation: You can exchange 4 empty bottles to get 1 full water bottle. 
Number of water bottles you can drink: 15 + 3 + 1 = 19.
 */
        public int NumWaterBottles(int b, int e)
        {
            int total = b;
            while (b >= e)
            {
                int newB = b / e;
                total += newB;
                b = newB + (b % e);
            }
            return total;
        }

        /*Given an array arr of positive integers sorted in a strictly increasing order, and an integer k.

Return the kth positive integer that is missing from this array.

 

Example 1:

Input: arr = [2,3,4,7,11], k = 5
Output: 9
Explanation: The missing positive integers are [1,5,6,8,9,10,12,13,...]. The 5th missing positive integer is 9.
Example 2:

Input: arr = [1,2,3,4], k = 2
Output: 6
Explanation: The missing positive integers are [5,6,7,...]. The 2nd missing positive integer is 6.*/
        public int KthMissing(int[] arr, int k)
        {
            int missCount = 0;
            int currNum = 1;
            int i = 0;

            while (missCount < k)
            {
                if (i < arr.Length && arr[i] == currNum)
                {
                    i++;
                }
                else
                {
                    missCount++;
                    if (missCount == k)
                    {
                        return currNum;
                    }
                }
                currNum++;
            }
            return -1;
        }

        /*You are given a string s and an integer array indices of the same length. The string s will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.

Return the shuffled string.

 

Example 1:


Input: s = "codeleet", indices = [4,5,6,7,0,2,1,3]
Output: "leetcode"
Explanation: As shown, "codeleet" becomes "leetcode" after shuffling.
Example 2:

Input: s = "abc", indices = [0,1,2]
Output: "abc"
Explanation: After shuffling, each character remains in its position.*/
        public string ShuffleString(string s, int[] idx)
        {
            char[] shuffled = new char[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                shuffled[idx[i]] = s[i];
            }

            return new string(shuffled);
        }

        /*Given an array of integers arr, and three integers a, b and c. You need to find the number of good triplets.

A triplet (arr[i], arr[j], arr[k]) is good if the following conditions are true:

0 <= i < j < k < arr.length
|arr[i] - arr[j]| <= a
|arr[j] - arr[k]| <= b
|arr[i] - arr[k]| <= c
Where |x| denotes the absolute value of x.

Return the number of good triplets.

 

Example 1:

Input: arr = [3,0,1,1,9,7], a = 7, b = 2, c = 3
Output: 4
Explanation: There are 4 good triplets: [(3,0,1), (3,0,1), (3,1,1), (0,1,1)].
Example 2:

Input: arr = [1,1,2,2,3], a = 0, b = 0, c = 1
Output: 0
Explanation: No triplet satisfies all conditions.*/
        public int CountGoodTriplets(int[] arr, int a, int b, int c)
        {
            int count = 0;

            for (int i = 0; i < arr.Length - 2; i++)
            {
                for (int j = i + 1; j < arr.Length - 1; j++)
                {
                    for (int k = j + 1; k < arr.Length; k++)
                    {
                        if (Math.Abs(arr[i] - arr[j]) <= a &&
                            Math.Abs(arr[j] - arr[k]) <= b &&
                            Math.Abs(arr[i] - arr[k]) <= c)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        /*Given an integer n, add a dot (".") as the thousands separator and return it in string format.

 

Example 1:

Input: n = 987
Output: "987"
Example 2:

Input: n = 1234
Output: "1.234"*/
        public string ThousandSeparator(int n)
        {
            string numStr = n.ToString();
            string result = "";
            int len = numStr.Length;

            for (int i = 0; i < len; i++)
            {
                result += numStr[i];

                if ((len - i - 1) % 3 == 0 && (len - i - 1) != 0)
                {
                    result += '.';
                }
            }

            return result;
        }

        /*Given a string s of lower and upper case English letters.

A good string is a string which doesn't have two adjacent characters s[i] and s[i + 1] where:

0 <= i <= s.length - 2
s[i] is a lower-case letter and s[i + 1] is the same letter but in upper-case or vice-versa.
To make the string good, you can choose two adjacent characters that make the string bad and remove them. You can keep doing this until the string becomes good.

Return the string after making it good. The answer is guaranteed to be unique under the given constraints.

Notice that an empty string is also good.

 

Example 1:

Input: s = "leEeetcode"
Output: "leetcode"
Explanation: In the first step, either you choose i = 1 or i = 2, both will result "leEeetcode" to be reduced to "leetcode".
Example 2:

Input: s = "abBAcC"
Output: ""
Explanation: We have many possible scenarios, and all lead to the same answer. For example:
"abBAcC" --> "aAcC" --> "cC" --> ""
"abBAcC" --> "abBA" --> "aA" --> ""
Example 3:

Input: s = "s"
Output: "s"*/
        public string MakeGood(string s)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in s)
            {
                if (result.Length > 0 &&
                    Math.Abs(result[result.Length - 1] - c) == 32)
                {
                    result.Length--;
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        /*Given a square matrix mat, return the sum of the matrix diagonals.

Only include the sum of all the elements on the primary diagonal and all the elements on the secondary diagonal that are not part of the primary diagonal.

 

Example 1:


Input: mat = [[1,2,3],
              [4,5,6],
              [7,8,9]]
Output: 25
Explanation: Diagonals sum: 1 + 5 + 9 + 3 + 7 = 25
Notice that element mat[1][1] = 5 is counted only once.
Example 2:

Input: mat = [[1,1,1,1],
              [1,1,1,1],
              [1,1,1,1],
              [1,1,1,1]]
Output: 8
Example 3:

Input: mat = [[5]]
Output: 5*/
        public int DiagonalSum(int[][] mat)
        {
            int n = mat.Length;
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += mat[i][i];
                sum += mat[i][n - 1 - i];
            }

            if (n % 2 == 1)
            {
                sum -= mat[n / 2][n / 2];
            }

            return sum;
        }

        /*Given an integer n and an integer array rounds. We have a circular track which consists of n sectors labeled from 1 to n. A marathon will be held on this track, the marathon consists of m rounds. The ith round starts at sector rounds[i - 1] and ends at sector rounds[i]. For example, round 1 starts at sector rounds[0] and ends at sector rounds[1]

Return an array of the most visited sectors sorted in ascending order.

Notice that you circulate the track in ascending order of sector numbers in the counter-clockwise direction (See the first example).

 

Example 1:


Input: n = 4, rounds = [1,3,1,2]
Output: [1,2]
Explanation: The marathon starts at sector 1. The order of the visited sectors is as follows:
1 --> 2 --> 3 (end of round 1) --> 4 --> 1 (end of round 2) --> 2 (end of round 3 and the marathon)
We can see that both sectors 1 and 2 are visited twice and they are the most visited sectors. Sectors 3 and 4 are visited only once.
Example 2:

Input: n = 2, rounds = [2,1,2,1,2,1,2,1,2]
Output: [2]
Example 3:

Input: n = 7, rounds = [1,3,5,7]
Output: [1,2,3,4,5,6,7]*/
        public int[] MostVisited(int n, int[] rounds)
        {
            int[] visits = new int[n + 1];
            int start = rounds[0];
            int m = rounds.Length;

            for (int i = 1; i < m; i++)
            {
                int end = rounds[i];

                if (start <= end)
                {
                    for (int j = start; j <= end; j++)
                    {
                        visits[j]++;
                    }
                }
                else
                {
                    for (int j = start; j <= n; j++)
                    {
                        visits[j]++;
                    }
                    for (int j = 1; j <= end; j++)
                    {
                        visits[j]++;
                    }
                }
                start = end;
            }

            int maxVisits = 0;
            for (int i = 1; i <= n; i++)
            {
                if (visits[i] > maxVisits)
                {
                    maxVisits = visits[i];
                }
            }

            List<int> result = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                if (visits[i] == maxVisits)
                {
                    result.Add(i);
                }
            }

            return result.ToArray();
        }

        /*Given an array of positive integers arr, find a pattern of length m that is repeated k or more times.

A pattern is a subarray (consecutive sub-sequence) that consists of one or more values, repeated multiple times consecutively without overlapping. A pattern is defined by its length and the number of repetitions.

Return true if there exists a pattern of length m that is repeated k or more times, otherwise return false.

 

Example 1:

Input: arr = [1,2,4,4,4,4], m = 1, k = 3
Output: true
Explanation: The pattern (4) of length 1 is repeated 4 consecutive times. Notice that pattern can be repeated k or more times but not less.
Example 2:

Input: arr = [1,2,1,2,1,1,1,3], m = 2, k = 2
Output: true
Explanation: The pattern (1,2) of length 2 is repeated 2 consecutive times. Another valid pattern (2,1) is also repeated 2 times.
Example 3:

Input: arr = [1,2,1,2,1,3], m = 2, k = 3
Output: false
Explanation: The pattern (1,2) is of length 2 but is repeated only 2 times. There is no pattern of length 2 that is repeated 3 or more times.*/
        public bool ContainsPattern(int[] arr, int m, int k)
        {
            int n = arr.Length;

            for (int i = 0; i <= n - m * k; i++)
            {
                bool isPattern = true;
                for (int j = 1; j < k; j++)
                {
                    for (int l = 0; l < m; l++)
                    {
                        if (arr[i + l] != arr[i + j * m + l])
                        {
                            isPattern = false;
                            break;
                        }
                    }

                    if (!isPattern)
                        break;
                }

                if (isPattern)
                {
                    return true;
                }
            }

            return false;
        }

        /*Given an array of positive integers arr, return the sum of all possible odd-length subarrays of arr.

A subarray is a contiguous subsequence of the array.

 

Example 1:

Input: arr = [1,4,2,5,3]
Output: 58
Explanation: The odd-length subarrays of arr and their sums are:
[1] = 1
[4] = 4
[2] = 2
[5] = 5
[3] = 3
[1,4,2] = 7
[4,2,5] = 11
[2,5,3] = 10
[1,4,2,5,3] = 15
If we add all these together we get 1 + 4 + 2 + 5 + 3 + 7 + 11 + 10 + 15 = 58
Example 2:

Input: arr = [1,2]
Output: 3
Explanation: There are only 2 subarrays of odd length, [1] and [2]. Their sum is 3.
Example 3:

Input: arr = [10,11,12]
Output: 66*/
        public int SumOddLengthSubarrays(int[] arr)
        {
            int totalSum = 0;
            int n = arr.Length;

            for (int i = 0; i < n; i++)
            {
                int oddStart = (i + 1);
                int oddEnd = (n - i);

                int oddCount = (oddStart * oddEnd + 1) / 2;

                totalSum += arr[i] * oddCount;
            }

            return totalSum;
        }








































    }
}
