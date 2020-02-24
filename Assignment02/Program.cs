using System;
using System.Collections.Generic;

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

            /*Console.WriteLine("Question 2");
            string s = "University of South Florida";
            string rs = StringReverse(s);
            Console.WriteLine(rs);*/

            Console.WriteLine("\nQuestion 3");
            int[] l2 = new int[] { 2, 2, 3, 5, 6 };
            int sum = MinimumSum(l2);
            Console.WriteLine(sum);

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

            Console.WriteLine("Question 7");
            int rodLength = 10;
            int priceProduct = GoldRod(rodLength);
            Console.WriteLine(priceProduct);

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
    }
}
