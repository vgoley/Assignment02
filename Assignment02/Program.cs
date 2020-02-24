using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Assignment02
{
    static class Counter
    {
        public static int c;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Question 1");
            int[] l1 = new int[] { 5, 6, 6, 9, 9, 12 };
            int target = 9;
            int[] r = TargetRange(l1, target);
            Console.Write("[");
            for (int l = 0; l < Counter.c; l++)
            {
                if (l != Counter.c - 1)
                    Console.Write(r[l] + ",");
                else
                    Console.Write(r[l]);
            }
            Console.Write("]\n");

            Console.WriteLine("Question 2");
            string s = "University of South Florida";
            string rs = StringReverse(s);
            Console.WriteLine(rs);

            Console.WriteLine("\nQuestion 3");
            int[] l2 = new int[] { 2, 2, 3, 5, 6 };
            int sum = MinimumSum(l2);
            Console.WriteLine(sum);

            Console.WriteLine("Question 4");
            string s2 = "Dell";
            string sortedString = FreqSort(s2);
            Console.WriteLine(sortedString);

            Console.WriteLine("\nQuestion 5-Part 1");
            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            int[] intersect1 = Intersect1(nums1, nums2);
            Console.WriteLine("Part 1- Intersection of two arrays is: ");
            DisplayArray(intersect1);
            Console.WriteLine("\n");
            
            Console.WriteLine("Question 5-Part 2");
            int[] intersect2 = Intersect2(nums1, nums2);
            Console.WriteLine("Part 2- Intersection of two arrays is: ");
            DisplayArray(intersect2);
            Console.WriteLine("\n");

            Console.WriteLine("Question 6");
            char[] arr = new char[] { 'a', 'g', 'h', 'a' };
            int k = 3;
            Console.WriteLine(ContainsDuplicate(arr, k));

            Console.WriteLine("Question 7");
            int rodLength = 10;
            int priceProduct = GoldRod(rodLength);
            Console.WriteLine(priceProduct);

            Console.WriteLine("Question 8");
            string[] userDict = new string[] { "rocky", "usf", "hello", "apple" };
            string keyword = "hhllo";
            Console.WriteLine(DictSearch(userDict, keyword));

            FindNumbers();
            Console.Read();

        }

        //Question1
        public static int[] TargetRange(int[] l1, int t)
        {
            try
            {
                int[] res = new int[l1.Length];
                Counter.c = 0;
                for (int i = 0; i < l1.Length; i++)
                {
                    if (l1[i] == t)
                    {
                        res[Counter.c] = i;
                        Counter.c++;
                    }
                }
                    if (Counter.c == 0)
                    {
                        res[Counter.c++] = -1;
                        res[Counter.c++] = -1;
                    }
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question-2 reverse string of words
        public static string StringReverse(string s)
        {
            Stack<char> st = new Stack<char>();
            // Traverse given string and push 
            // all characters to stack until
            // we see a space. 
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] != ' ')
                {
                    st.Push(s[i]);
                }
                // When we see a space, we 
                // print contents of stack. 
                else
                {
                    while (st.Count > 0)
                    {
                        Console.Write(st.Pop());
                    }
                    Console.Write(" ");
                }
            }
            // Since there may not be 
            // space after last word. 
            while (st.Count > 0)
            {
                Console.Write(st.Pop());
            }
            return s;
        }

        //Question3
        public static int MinimumSum(int[] l2)
        {
            try
            {
                int sum = 0;
                for (int i = 0, j = 1; j < l2.Length; i++,j++)
                {
                    if(l2[i] >= l2[j])
                    {
                        l2[j] = l2[i] + 1;
                    }
                }
                for (int i = 0; i < l2.Length; i++)
                {
                    Console.Write(l2[i]);
                    sum += l2[i];
                }
                Console.Write('\n');
                return sum;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Question-4 freequency sort - decreasing order
        public static string FreqSort(string s)
        {
            StringBuilder res = new StringBuilder();
            if (s.Length == 0)
            {
                return res.ToString();
            }
            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (map.ContainsKey(c))
                {
                    map[c] = map[c] + 1;
                }
                else
                {
                    map[c] = 1;
                }
            }
            //sort the frequency of occurrences by value
            var sortedFrequencies = from keyValuePair in map
                                    orderby keyValuePair.Value descending
                                    select keyValuePair;

            foreach (KeyValuePair<char, int> c in sortedFrequencies)
            {
                for (int i = 0; i < c.Value; i++)
                {
                    res.Append(c.Key);
                }
            }
            Console.WriteLine(res.ToString());
            return res.ToString();
        }

        //Question5-Part1
        public static int[] Intersect1(int[] nums1, int[] nums2)
        {
            try
            {
                int i, j, len;
                //Sort both the arrays using merge sort so that the complexity is O(nlogn).
                int[] sortnums1 = MergeSort(nums1);
                int[] sortnums2 = MergeSort(nums2);

                //Find the Length to be declared of the final array.
                if (nums1.Length > nums2.Length)
                    len = nums1.Length;
                else
                    len = nums2.Length;

                int[] inter = new int[len];

                //Counter to find the elements in the final intersection array 
                Counter.c = 0;
                i = 0; j = 0;

                while (i < nums1.Length && j < nums2.Length)
                {
                    //If the items in both the array is equal, add it to the intersection array and increase the count of the array.
                    if (sortnums1[i] == sortnums2[j])
                    {
                        inter[Counter.c] = sortnums1[i];
                        Counter.c++; i++; j++;
                    }
                    else
                    //If the first array element is less than the second array element, increase the counter of first array. 
                    if (sortnums1[i] < sortnums2[j])
                        i++;
                    else
                    //Else increase the counter of the second array.
                    if (sortnums1[i] > sortnums2[j])
                        j++;
                }
                return inter;
            }
            catch
            {
                throw;
            }
        }
        public static int[] MergeSort(int[] array)
        {
            int[] left, right;
            int[] sorted = new int[array.Length];
            if (array.Length <= 1)
                return array;
            // Find midpoint of the array  
            int midPoint = array.Length / 2;
            left = new int[midPoint];

            //if array has an even number of elements, the left and right array will have the same number of 
            //elements
            if (array.Length % 2 == 0)
                right = new int[midPoint];
            //if array has an odd number of elements, the right array will have one more element than left
            else
                right = new int[midPoint + 1];

            //populate left array
            for (int i = 0; i < midPoint; i++)
                left[i] = array[i];

            //populate right array   
            int x = 0;
            //For right array, index will start from the midpoint, as the left array is populated from 0 to midpont.
            for (int i = midPoint; i < array.Length; i++)
            {
                right[x] = array[i];
                x++;
            }

            //Sort both arrays recursively.
            left = MergeSort(left);
            right = MergeSort(right);

            //Merge our two sorted arrays

            int finalLen = right.Length + left.Length;
            int L = 0, R = 0, Res = 0;

            //While any one of the array still has an element
            while (L < left.Length || R < right.Length)
            {
                //When both arrays have elements  
                if (L < left.Length && R < right.Length)
                {
                    //When item on left array is less than that on right array, add that item to the sorted array 
                    if (left[L] <= right[R])
                    {
                        sorted[Res] = left[L];
                        L++;
                        Res++;
                    }
                    // else add the item in the right array to the sorted array
                    else
                    {
                        sorted[Res] = right[R];
                        R++;
                        Res++;
                    }
                }
                //when only the left array has elements left, add all its items to the sorted array
                else if (L < left.Length)
                {
                    sorted[Res] = left[L];
                    L++;
                    Res++;
                }
                //when only the right array has elements left, add all its items to the sorted array
                else if (R < right.Length)
                {
                    sorted[Res] = right[R];
                    R++;
                    Res++;
                }
            }
            return sorted;
        }

        //Question5-Part2
        public static int[] Intersect2(int[] nums1, int[] nums2)
        {
            try
            {
                Dictionary<int, int> dict1 = new Dictionary<int, int>();
                Dictionary<int, int> dict2 = new Dictionary<int, int>();
                Dictionary<int, int> Finaldict = new Dictionary<int, int>();

                //Storing values in dictionary1
                for (int i = 0; i < nums1.Length; i++)
                {
                    if (!dict1.ContainsKey(nums1[i]))
                        dict1.Add(nums1[i], 1);
                    else
                        dict1[nums1[i]] = dict1[nums1[i]] + 1;
                }

                //storing values in dictionary2
                for (int j = 0; j < nums2.Length; j++)
                {
                    if (!dict2.ContainsKey(nums2[j]))
                        dict2.Add(nums2[j], 1);
                    else
                        dict2[nums2[j]] = dict2[nums2[j]] + 1;
                }

                foreach (var v1 in dict1)
                {
                    if (dict2.ContainsKey(v1.Key))
                    {
                        int val;
                        if (!Finaldict.ContainsKey(v1.Key))
                        {
                            if (v1.Value < dict2[v1.Key])
                                val = v1.Value;
                            else
                                val = dict2[v1.Key];

                            if (!Finaldict.ContainsKey(v1.Key))
                                Finaldict.Add(v1.Key, val);
                        }

                    }
                }
                //Storing elements for returning output.
                Counter.c = 0;
                List<int> inter = new List<int>();
                foreach (var fd in Finaldict)
                {
                    for (int i = 0; i < fd.Value; i++)
                    {
                        inter.Add(fd.Key);
                        Counter.c++;
                    }
                }
                return inter.ToArray();
            }
            catch
            {
                throw;
            }
        }

        //Code to display the array.
        public static void DisplayArray(int[] arr)
        {
            try
            {
                Console.Write("[");
                for (int l = 0; l < Counter.c; l++)
                {
                    if (l != Counter.c - 1)
                        Console.Write(arr[l] + ",");
                    else
                        Console.Write(arr[l]);
                }
                Console.Write("]");
            }
            catch
            {
                throw;
            }
        }

        //Question-6 solution
        public static bool ContainsDuplicate(char[] arr, int k)
        {
            Dictionary<int, char> dupDictionary = new Dictionary<int, char>();
            for (int i = 0; i < arr.Length; i++)
            {
                dupDictionary.Add(i, arr[i]);
            }
            //we do not have to use a dictionary in this case
            for (int i = 0; i < dupDictionary.Count; i++)
            {
                if (i + k >= dupDictionary.Count)
                {
                    i = dupDictionary.Count;
                    continue;
                }
                if (dupDictionary[i] == dupDictionary[i + k])
                {
                    return true;
                }
            }
            return false;
        }

        //Question7
        public static int GoldRod(int rodLength)
        {
            try
            {
                if ((rodLength == 2) || (rodLength == 1))
                    return 1; 
                else
                 if (rodLength == 3)
                    return 2;
                else
                if (rodLength == 4)
                    return 4;

                while (rodLength > 4)
                {
                    return (3 * GoldRod(rodLength - 3));
                }
                return rodLength;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Question -8 solution

        public static bool DictSearch(string[] userDict, string keyword)
        {
            try
            {

                int positionofWord = Array.IndexOf(userDict, keyword);

                if (positionofWord > -1)

                {

                    //return false

                    return false;

                }

                for (int i = 0; i < userDict.Length; i++)

                {

                    //we dont even have to worry about this and go to the next word

                    if (userDict[i].Length != keyword.Length)

                    {

                        continue;

                    }

                    int noOfMismatches = 0;

                    int misMatchedIndex = -1;

                    for (int j = 0; j < userDict[i].Length; j++)

                    {

                        if (keyword[j] == userDict[i][j])

                        {

                            continue;

                        }

                        misMatchedIndex = j;

                        noOfMismatches++;

                    }

                    //this is not the word we are looking for

                    //should be exactly one letter that mismatched

                    if (noOfMismatches > 1)

                    {

                        continue;

                    }

                    //try replacing mismatched indexes letter with letter from keyworkd

                    StringBuilder currentWordBeingCompared = new StringBuilder(userDict[i]);

                    currentWordBeingCompared[misMatchedIndex] = keyword[misMatchedIndex];

                    if (currentWordBeingCompared.ToString() == keyword)

                    {

                        return true;

                    }

                }

                return false;

            }

            catch (Exception ex)

            {
                throw;
            }
            return default(Boolean);
        }

        //Question-9 puzzle solving
        public static void FindNumbers()
        {
            //Dictionary<char, int> weightsOfAlphabets = new Dictionary<char, int>();

            ////01459

            //// "UBER"   1BER    1274

            //// "COOL"   9OOL    9663

            ////"UNCLE"  109LE   10937

            ////ASSUME A=1 THROUGH Z= 26 AND EACH WORD HAS A UNIQUE VALUE ASSIGNED TO IT

            ////Assume there cannot be any zeros and each number is unique

            ////we know that max(4 digit) = 9999 and adding it twice gives to 19998

            ////so the fifth letter has to be 1

            //if (lengthOfFirstWord ==4 && LengthOfsecondWord==4 && lengthOfResult == 5)

            //{

            //    //first word of result has been figured out

            //    weightsOfAlphabets.Add(thirdWord[lengthOfResult-1], 1);

            //    //apply the same logic for the 4th word

            //    //max sum of three digit integers = 999* 2 = 1998 so we either get a 0 or 1 carry over

            //    if(weightsOfAlphabets.Keys.Contains(firstWord[lengthOfFirstWord - 1])  || weightsOfAlphabets.Keys.Contains(secondWord[lengthOfFirstWord - 1]))

            //    {

            //     //implies 1 + somecharacter+ 1 = 1N  -- 1 on the lhs is a carry over

            //     //max possible value of c is 8 or 9 (8 with a cary over and 9 without a carry over)

            //     //n can be 1 or 0 (0+9+1 or 1+8+1) since 1 is lalredy found 4th character can obly be a 0)

            //     weightsOfAlphabets.Add(thirdWord[lengthOfResult-2],0);

            //    }

            //    //100th place...

            //    //max value of c =9 ( and as determined from previous step c can be 8 or 9)

            //    //c can only be 9 as seen in the previous step sa there is no carry over from the 100th to the 1000th.

            //    //1 can be a carry over (99*2 = 198)

            //    //1+B+O= 9 OR B+O= 9 => B AND O are less than 8 or 9 in case of no carry over

            //    //1,6,2

            //    //1,3,5

            //    //0,2,7 ignore this as there has to be a carry over

            //    //0,3,6 ignore this as there has to be a carry over

            //    //0,4,5 ignore this as there has to be a carry over
            //    weightsOfAlphabets.Add(thirdWord[lengthOfResult - 3], 9);
            //    //L shoudl be less than E and the max. possible value of l is 6 and the second place will not have a carry over
            //    //for any other case other than L = 3
            //    weightsOfAlphabets.Add(thirdWord[lengthOfResult - 3], 3);
            //}
            try

            {

                // Write your code here

                //get user input of uber , cool and uncle



                string[] words = GetInput();

                string firstWord = words[0];

                int lengthOfFirstWord = firstWord.Length;



                string secondWord = words[1];

                int LengthOfsecondWord = secondWord.Length;



                string thirdWord = words[2];

                int lengthOfResult = thirdWord.Length;

                // get the distinct characters

                string vWord = string.Join("", words);

                string distinctChars = new String(vWord.Distinct().ToArray());

                //set range for distinct numerical values used 8 since there are 8 distinct characters

                int l = 10000000, r = 999999999;



                //Letting user know code engine is currently processing

                Console.WriteLine("Processing...");



                //Get all the unique values between 10000000 and 999999999

                int[] uniqueNumbers = GenerateUniqueNumbers(l, r);



                foreach (int element in uniqueNumbers)

                {

                    //get the individual digits of each unique number

                    int[] digitsInNumber = ConvertNumberToIntArray(element);

                    Dictionary<char, int> weightOfEachDigit = new Dictionary<char, int>();

                    //Assign a value to the unique letters of Uber, Cool, Uncle

                    weightOfEachDigit.Add(distinctChars[0], digitsInNumber[1]);

                    weightOfEachDigit.Add(distinctChars[1], digitsInNumber[0]);

                    weightOfEachDigit.Add(distinctChars[2], digitsInNumber[2]);

                    weightOfEachDigit.Add(distinctChars[3], digitsInNumber[3]);

                    weightOfEachDigit.Add(distinctChars[4], digitsInNumber[4]);

                    weightOfEachDigit.Add(distinctChars[5], digitsInNumber[5]);

                    weightOfEachDigit.Add(distinctChars[6], digitsInNumber[6]);

                    weightOfEachDigit.Add(distinctChars[7], digitsInNumber[7]);



                    int firstNumber = int.Parse(weightOfEachDigit[firstWord[3]].ToString() + weightOfEachDigit[firstWord[2]].ToString() + weightOfEachDigit[firstWord[1]].ToString() + weightOfEachDigit[firstWord[0]].ToString());

                    int secondNumber = int.Parse(weightOfEachDigit[secondWord[3]].ToString() + weightOfEachDigit[secondWord[2]].ToString() + weightOfEachDigit[secondWord[1]].ToString() + weightOfEachDigit[secondWord[0]].ToString());

                    int finalResult = int.Parse(weightOfEachDigit[thirdWord[4]].ToString() + weightOfEachDigit[thirdWord[3]].ToString() + weightOfEachDigit[thirdWord[2]].ToString() + weightOfEachDigit[thirdWord[1]].ToString() + weightOfEachDigit[thirdWord[0]].ToString());



                    //Check if the combination for Uber+Cool=UNCLE exists

                    if ((firstNumber + secondNumber) == finalResult)
                    {
                        Console.WriteLine("\tThe numbers that make up the given puzzle are: \n\t" + firstNumber.ToString() + " + " + secondNumber.ToString() + "= " + finalResult.ToString());
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        private static string[] GetInput()
        {
            Console.WriteLine("Enter space separated input words with the first two words representing the input and the third representing the output:");
            string[] input = Console.ReadLine().Split();
            return input;
        }

        public static int[] GenerateUniqueNumbers(int l, int r)
        {
            List<int> NumList = new List<int>();
            // Start traversing the numbers
            for (int i = l; i <= r; i++)
            {
                Int64 num = i;
                bool[] visited = new bool[10];
                // Find digits and maintain
                // its hash
                while (num != 0)
                {   // if a digit occcurs more
                    // than 1 time then break
                    if (visited[num % 10])
                        break;
                    visited[num % 10] = true;
                    num = num / 10;
                }
                // num will be 0 only when
                // above loop doesn't get
                // break that means the number
                // is unique so print it.
                if (num == 0)
                {
                    NumList.Add(i);
                }
            }
            return NumList.ToArray();
        }
        public static int[] ConvertNumberToIntArray(int value)
        {
            //initialized a blank collection
            var numbers = new Stack<int>();
            //enumerating through value and adding each digit to the collection
            for (; value > 0; value /= 10)
                numbers.Push(value % 10);
            //return number to be used to solution
            return numbers.ToArray();
        }
    }
}
