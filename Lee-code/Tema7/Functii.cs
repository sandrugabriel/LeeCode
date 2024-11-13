using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema7
{
    public class Functii
    {

        /*You are given an integer n, the number of teams in a tournament that has strange rules:

If the current number of teams is even, each team gets paired with another team. A total of n / 2 matches are played, and n / 2 teams advance to the next round.
If the current number of teams is odd, one team randomly advances in the tournament, and the rest gets paired. A total of (n - 1) / 2 matches are played, and (n - 1) / 2 + 1 teams advance to the next round.
Return the number of matches played in the tournament until a winner is decided.

 

Example 1:

Input: n = 7
Output: 6
Explanation: Details of the tournament: 
- 1st Round: Teams = 7, Matches = 3, and 4 teams advance.
- 2nd Round: Teams = 4, Matches = 2, and 2 teams advance.
- 3rd Round: Teams = 2, Matches = 1, and 1 team is declared the winner.
Total number of matches = 3 + 2 + 1 = 6.
Example 2:

Input: n = 14
Output: 13
Explanation: Details of the tournament:
- 1st Round: Teams = 14, Matches = 7, and 7 teams advance.
- 2nd Round: Teams = 7, Matches = 3, and 4 teams advance.
- 3rd Round: Teams = 4, Matches = 2, and 2 teams advance.
- 4th Round: Teams = 2, Matches = 1, and 1 team is declared the winner.
Total number of matches = 7 + 3 + 2 + 1 = 13.*/
        public int NumberOfMatches(int n)
        {
            int totalMatches = 0;

            while (n > 1)
            {
                if (n % 2 == 0)
                {
                    totalMatches += n / 2;
                    n /= 2;
                }
                else
                {
                    totalMatches += (n - 1) / 2;
                    n = (n - 1) / 2 + 1;
                }
            }

            return totalMatches;
        }

        /*You are given a phone number as a string number. number consists of digits, spaces ' ', and/or dashes '-'.

You would like to reformat the phone number in a certain manner. Firstly, remove all spaces and dashes. Then, group the digits from left to right into blocks of length 3 until there are 4 or fewer digits. The final digits are then grouped as follows:

2 digits: A single block of length 2.
3 digits: A single block of length 3.
4 digits: Two blocks of length 2 each.
The blocks are then joined by dashes. Notice that the reformatting process should never produce any blocks of length 1 and produce at most two blocks of length 2.

Return the phone number after formatting.

 

Example 1:

Input: number = "1-23-45 6"
Output: "123-456"
Explanation: The digits are "123456".
Step 1: There are more than 4 digits, so group the next 3 digits. The 1st block is "123".
Step 2: There are 3 digits remaining, so put them in a single block of length 3. The 2nd block is "456".
Joining the blocks gives "123-456".
Example 2:

Input: number = "123 4-567"
Output: "123-45-67"
Explanation: The digits are "1234567".
Step 1: There are more than 4 digits, so group the next 3 digits. The 1st block is "123".
Step 2: There are 4 digits left, so split them into two blocks of length 2. The blocks are "45" and "67".
Joining the blocks gives "123-45-67".
Example 3:

Input: number = "123 4-5678"
Output: "123-456-78"
Explanation: The digits are "12345678".
Step 1: The 1st block is "123".
Step 2: The 2nd block is "456".
Step 3: There are 2 digits left, so put them in a single block of length 2. The 3rd block is "78".
Joining the blocks gives "123-456-78".
 */
        public string ReformatNumber(string number)
        {
            string digits = "";
            foreach (char c in number)
            {
                if (char.IsDigit(c))
                    digits += c;
            }

            string result = "";
            int i = 0;

            while (digits.Length - i > 4)
            {
                result += digits.Substring(i, 3) + "-";
                i += 3;
            }

            int remaining = digits.Length - i;
            if (remaining == 4)
            {
                result += digits.Substring(i, 2) + "-" + digits.Substring(i + 2, 2);
            }
            else if (remaining == 3)
            {
                result += digits.Substring(i, 3);
            }
            else if (remaining == 2)
            {
                result += digits.Substring(i, 2);
            }

            return result;
        }

        /*Hercy wants to save money for his first car. He puts money in the Leetcode bank every day.

He starts by putting in $1 on Monday, the first day. Every day from Tuesday to Sunday, he will put in $1 more than the day before. On every subsequent Monday, he will put in $1 more than the previous Monday.

Given n, return the total amount of money he will have in the Leetcode bank at the end of the nth day.

 

Example 1:

Input: n = 4
Output: 10
Explanation: After the 4th day, the total is 1 + 2 + 3 + 4 = 10.
Example 2:

Input: n = 10
Output: 37
Explanation: After the 10th day, the total is (1 + 2 + 3 + 4 + 5 + 6 + 7) + (2 + 3 + 4) = 37. Notice that on the 2nd Monday, Hercy only puts in $2.
Example 3:

Input: n = 20
Output: 96
Explanation: After the 20th day, the total is (1 + 2 + 3 + 4 + 5 + 6 + 7) + (2 + 3 + 4 + 5 + 6 + 7 + 8) + (3 + 4 + 5 + 6 + 7 + 8) = 96.*/
        public int TotalMoney(int n)
        {
            int total = 0;
            int weekStart = 1;

            for (int i = 0; i < n; i++)
            {
                total += weekStart + (i % 7);

                if ((i + 1) % 7 == 0)
                {
                    weekStart++;
                }
            }

            return total;
        }

        /*You are given a string s of even length. Split this string into two halves of equal lengths, and let a be the first half and b be the second half.

Two strings are alike if they have the same number of vowels ('a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'). Notice that s contains uppercase and lowercase letters.

Return true if a and b are alike. Otherwise, return false.

 

Example 1:

Input: s = "book"
Output: true
Explanation: a = "bo" and b = "ok". a has 1 vowel and b has 1 vowel. Therefore, they are alike.
Example 2:

Input: s = "textbook"
Output: false
Explanation: a = "text" and b = "book". a has 1 vowel whereas b has 2. Therefore, they are not alike.
Notice that the vowel o is counted twice.*/
        public bool HalvesAreAlike(string s)
        {
            HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            int countA = 0, countB = 0;
            int n = s.Length;

            for (int i = 0; i < n / 2; i++)
            {
                if (vowels.Contains(s[i])) countA++;
                if (vowels.Contains(s[i + n / 2])) countB++;
            }

            return countA == countB;
        }

        /*You are assigned to put some amount of boxes onto one truck. You are given a 2D array boxTypes, where boxTypes[i] = [numberOfBoxesi, numberOfUnitsPerBoxi]:

numberOfBoxesi is the number of boxes of type i.
numberOfUnitsPerBoxi is the number of units in each box of the type i.
You are also given an integer truckSize, which is the maximum number of boxes that can be put on the truck. You can choose any boxes to put on the truck as long as the number of boxes does not exceed truckSize.

Return the maximum total number of units that can be put on the truck.

 

Example 1:

Input: boxTypes = [[1,3],[2,2],[3,1]], truckSize = 4
Output: 8
Explanation: There are:
- 1 box of the first type that contains 3 units.
- 2 boxes of the second type that contain 2 units each.
- 3 boxes of the third type that contain 1 unit each.
You can take all the boxes of the first and second types, and one box of the third type.
The total number of units will be = (1 * 3) + (2 * 2) + (1 * 1) = 8.
Example 2:

Input: boxTypes = [[5,10],[2,5],[4,7],[3,9]], truckSize = 10
Output: 91
 */
        public int MaximumUnits(int[][] boxTypes, int truckSize)
        {
            Array.Sort(boxTypes, (a, b) => b[1] - a[1]);

            int totalUnits = 0;
            foreach (var box in boxTypes)
            {
                int numOfBoxes = box[0];
                int unitsPerBox = box[1];

                int boxesToTake = Math.Min(truckSize, numOfBoxes);
                totalUnits += boxesToTake * unitsPerBox;

                truckSize -= boxesToTake;

                if (truckSize == 0)
                    break;
            }

            return totalUnits;
        }

        /*There is a biker going on a road trip. The road trip consists of n + 1 points at different altitudes. The biker starts his trip on point 0 with altitude equal 0.

You are given an integer array gain of length n where gain[i] is the net gain in altitude between points i​​​​​​ and i + 1 for all (0 <= i < n). Return the highest altitude of a point.

 

Example 1:

Input: gain = [-5,1,5,0,-7]
Output: 1
Explanation: The altitudes are [0,-5,-4,1,1,-6]. The highest is 1.
Example 2:

Input: gain = [-4,-3,-2,-1,4,3,2]
Output: 0
Explanation: The altitudes are [0,-4,-7,-9,-10,-6,-3,-1]. The highest is 0.
 */
        public int LargestAltitude(int[] gain)
        {
            int currentAltitude = 0;
            int maxAltitude = 0;

            foreach (int g in gain)
            {
                currentAltitude += g;
                if (currentAltitude > maxAltitude)
                {
                    maxAltitude = currentAltitude;
                }
            }

            return maxAltitude;
        }

        /*There is a hidden integer array arr that consists of n non-negative integers.

It was encoded into another integer array encoded of length n - 1, such that encoded[i] = arr[i] XOR arr[i + 1]. For example, if arr = [1,0,2,1], then encoded = [1,2,3].

You are given the encoded array. You are also given an integer first, that is the first element of arr, i.e. arr[0].

Return the original array arr. It can be proved that the answer exists and is unique.

 

Example 1:

Input: encoded = [1,2,3], first = 1
Output: [1,0,2,1]
Explanation: If arr = [1,0,2,1], then first = 1 and encoded = [1 XOR 0, 0 XOR 2, 2 XOR 1] = [1,2,3]
Example 2:

Input: encoded = [6,2,7,3], first = 4
Output: [4,2,0,7,4]*/
        public int[] Decode(int[] encoded, int first)
        {
            int n = encoded.Length;
            int[] arr = new int[n + 1];
            arr[0] = first;

            for (int i = 0; i < n; i++)
            {
                arr[i + 1] = encoded[i] ^ arr[i];
            }

            return arr;
        }

        /*You are given an array rectangles where rectangles[i] = [li, wi] represents the ith rectangle of length li and width wi.

You can cut the ith rectangle to form a square with a side length of k if both k <= li and k <= wi. For example, if you have a rectangle [4,6], you can cut it to get a square with a side length of at most 4.

Let maxLen be the side length of the largest square you can obtain from any of the given rectangles.

Return the number of rectangles that can make a square with a side length of maxLen.

 

Example 1:

Input: rectangles = [[5,8],[3,9],[5,12],[16,5]]
Output: 3
Explanation: The largest squares you can get from each rectangle are of lengths [5,3,5,5].
The largest possible square is of length 5, and you can get it out of 3 rectangles.
Example 2:

Input: rectangles = [[2,3],[3,7],[4,3],[3,7]]
Output: 3*/
        public int CountGoodRectangles(int[][] rectangles)
        {
            int maxLen = 0;
            int count = 0;

            foreach (var rect in rectangles)
            {
                int side = Math.Min(rect[0], rect[1]);
                if (side > maxLen)
                {
                    maxLen = side;
                    count = 1;
                }
                else if (side == maxLen)
                {
                    count++;
                }
            }

            return count;
        }

        /*You are working in a ball factory where you have n balls numbered from lowLimit up to highLimit inclusive (i.e., n == highLimit - lowLimit + 1), and an infinite number of boxes numbered from 1 to infinity.

Your job at this factory is to put each ball in the box with a number equal to the sum of digits of the ball's number. For example, the ball number 321 will be put in the box number 3 + 2 + 1 = 6 and the ball number 10 will be put in the box number 1 + 0 = 1.

Given two integers lowLimit and highLimit, return the number of balls in the box with the most balls.

 

Example 1:

Input: lowLimit = 1, highLimit = 10
Output: 2
Explanation:
Box Number:  1 2 3 4 5 6 7 8 9 10 11 ...
Ball Count:  2 1 1 1 1 1 1 1 1 0  0  ...
Box 1 has the most number of balls with 2 balls.
Example 2:

Input: lowLimit = 5, highLimit = 15
Output: 2
Explanation:
Box Number:  1 2 3 4 5 6 7 8 9 10 11 ...
Ball Count:  1 1 1 1 2 2 1 1 1 0  0  ...
Boxes 5 and 6 have the most number of balls with 2 balls in each.
Example 3:

Input: lowLimit = 19, highLimit = 28
Output: 2
Explanation:
Box Number:  1 2 3 4 5 6 7 8 9 10 11 12 ...
Ball Count:  0 1 1 1 1 1 1 1 1 2  0  0  ...
Box 10 has the most number of balls with 2 balls.
 */
        public int CountBalls(int lowLimit, int highLimit)
        {
            Dictionary<int, int> boxCount = new Dictionary<int, int>();
            int maxBalls = 0;

            for (int i = lowLimit; i <= highLimit; i++)
            {
                int boxNumber = SumOfDigits(i);

                if (boxCount.ContainsKey(boxNumber))
                {
                    boxCount[boxNumber]++;
                }
                else
                {
                    boxCount[boxNumber] = 1;
                }

                maxBalls = Math.Max(maxBalls, boxCount[boxNumber]);
            }

            return maxBalls;
        }
        private int SumOfDigits(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }

        /*You are given an integer array nums. The unique elements of an array are the elements that appear exactly once in the array.

Return the sum of all the unique elements of nums.

 

Example 1:

Input: nums = [1,2,3,2]
Output: 4
Explanation: The unique elements are [1,3], and the sum is 4.
Example 2:

Input: nums = [1,1,1,1,1]
Output: 0
Explanation: There are no unique elements, and the sum is 0.
Example 3:

Input: nums = [1,2,3,4,5]
Output: 15
Explanation: The unique elements are [1,2,3,4,5], and the sum is 15.*/
        public int SumOfUnique(int[] nums)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();

            foreach (int num in nums)
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

            int sum = 0;
            foreach (var kvp in freq)
            {
                if (kvp.Value == 1)
                {
                    sum += kvp.Key;
                }
            }

            return sum;
        }
































    }
}
