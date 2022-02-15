using System;
using System.Threading;
using System.Diagnostics;

namespace Mergesort_v2 {
    class Program {
        static void Main(string[] args) {
            int[] numberArray = new int[8000]; // Array with 1000 ints
            Random intRng = new Random(); // Random number generator
            int arrayLength = numberArray.Length; // The length of the array.

            Console.WriteLine("= = = = = = = = = = = = = = = = = = = =");
            Console.WriteLine("Before Merge Sort:");
            Console.WriteLine("= = = = = = = = = = = = = = = = = = = = \n");
            Console.ReadKey();

            for(int i = 0; i < 8000 ; i++) { // Assigns random values to the ints
                numberArray[i] = intRng.Next(1, 1001);
                Console.Write(numberArray[i] + " ");
            }

            Console.WriteLine("\n= = = = = = = = = = = = = = = = = = = =");
            Console.WriteLine("Begin Merge Sort");
            Console.WriteLine("= = = = = = = = = = = = = = = = = = = =");
            Console.ReadKey();
            var timer = Stopwatch.StartNew();

            SortMethod(numberArray, 0, arrayLength - 1);
            foreach (int item in numberArray) {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("= = = = = = = = = = = = = = = = = = = =");
            Console.WriteLine("Time to sort was: " + timer.ElapsedMilliseconds + "ms");
            Console.WriteLine("= = = = = = = = = = = = = = = = = = = =");
            Console.ReadKey();
        }

        // === === === === === == === === === \\
        // === === ==== Mergesort ==== === ===\\
        // === === === === === == === === === \\

        static public void MergeMethod(int[] numberArray, int left, int mid, int right) {
            int[] temp = new int[8000];
            int i, left_end, num_elements, tmp_pos;

            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right)) {
                if (numberArray[left] <= numberArray[mid]) {
                    temp[tmp_pos++] = numberArray[left++];
                } else {
                    temp[tmp_pos++] = numberArray[mid++];
                }
            }

            while (left <= left_end) {
                temp[tmp_pos++] = numberArray[left++];
            } while (mid <= right) {
                temp[tmp_pos++] = numberArray[mid++];
            }

            for (i = 0; i < num_elements; i++) {
                numberArray[right] = temp[right];
                right--;
            }
        }
        static public void SortMethod(int[] numberArray, int left, int right) {
            int middle;
            if (right > left) {
                middle = (right + left) / 2;
                SortMethod(numberArray, left, middle);
                SortMethod(numberArray, (middle + 1), right);
                MergeMethod(numberArray, left, (middle + 1), right);
            }
        }
    }
}