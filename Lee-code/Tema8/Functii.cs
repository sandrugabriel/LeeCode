using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema8
{
    public class Functii
    {

        /*You are given a string time in the form of  hh:mm, where some of the digits in the string are hidden (represented by ?).

The valid times are those inclusively between 00:00 and 23:59.

Return the latest valid time you can get from time by replacing the hidden digits.

 

Example 1:

Input: time = "2?:?0"
Output: "23:50"
Explanation: The latest hour beginning with the digit '2' is 23 and the latest minute ending with the digit '0' is 50.
Example 2:

Input: time = "0?:3?"
Output: "09:39"
Example 3:

Input: time = "1?:22"
Output: "19:22"
 */
        public string MaximumTime(string time)
        {
            char[] a = time.ToCharArray();

            if (a[0] == '?') a[0] = (a[1] == '?' || a[1] <= '3') ? '2' : '1';
            if (a[1] == '?') a[1] = (a[0] == '2') ? '3' : '9';

            if (a[3] == '?') a[3] = '5';
            if (a[4] == '?') a[4] = '9';

            return new string(a);

        }

        /*A string s is nice if, for every letter of the alphabet that s contains, it appears both in uppercase and lowercase. For example, "abABB" is nice because 'A' and 'a' appear, and 'B' and 'b' appear. However, "abA" is not because 'b' appears, but 'B' does not.

Given a string s, return the longest substring of s that is nice. If there are multiple, return the substring of the earliest occurrence. If there are none, return an empty string.

 

Example 1:

Input: s = "YazaAay"
Output: "aAa"
Explanation: "aAa" is a nice string because 'A/a' is the only letter of the alphabet in s, and both 'A' and 'a' appear.
"aAa" is the longest nice substring.
Example 2:

Input: s = "Bb"
Output: "Bb"
Explanation: "Bb" is a nice string because both 'B' and 'b' appear. The whole string is a substring.
Example 3:

Input: s = "c"
Output: ""
Explanation: There are no nice substrings.*/
        public string LongestNiceSubstring(string s)
        {
            if (s.Length < 2) return string.Empty;

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (s.Contains(char.ToLower(c)) && s.Contains(char.ToUpper(c)))
                    continue;

                string left = LongestNiceSubstring(s.Substring(0, i));
                string right = LongestNiceSubstring(s.Substring(i + 1));

                return left.Length >= right.Length ? left : right;
            }

            return s;
        }

        /*Given an array nums, return true if the array was originally sorted in non-decreasing order, then rotated some number of positions (including zero). Otherwise, return false.

There may be duplicates in the original array.

Note: An array A rotated by x positions results in an array B of the same length such that A[i] == B[(i+x) % A.length], where % is the modulo operation.

 

Example 1:

Input: nums = [3,4,5,1,2]
Output: true
Explanation: [1,2,3,4,5] is the original sorted array.
You can rotate the array by x = 3 positions to begin on the the element of value 3: [3,4,5,1,2].
Example 2:

Input: nums = [2,1,3,4]
Output: false
Explanation: There is no sorted array once rotated that can make nums.
Example 3:

Input: nums = [1,2,3]
Output: true
Explanation: [1,2,3] is the original sorted array.
You can rotate the array by x = 0 positions (i.e. no rotation) to make nums.
 */
        public bool IsRotatedSortedArray(int[] nums)
        {
            int n = nums.Length;
            int breaks = 0;

            for (int i = 0; i < n; i++)
            {
                if (nums[i] > nums[(i + 1) % n])
                    breaks++;
                if (breaks > 1)
                    return false;
            }

            return true;
        }

        /*You are given a string s consisting only of the characters '0' and '1'. In one operation, you can change any '0' to '1' or vice versa.

The string is called alternating if no two adjacent characters are equal. For example, the string "010" is alternating, while the string "0100" is not.

Return the minimum number of operations needed to make s alternating.

 

Example 1:

Input: s = "0100"
Output: 1
Explanation: If you change the last character to '1', s will be "0101", which is alternating.
Example 2:

Input: s = "10"
Output: 0
Explanation: s is already alternating.
Example 3:

Input: s = "1111"
Output: 2
Explanation: You need two operations to reach "0101" or "1010".
 */
        public int MinOperationsToMakeAlternating(string s)
        {
            int alt1 = 0;
            int alt2 = 0;

            for (int i = 0; i < s.Length; i++)
            {
                char expectedAlt1 = (i % 2 == 0) ? '0' : '1';
                char expectedAlt2 = (i % 2 == 0) ? '1' : '0';

                if (s[i] != expectedAlt1) alt1++;
                if (s[i] != expectedAlt2) alt2++;
            }

            return Math.Min(alt1, alt2);
        }

        /*You are given two integers, x and y, which represent your current location on a Cartesian grid: (x, y). You are also given an array points where each points[i] = [ai, bi] represents that a point exists at (ai, bi). A point is valid if it shares the same x-coordinate or the same y-coordinate as your location.

Return the index (0-indexed) of the valid point with the smallest Manhattan distance from your current location. If there are multiple, return the valid point with the smallest index. If there are no valid points, return -1.

The Manhattan distance between two points (x1, y1) and (x2, y2) is abs(x1 - x2) + abs(y1 - y2).

 

Example 1:

Input: x = 3, y = 4, points = [[1,2],[3,1],[2,4],[2,3],[4,4]]
Output: 2
Explanation: Of all the points, only [3,1], [2,4] and [4,4] are valid. Of the valid points, [2,4] and [4,4] have the smallest Manhattan distance from your current location, with a distance of 1. [2,4] has the smallest index, so return 2.
Example 2:

Input: x = 3, y = 4, points = [[3,4]]
Output: 0
Explanation: The answer is allowed to be on the same location as your current location.
Example 3:

Input: x = 3, y = 4, points = [[2,3]]
Output: -1
Explanation: There are no valid points.
 */
        public int NearestValidPoint(int x, int y, int[][] points)
        {
            int minDistance = int.MaxValue;
            int resultIndex = -1;

            for (int i = 0; i < points.Length; i++)
            {
                int px = points[i][0];
                int py = points[i][1];

                if (px == x || py == y)
                {
                    int distance = Math.Abs(x - px) + Math.Abs(y - py);


                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        resultIndex = i;
                    }
                }
            }

            return resultIndex;
        }

        /*You are given an array items, where each items[i] = [typei, colori, namei] describes the type, color, and name of the ith item. You are also given a rule represented by two strings, ruleKey and ruleValue.

The ith item is said to match the rule if one of the following is true:

ruleKey == "type" and ruleValue == typei.
ruleKey == "color" and ruleValue == colori.
ruleKey == "name" and ruleValue == namei.
Return the number of items that match the given rule.

 

Example 1:

Input: items = [["phone","blue","pixel"],["computer","silver","lenovo"],["phone","gold","iphone"]], ruleKey = "color", ruleValue = "silver"
Output: 1
Explanation: There is only one item matching the given rule, which is ["computer","silver","lenovo"].
Example 2:

Input: items = [["phone","blue","pixel"],["computer","silver","phone"],["phone","gold","iphone"]], ruleKey = "type", ruleValue = "phone"
Output: 2
Explanation: There are only two items matching the given rule, which are ["phone","blue","pixel"] and ["phone","gold","iphone"]. Note that the item ["computer","silver","phone"] does not match.
 */
        public int CountMatches(List<List<string>> items, string ruleKey, string ruleValue)
        {
            int index = ruleKey == "type" ? 0 : (ruleKey == "color" ? 1 : 2);
            int count = 0;

            foreach (var item in items)
            {
                if (item[index] == ruleValue)
                    count++;
            }

            return count;
        }

        /*Given an alphanumeric string s, return the second largest numerical digit that appears in s, or -1 if it does not exist.

An alphanumeric string is a string consisting of lowercase English letters and digits.

 

Example 1:

Input: s = "dfa12321afd"
Output: 2
Explanation: The digits that appear in s are [1, 2, 3]. The second largest digit is 2.
Example 2:

Input: s = "abc1111"
Output: -1
Explanation: The digits that appear in s are [1]. There is no second largest digit. */
        public int SecondLargestDigit(string s)
        {
            HashSet<int> digits = new HashSet<int>();

            foreach (char c in s)
            {
                if (char.IsDigit(c))
                {
                    digits.Add(c - '0');
                }
            }

            if (digits.Count < 2)
                return -1;

            int max = int.MinValue, secondMax = int.MinValue;

            foreach (int d in digits)
            {
                if (d > max)
                {
                    secondMax = max;
                    max = d;
                }
                else if (d > secondMax)
                {
                    secondMax = d;
                }
            }

            return secondMax;
        }

        /*Given a binary string s ​​​​​without leading zeros, return true​​​ if s contains at most one contiguous segment of ones. Otherwise, return false.

 

Example 1:

Input: s = "1001"
Output: false
Explanation: The ones do not form a contiguous segment.
Example 2:

Input: s = "110"
Output: true*/
        public bool HasOneSegmentOfOnes(string s)
        {
            bool seenSegment = false;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '1')
                {
                    if (seenSegment && s[i - 1] == '0')
                    {
                        return false;
                    }
                    seenSegment = true;
                }
            }

            return true;
        }

        /*You are given two strings s1 and s2 of equal length. A string swap is an operation where you choose two indices in a string (not necessarily different) and swap the characters at these indices.

Return true if it is possible to make both strings equal by performing at most one string swap on exactly one of the strings. Otherwise, return false.

 

Example 1:

Input: s1 = "bank", s2 = "kanb"
Output: true
Explanation: For example, swap the first character with the last character of s2 to make "bank".
Example 2:

Input: s1 = "attack", s2 = "defend"
Output: false
Explanation: It is impossible to make them equal with one string swap.
Example 3:

Input: s1 = "kelb", s2 = "kelb"
Output: true
Explanation: The two strings are already equal, so no string swap operation is required.*/
        public bool CanBeEqualWithOneSwap(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;

            int diffCount = 0;
            char s1FirstDiff = '\0', s1SecondDiff = '\0';
            char s2FirstDiff = '\0', s2SecondDiff = '\0';

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    diffCount++;
                    if (diffCount == 1)
                    {
                        s1FirstDiff = s1[i];
                        s2FirstDiff = s2[i];
                    }
                    else if (diffCount == 2)
                    {
                        s1SecondDiff = s1[i];
                        s2SecondDiff = s2[i];
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return diffCount == 0 || (diffCount == 2 && s1FirstDiff == s2SecondDiff && s1SecondDiff == s2FirstDiff);
        }

        /*There is an undirected star graph consisting of n nodes labeled from 1 to n. A star graph is a graph where there is one center node and exactly n - 1 edges that connect the center node with every other node.

You are given a 2D integer array edges where each edges[i] = [ui, vi] indicates that there is an edge between the nodes ui and vi. Return the center of the given star graph.

 

Example 1:


Input: edges = [[1,2],[2,3],[4,2]]
Output: 2
Explanation: As shown in the figure above, node 2 is connected to every other node, so 2 is the center.
Example 2:

Input: edges = [[1,2],[5,1],[1,3],[1,4]]
Output: 1*/
        public int FindCenter(List<List<int>> edges)
        {
            Dictionary<int, int> nodeCount = new Dictionary<int, int>();

            foreach (var edge in edges)
            {
                int u = edge[0];
                int v = edge[1];

                if (!nodeCount.ContainsKey(u))
                    nodeCount[u] = 0;
                if (!nodeCount.ContainsKey(v))
                    nodeCount[v] = 0;

                nodeCount[u]++;
                nodeCount[v]++;
            }

            foreach (var node in nodeCount)
            {
                if (node.Value == edges.Count)
                    return node.Key;
            }

            return -1;
        }


































































    }
}
