using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema5
{


    /*Design a parking system for a parking lot. The parking lot has three kinds of parking spaces: big, medium, and small, with a fixed number of slots for each size.

Implement the ParkingSystem class:

ParkingSystem(int big, int medium, int small) Initializes object of the ParkingSystem class. The number of slots for each parking space are given as part of the constructor.
bool addCar(int carType) Checks whether there is a parking space of carType for the car that wants to get into the parking lot. carType can be of three kinds: big, medium, or small, which are represented by 1, 2, and 3 respectively. A car can only park in a parking space of its carType. If there is no space available, return false, else park the car in that size space and return true.


Example 1:

Input
["ParkingSystem", "addCar", "addCar", "addCar", "addCar"]
[[1, 1, 0], [1], [2], [3], [1]]
Output
[null, true, true, false, false]

Explanation
ParkingSystem parkingSystem = new ParkingSystem(1, 1, 0);
parkingSystem.addCar(1); // return true because there is 1 available slot for a big car
parkingSystem.addCar(2); // return true because there is 1 available slot for a medium car
parkingSystem.addCar(3); // return false because there is no available slot for a small car
parkingSystem.addCar(1); // return false because there is no available slot for a big car. It is already occupied.*/
    public class ParkingSystem
    {
        private int bigSlots;
        private int mediumSlots;
        private int smallSlots; 

        public ParkingSystem(int big, int medium, int small)
        {
            bigSlots = big;
            mediumSlots = medium;
            smallSlots = small;
        }

        public bool AddCar(int carType)
        {
            switch (carType)
            {
                case 1: 
                    if (bigSlots > 0)
                    {
                        bigSlots--;
                        return true;
                    }
                    break;
                case 2: 
                    if (mediumSlots > 0)
                    {
                        mediumSlots--;
                        return true;
                    }
                    break;
                case 3:
                    if (smallSlots > 0)
                    {
                        smallSlots--;
                        return true;
                    }
                    break;
            }
            return false;
        }
    }

    public class Functii
    {

        /*Given an m x n binary matrix mat, return the number of special positions in mat.

A position (i, j) is called special if mat[i][j] == 1 and all other elements in row i and column j are 0 (rows and columns are 0-indexed).

 

Example 1:


Input: mat = [[1,0,0],[0,0,1],[1,0,0]]
Output: 1
Explanation: (1, 2) is a special position because mat[1][2] == 1 and all other elements in row 1 and column 2 are 0.
Example 2:


Input: mat = [[1,0,0],[0,1,0],[0,0,1]]
Output: 3
Explanation: (0, 0), (1, 1) and (2, 2) are special positions.*/
        public int NumSpecial(int[][] mat)
        {
            int m = mat.Length;
            int n = mat[0].Length;
            int specialCount = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (mat[i][j] == 1 && IsSpecial(mat, i, j, m, n))
                    {
                        specialCount++;
                    }
                }
            }

            return specialCount;
        }
        private bool IsSpecial(int[][] mat, int r, int c, int m, int n)
        {
            for (int j = 0; j < n; j++)
            {
                if (j != c && mat[r][j] == 1)
                {
                    return false;
                }
            }
            for (int i = 0; i < m; i++)
            {
                if (i != r && mat[i][c] == 1)
                {
                    return false;
                }
            }
            return true;
        }

        /*You are given a string text of words that are placed among some number of spaces. Each word consists of one or more lowercase English letters and are separated by at least one space. It's guaranteed that text contains at least one word.

Rearrange the spaces so that there is an equal number of spaces between every pair of adjacent words and that number is maximized. If you cannot redistribute all the spaces equally, place the extra spaces at the end, meaning the returned string should be the same length as text.

Return the string after rearranging the spaces.

 

Example 1:

Input: text = "  this   is  a sentence "
Output: "this   is   a   sentence"
Explanation: There are a total of 9 spaces and 4 words. We can evenly divide the 9 spaces between the words: 9 / (4-1) = 3 spaces.
Example 2:

Input: text = " practice   makes   perfect"
Output: "practice   makes   perfect "
Explanation: There are a total of 7 spaces and 3 words. 7 / (3-1) = 3 spaces plus 1 extra space. We place this extra space at the end of the string.*/
        public string RearrangeSpaces(string text)
        {
            string[] words = text.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int totalSpaces = text.Count(c => c == ' ');
            int wordCount = words.Length;

            if (wordCount == 1)
            {
                return words[0] + new string(' ', totalSpaces);
            }

            int spacesBetweenWords = totalSpaces / (wordCount - 1);
            int extraSpaces = totalSpaces % (wordCount - 1);

            string space = new string(' ', spacesBetweenWords);
            string result = string.Join(space, words) + new string(' ', extraSpaces);

            return result;
        }

        /*The Leetcode file system keeps a log each time some user performs a change folder operation.

The operations are described below:

"../" : Move to the parent folder of the current folder. (If you are already in the main folder, remain in the same folder).
"./" : Remain in the same folder.
"x/" : Move to the child folder named x (This folder is guaranteed to always exist).
You are given a list of strings logs where logs[i] is the operation performed by the user at the ith step.

The file system starts in the main folder, then the operations in logs are performed.

Return the minimum number of operations needed to go back to the main folder after the change folder operations.

 

Example 1:



Input: logs = ["d1/","d2/","../","d21/","./"]
Output: 2
Explanation: Use this change folder operation "../" 2 times and go back to the main folder.
Example 2:



Input: logs = ["d1/","d2/","./","d3/","../","d31/"]
Output: 3
Example 3:

Input: logs = ["d1/","../","../","../"]
Output: 0*/
        public int MinOperations(string[] logs)
        {
            int depth = 0;

            foreach (string log in logs)
            {
                if (log == "../")
                {
                    if (depth > 0)
                    {
                        depth--;
                    }
                }
                else if (log != "./")
                {
                    depth++;
                }
            }

            return depth;
        }

        /*You are given an array nums of non-negative integers. nums is considered special if there exists a number x such that there are exactly x numbers in nums that are greater than or equal to x.

Notice that x does not have to be an element in nums.

Return x if the array is special, otherwise, return -1. It can be proven that if nums is special, the value for x is unique.

 

Example 1:

Input: nums = [3,5]
Output: 2
Explanation: There are 2 values (3 and 5) that are greater than or equal to 2.
Example 2:

Input: nums = [0,0]
Output: -1
Explanation: No numbers fit the criteria for x.
If x = 0, there should be 0 numbers >= x, but there are 2.
If x = 1, there should be 1 number >= x, but there are 0.
If x = 2, there should be 2 numbers >= x, but there are 0.
x cannot be greater since there are only 2 numbers in nums.
Example 3:

Input: nums = [0,4,3,0,4]
Output: 3
Explanation: There are 3 values that are greater than or equal to 3.*/
        public int SpecialArray(int[] nums)
        {
            Array.Sort(nums);

            int n = nums.Length;

            for (int x = 0; x <= n; x++)
            {
                int count = CountGreaterEqual(nums, x);
                if (count == x)
                {
                    return x;
                }
            }

            return -1;
        }
        private int CountGreaterEqual(int[] nums, int x)
        {
            int left = 0, right = nums.Length;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] >= x)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return nums.Length - left;
        }

        /*Given a valid parentheses string s, return the nesting depth of s. The nesting depth is the maximum number of nested parentheses.

 

Example 1:

Input: s = "(1+(2*3)+((8)/4))+1"

Output: 3

Explanation:

Digit 8 is inside of 3 nested parentheses in the string.

Example 2:

Input: s = "(1)+((2))+(((3)))"

Output: 3

Explanation:

Digit 3 is inside of 3 nested parentheses in the string.

Example 3:

Input: s = "()(())((()()))"

Output: 3*/
        public int MaxDepth(string s)
        {
            int maxDepth = 0;
            int currentDepth = 0;

            foreach (char c in s)
            {
                if (c == '(')
                {
                    currentDepth++;
                    if (currentDepth > maxDepth)
                    {
                        maxDepth = currentDepth;
                    }
                }
                else if (c == ')')
                {
                    currentDepth--;
                }
            }

            return maxDepth;
        }

        /*Given an array of integers nums, sort the array in increasing order based on the frequency of the values. If multiple values have the same frequency, sort them in decreasing order.

Return the sorted array.

 

Example 1:

Input: nums = [1,1,2,2,2,3]
Output: [3,1,1,2,2,2]
Explanation: '3' has a frequency of 1, '1' has a frequency of 2, and '2' has a frequency of 3.
Example 2:

Input: nums = [2,3,1,3,2]
Output: [1,3,3,2,2]
Explanation: '2' and '3' both have a frequency of 2, so they are sorted in decreasing order.
Example 3:

Input: nums = [-1,1,-6,4,5,-6,1,4,1]
Output: [5,-1,4,4,-6,-6,1,1,1]*/
        public int[] FrequencySort(int[] nums)
        {

            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

            foreach (int num in nums)
            {
                if (frequencyMap.ContainsKey(num))
                {
                    frequencyMap[num]++;
                }
                else
                {
                    frequencyMap[num] = 1;
                }
            }
            return nums.OrderBy(num => frequencyMap[num])
                       .ThenByDescending(num => num)
                       .ToArray();
        }

        /*Given n points on a 2D plane where points[i] = [xi, yi], Return the widest vertical area between two points such that no points are inside the area.

A vertical area is an area of fixed-width extending infinitely along the y-axis (i.e., infinite height). The widest vertical area is the one with the maximum width.

Note that points on the edge of a vertical area are not considered included in the area.

 

Example 1:

​
Input: points = [[8,7],[9,9],[7,4],[9,7]]
Output: 1
Explanation: Both the red and the blue area are optimal.
Example 2:

Input: points = [[3,1],[9,0],[1,0],[1,4],[5,3],[8,8]]
Output: 3*/
        public int WidestVerticalArea(int[][] points)
        {
            HashSet<int> xCoordinates = new HashSet<int>();

            foreach (var point in points)
            {
                xCoordinates.Add(point[0]);
            }

            int[] sortedX = xCoordinates.OrderBy(x => x).ToArray();

            int maxWidth = 0;

            for (int i = 1; i < sortedX.Length; i++)
            {
                maxWidth = Math.Max(maxWidth, sortedX[i] - sortedX[i - 1]);
            }

            return maxWidth;
        }

        /*Given a string s, return the length of the longest substring between two equal characters, excluding the two characters. If there is no such substring return -1.

A substring is a contiguous sequence of characters within a string.

 

Example 1:

Input: s = "aa"
Output: 0
Explanation: The optimal substring here is an empty substring between the two 'a's.
Example 2:

Input: s = "abca"
Output: 2
Explanation: The optimal substring here is "bc".
Example 3:

Input: s = "cbzxy"
Output: -1
Explanation: There are no characters that appear twice in s.*/
        public int LongestSubstringBetweenEqualCharacters(string s)
        {
           
            Dictionary<char, int> lastIndexMap = new Dictionary<char, int>();
            int maxLength = -1; 

            for (int i = 0; i < s.Length; i++)
            {
                char currentChar = s[i];

                if (lastIndexMap.ContainsKey(currentChar))
                {
                    int length = i - lastIndexMap[currentChar] - 1;
                    maxLength = Math.Max(maxLength, length);
                }

                lastIndexMap[currentChar] = i;
            }

            return maxLength;
        }

        /*A newly designed keypad was tested, where a tester pressed a sequence of n keys, one at a time.

You are given a string keysPressed of length n, where keysPressed[i] was the ith key pressed in the testing sequence, and a sorted list releaseTimes, where releaseTimes[i] was the time the ith key was released. Both arrays are 0-indexed. The 0th key was pressed at the time 0, and every subsequent key was pressed at the exact time the previous key was released.

The tester wants to know the key of the keypress that had the longest duration. The ith keypress had a duration of releaseTimes[i] - releaseTimes[i - 1], and the 0th keypress had a duration of releaseTimes[0].

Note that the same key could have been pressed multiple times during the test, and these multiple presses of the same key may not have had the same duration.

Return the key of the keypress that had the longest duration. If there are multiple such keypresses, return the lexicographically largest key of the keypresses.

 

Example 1:

Input: releaseTimes = [9,29,49,50], keysPressed = "cbcd"
Output: "c"
Explanation: The keypresses were as follows:
Keypress for 'c' had a duration of 9 (pressed at time 0 and released at time 9).
Keypress for 'b' had a duration of 29 - 9 = 20 (pressed at time 9 right after the release of the previous character and released at time 29).
Keypress for 'c' had a duration of 49 - 29 = 20 (pressed at time 29 right after the release of the previous character and released at time 49).
Keypress for 'd' had a duration of 50 - 49 = 1 (pressed at time 49 right after the release of the previous character and released at time 50).
The longest of these was the keypress for 'b' and the second keypress for 'c', both with duration 20.
'c' is lexicographically larger than 'b', so the answer is 'c'.
Example 2:

Input: releaseTimes = [12,23,36,46,62], keysPressed = "spuda"
Output: "a"
Explanation: The keypresses were as follows:
Keypress for 's' had a duration of 12.
Keypress for 'p' had a duration of 23 - 12 = 11.
Keypress for 'u' had a duration of 36 - 23 = 13.
Keypress for 'd' had a duration of 46 - 36 = 10.
Keypress for 'a' had a duration of 62 - 46 = 16.
The longest of these was the keypress for 'a' with duration 16.*/
        public char SlowestKey(int[] releaseTimes, string keysPressed)
        {
            int maxDuration = releaseTimes[0];
            char longestKey = keysPressed[0];

            for (int i = 1; i < releaseTimes.Length; i++)
            {
                int duration = releaseTimes[i] - releaseTimes[i - 1];

                if (duration > maxDuration)
                {
                    maxDuration = duration;
                    longestKey = keysPressed[i];
                }
                else if (duration == maxDuration)
                {
                    longestKey = (longestKey > keysPressed[i]) ? longestKey : keysPressed[i];
                }
            }

            return longestKey;
        }









































    }
}
