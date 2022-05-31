using System;

namespace HackingCoding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Rotate an Array by N Elements

            int[] array = new int[] { 1, 10, 20, 0, 59, 86, 32, 11, 9, 40 };

            // n > 0 causes right rotation
            // exe n = 2 
            // { 9, 40, ... , 32, 11}
            // exe n = -1
            // { 10, 1, ... }

            // normalize the rotations, so the do not exceed the length of the array. For exe, for an array of length 10,
            // rotating by 14 elements is the same as rotating by (14 % 10) 4 elements.

        }

        public static void rotateArray(int[] array, int n)
        {
            int len = array.Length;
            // normalize the 'n' rotations
            n = n % len;

            if (n < 0)
            {
                n = n + len;
            }

            int[] temp = new int[] { };

            for (int i = 0; i < n; i++)
                temp[i] = array[len - n + i];

            for (int i = len - 1; i >= n; i--)
                array[i] = array[i - n];

            for (int i = 0; i < n; i++)
                array[i] = temp[i];
        }
    }
}
