using System;
using System.Collections.Generic;

namespace RepoPattern
{
    public class Customer
    {
        public int Id { get; set; }
    }

    public class Node
    {
        public Node(int value)
        {
            this.value = value;
        }
        public int value;
        public Node next;
    }

    

    class Program
    {
        static bool search(Node head, int value)
        {
            if (head == null)
                return false;
            if (head.value == value)
                return true;

            else return search(head.next, value);
        }
        static void reverse(Node head)
        {
            if (head == null)
                return;
            reverse(head.next);

            Console.WriteLine(head.value + " ");
        }

        static void Main(string[] args)
        {

            // repositories are classes or components that encapsulate the logic required to acces data sources
            // encapsulate business logic and avoid duplicate queries

            Console.WriteLine("Hello World!");

            Console.WriteLine("----------");



            // x fuqi e y
            int product = xPowerY(10, 5);
            long productIterative = xPowerYIterative(10, 5);
            Console.WriteLine("product " + product);
            Console.WriteLine("product Iterative " + productIterative);
            Console.WriteLine(Math.Pow(10, 5));
            Console.WriteLine(Math.Pow(-1, 4));

            Console.WriteLine("----------");

            Console.WriteLine("squared -> " + square(12));
            Console.WriteLine("Should be -> " + Math.Pow(-1, 5));

            Console.WriteLine("----------");

            Console.WriteLine(fakultat(6));
            Console.WriteLine("-----#-----");
            Console.WriteLine(fibonacci(6));
            Console.WriteLine("----------");
            Console.WriteLine(fibonacciRecursive(6));
            Console.WriteLine("-----#-----");
            //Console.WriteLine(getRemainder(12316767678678, 10));
            //Console.WriteLine(getRemainder(6, 4));
            Console.WriteLine("-----#-----");
            Console.WriteLine(findSinWithTaylerFormula(5, 5));


            DateTime today = DateTime.Today;

            // Ester Tag des Monats
            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);

            // Memory allocation to methods
            // method is called -> state of method on the call stack with where it is called from
            // tells run-time where it should return to when the current method finishes executing
            // each recursive call pushes a new stack frame.
            // with datas -> address, argument vars and local variables related to that method call.

            // method calls itself -> new method call gets added to the top of the call stack and exe of the current method pauses
            // while recursive call is being processed
            // base cased is reached the stack frames start poping from the stack until the stack is empty


            // length of a linked list
            // 
            Console.WriteLine("###########");
            Console.WriteLine(reverseStringR("Hello World"));
            // Console.WriteLine(remDuplicatesR("Hello World"));

            char[] input = { 'a', 'b', 'b', 'a' };
            permutations(input, input.Length);


            // taylor series to calculate sinus



            // dezimal modulo
            // a mod b = a - (int [a / b] x b)

            Console.WriteLine("modul me, {0}", findDecimalModul(125, 26));
            Console.WriteLine("modul me mod(), {0}", mod("27", 6));
            Console.WriteLine("modul me clock(), {0}", findModDividentNegativeOrPositive(-5, 3));
            Console.WriteLine("modul me clock(), {0}", findModDividentNegativeOrPositive(-5, 2));
            Console.WriteLine("modul me clock(), {0}", findModDividentNegativeOrPositive(-17, 3));

            Console.WriteLine(isPalindrome("madam"));
            Console.WriteLine(isPalidromeIterative("takovavokat"));

            // Knapsack problem

            /*
            Items: { Apple, Orange, Banana, Melon }
            Weights: { 2, 3, 1, 4 }
            Profits: { 4, 5, 3, 7 }
            */

            // put these items in a knapsack that has a capacity
            // Knapsack capacity: 5

            // put different items in knapsack, such that total weight is not more than N(capacity)

            // Top-down Dynamic Programming with Memoization

            int[] profits = { 1, 6, 10, 16 };
            int[] weights = { 1, 2, 3, 5 };
            int maxProfit = solveKnapsack(profits, weights, 7);
            Console.WriteLine("Total knapsack profit ---> " + maxProfit);
            maxProfit = solveKnapsack(profits, weights, 6);
            Console.WriteLine("Total knapsack profit ---> " + maxProfit);
            int[] prices = new int[] { 7, 1, 5, 3, 6, 4 };
            Console.WriteLine("max stock profit: ");

            Console.WriteLine(maxStockProfit(prices));

            // stock prices where i is the number of the day
            // [7, 1, 1, 5, 7] -> 5 days with corresponding price
            // max profit -> which day should I buy and sell it on the one of following up day

            // first find minimum price 
            // calculate difference of of each following day
            // keep trakc of minimum prices

            // keep record of max_profits for each following days

            // Maximum Contiguous SubArray Sum

            // [-2, 1, -3, 4, -1, 2, 1, -5, 4]

            // output: 6

            // find the contiguous subarray (at least one number) which has the largest sum and returns its sum.
            int[] num_array = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            
            maxSumOfSubArr(num_array);
        }

        // sinus berechnung



        // radian * (180 / pi) = degree
        // radian = degree * (Math.PI / 180);
        // degree = radian / (Math.PI / 180);
        public static double convertToRad(int degree)
        {

            return degree * (Math.PI / 180);
        }

        public static double convertToDegree(int radian)
        {

            return radian / (Math.PI / 180);
        }

        public static void maxSumOfSubArr(int[] num_array)
        {
            int max_sum = int.MinValue;
            int start = 0;
            int end = 1;

            for (int i = 0; i < num_array.Length; i++)
            {
                int sum = 0;
                for (int j = 1; j < num_array.Length; j++)
                {
                    sum += num_array[j];
                    if(sum > max_sum)
                    {
                        max_sum = sum;
                        start = i;
                        end = j + 1;
                    }
                }
            }

            Console.WriteLine("The array {0} has the largest sum of {1}", string.Join(", ", num_array.ToString()), max_sum);
        }

        public static int fakultat1(int number)
        {
            // !5 = 5 * 4 * ... * 1;
            //int product = 1;

            //for(int i = 0; i < number; i++)
            //{
            //    product *= i;
            //}

            //return product;

            if (number == 0)
                return 1;
            if (number == 1)
                return 1;

            return number * fakultat1(number - 1);
        }

        // maximize stock profits
        // element is price of a given stock of day i
        // buy one sell one
        // 2 days to make a profit
        public static int maxStockProfit(int[] prices)
        {
            int[] max_profit = new int[prices.Length];
            int min_price = prices[0];
            for (int i = 0; i < prices.Length; i++)
            {
                max_profit[i] = 0;
            }

            if (prices.Length == 1)
                return max_profit[0];

            // calculate max_profit[i] using previously computed
            // solution of max_profit[i - 1]
            for(int i = 1; i < prices.Length; i++)
            {
                if (prices[i] < min_price)
                    min_price = prices[i];

                max_profit[i] = Math.Max(prices[i] - min_price, max_profit[i - 1]);
            }

            return max_profit[prices.Length - 1];
        }

        public static int solveKnapsack(int[] profits, int[] weights, int capacity)
        {
            // best combination of items that has best value of profit where weights does not exceed the capacity
            // base checks
            if (capacity <= 0 || profits.Length == 0 || weights.Length != profits.Length)
                return 0;

            int n = profits.Length;
            int[,] dp = new int[n, capacity + 1];

            for (int i = 0; i < n; i++)
                dp[i, 0] = 0;

            // if we have only one weight, we will take it if it is not more than the capacity
            for (int c = 0; c <= capacity; c++)
            {
                if(weights[0] <= c)
                {
                    dp[0, c] = profits[0];
                }
            }

            // process all sub-arrays for all the capacities
            for (int i = 1; i < n; i++)
            {
                for (int c = 1; c <= capacity; c++)
                {
                    int profit1 = 0, profit2;

                    // include the item, if it is not more than the capacoty

                    if (weights[i] <= c)
                        profit1 = profits[i] + dp[i - 1, c - weights[i]];

                    profit2 = dp[i - 1, c];

                    dp[i, c] = Math.Max(profit1, profit2);
                }
            }

            printSelectedElements(dp, weights, profits, capacity);

            return dp[n - 1, capacity];
        }

        private static void printSelectedElements(int[,] dp, int[] weights, int[] profits, int capacity)
        {
            Console.WriteLine("Selected weights:");
            int totalProfit = dp[weights.Length - 1, capacity];
            for (int i = weights.Length - 1; i > 0; i--)
            {
                if (totalProfit != dp[i - 1, capacity])
                {
                    Console.WriteLine(" " + weights[i]);
                    capacity -= weights[i];
                    totalProfit -= profits[i];
                }
            }

            if (totalProfit != 0)
                Console.WriteLine(" " + weights[0]);
            Console.WriteLine("");
        }

        static void sortArrayRecursivly(int[] arr, int n)
        {
          
        }

        static bool isPalindrome(String text)
        {
            // first cahracter is equall to last character

            if (text.Length == 0)
                return false;
            if (text.Length == 1)
                return true;

            if (text.Substring(0, 1).Equals(text.Substring(text.Length - 1, 1)))
            {
                return isPalindrome(text.Substring(1, text.Length - 2));
            }

            return false;
        }

        static bool isPalidromeIterative(String text)
        {
            var middle = text.Length / 2;
            var left = "";
            var right = "";

            for(int i = 0; i < middle; i++)
            {
                left += text[i];
            }

            for (int i = text.Length - 1; i > middle; i--)
            {
                right += text[i];
            }

            return left.Equals(right);
        }

        // Function to compute num (mod a)
        static int mod(String num, int a)
        {

            // Initialize result
            int res = 0;

            // One by one process all
            // digits of 'num'
            for (int i = 0; i < num.Length; i++)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("iteration {0}", i);
                Console.WriteLine("num[{1}]: {0}", num[i], i);
                Console.WriteLine("a value: {0}", a);
               
                var b = (int)num[i] - '0';
                Console.WriteLine("(int)num[i] - '0': {0}", b);
                var c = (res * 10 + (int)num[i] - '0');
                Console.WriteLine("(res * 10 + (int)num[i] - '0'): {0}", c);
                
                res = (res * 10 + (int)num[i] - '0') % a;
                Console.WriteLine("res value: {0}", res);


                Console.WriteLine("\n");
            }
            

            return res;
        }

        static int findModDividentNegativeOrPositive(int divident, int divisor)
        {
            // 27 mod 6 = 3
            // 7 mod 2 = 1

            // [0, ... , 5] 
            // 7 x [0, 1]
            // [0,1]
            // [0 1 2 3]

            int mod = 0;
            int[] clockArray = new int[divisor];
            for (int i = 0; i < divisor; i++)
            {
                clockArray[i] = i;
            }

            int iteratorToDivident = 0;

            List<int> clockwiseAllNumbers = new List<int>();

            if(divident < 0)
            {
                for (int i = divisor; i > 0;)
                {
                    iteratorToDivident++;
                    clockwiseAllNumbers.Add(i);

                    if (iteratorToDivident == Math.Abs(divident) + 1)
                    {
                        mod = i;
                        break;
                    }

                    i--;

                    if (i == 0)
                    {
                        i = divisor;
                    }
                }
            }
            else
            {
                for (int i = 0; i < clockArray.Length;)
                {
                    iteratorToDivident++;
                    clockwiseAllNumbers.Add(i);

                    if (iteratorToDivident == divident + 1)
                    {
                        mod = i;
                        break;
                    }

                    i++;

                    if (i == clockArray.Length)
                    {
                        i = 0;
                    }
                }
            }

            //int iterate = 0;
            //while(iterate < clockArray.Length)
            //{
            //    for (int i = 0; i < clockArray.Length; i++)
            //    {
            //        clockArray[i] = i;
            //    }

            //    iterate += clockArray.Length;
            //}
            foreach (var el in clockwiseAllNumbers)
            {
                Console.WriteLine(el);
            }

            return mod;
        }
        
        
        static int findDecimalModul(int divident, int divisor)
        {
            var modul = (divident - ((divident / divisor) * divisor));

            Console.WriteLine("modul {0}", modul);
            return modul;
        }

        public static int findSinWithTaylerFormula(int x, int number)
        {
            // (-1) power n -> 
            // (-1)pn * (x power (2n + 1) / (2n + 1)!)

            int sumOfSerie = 0;

            for(int i = 0; i < number; i++)
            {
                int signOfTerm = xPowerY(-1, number);
                int termX = xPowerY(x, 2 * number + 1);
                int facultat = fakultat1(2 * number + 1);

                sumOfSerie = signOfTerm * (termX / facultat);
            }

            return sumOfSerie;
        }

        static double sinus(int x)
        {
       
            double val = 0;

            for(int n = 0; n < 8; n++)
            {
                double p = xPowerY(-1, n);
                double px = xPowerY(x, 2 * n + 1);
                long fac = fakultat(2 * n + 1);
                val += p * px / fac;
            }

            return val;
        }

        static void make_zeroes(int[][] matrix)
        {
            if (matrix.Length == 0)
                return;

            HashSet<int> zero_rows = new HashSet<int>();
            HashSet<int> zero_cols = new HashSet<int>();

            int rows = matrix.Length;
            int cols = matrix[0].Length;

            for(int i = 0; i < rows; ++i)
            {
                for(int j = 0; j < cols; ++j)
                {
                    if(matrix[i][j] == 0)
                    {
                        if (!zero_rows.Contains(i))
                            zero_rows.Add(i);
                        if (!zero_cols.Contains(j))
                            zero_cols.Add(j);
                    }
                }
            }

            foreach(int r in zero_rows)
            {
                for (int c = 0; c < cols; ++c)
                    matrix[r][c] = c;
            }

            foreach(int c in zero_cols)
            {
                for (int r = 0; r < rows; ++r)
                    matrix[r][c] = 0;
            }

        }

        // [1,2,3,4,5] val = 5
        // Given an array of integers and a value, determine if there are any two integeres in the array whose sum is equal to the given value
        static bool findSumOfTwo(int[] array, int value)
        {
            HashSet<int> traversedElements = new HashSet<int>();

            foreach(int element in array)
            {
                if (traversedElements.Contains(value - element))
                    return true;

                traversedElements.Add(element);
            }

            return false;
        }

        static void sortArray(int[] array, int n)
        {
            if (n == 1)
                return;

            for(int i = 0; i < n - 1; i++)
            {
                if(array[i] > array[i + 1])
                {
                    int tmp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = tmp;
                }
            }

            sortArray(array, n - 1);
        }

        static void invert(int[] arr)
        {
            int s = arr.Length / 2;
            int reverseIndex = arr.Length - 1;
            int tmpElement = 0;

            for (int i = 0; i < s; i++)
            {
                tmpElement = arr[i];
                arr[i] = arr[reverseIndex];
                arr[reverseIndex] = tmpElement;
                reverseIndex -= 1;
            }
        }

        static void invertR(int[] array, int currentIndex)
        {
            if (currentIndex < array.Length / 2)
            {
                int temp = array[currentIndex];
                array[currentIndex] = array[array.Length - 1 - currentIndex];
                array[array.Length - 1 - currentIndex] = temp;

                invertR(array, currentIndex + 1);
            }
        }

        // find the first occurrence of a number in an Array
        static int firstOccurrance(int[] arr, int n, int currentIndex)
        {
            if (arr.Length == currentIndex)
                return -1;
            else if (arr[currentIndex] == n)
                return currentIndex;
            return firstOccurrance(arr, n, currentIndex + 1);
        }

        static void permutations(char[] array, int length)
        {
            if (length == 1) { 
                Console.WriteLine(array);
                return;
            }

            for(int i = 0; i < length; i++)
            {
                swap(array, i, length - 1);
                permutations(array, length - 1);
                swap(array, i, length - 1);
            }
        }

        static void swap(char[] array, int i, int j)
        {
            char c;
            c = array[i];
            array[i] = array[j];
            array[j] = c;
        }

        // call stack - Last In First Out
        static String remDuplicatesR(String text)
        {
            if (text.Length == 1)
                return text;

            if (text.Substring(0, 1).Equals(text.Substring(1, 2)))
                return remDuplicatesR(text.Substring(1));

            return text.Substring(0, 1) + remDuplicatesR(text.Substring(1));
        }

        static String reverseStringR(String myString)
        {
            if (string.IsNullOrEmpty(myString))
                return myString;

            return reverseStringR(myString.Substring(1)) + myString.Substring(0, 1);
        }

        static int greatestCommonDivisor(int num1, int num2)
        {
            // all numbers can be expressed as production of prime numbers

            
            if (num1 == num2)
                return num1;

            if (num1 > num2)
                return greatestCommonDivisor(num1 - num2, num2);

            return greatestCommonDivisor(num1, num2 - num1);
        }

        static int sumAllR(int number)
        {
            if (number == 1)
                return number;

            return number + sumAllR(number - 1);
        }

        static int lengthOfListR(Node node)
        {
            if (node == null)
                return 0;

            return 1 + lengthOfList(node.next);
        }

        static int lengthOfList(Node head)
        {
            int count = 0;

            Node temp = head;

            while (temp != null)
            {
                count++;
                temp = temp.next;
            }

            return count;
        }

        static int countDigitsR(int n)
        {
            if (n < 0)
                return 1;

            return 1 + countDigits(n - 1);
        }
        
        static int countDigits(int n)
        {
            int count = 0;
            while(n > 0)
            {
                n /= 10;
                count++;
            }
            return count;
        }

        static int square(int n)
        {

            // base case
            if (n == 0)
                return 0;

            // (n - 1)squared -> (n2 - 2n + 1)

            // (n - 1)squared = (n2 - 2n + 1)

            // n2 = (n - 1)squared + n2 - 1


            return square(n - 1) + (2 * n) - 1;
            
        }
        // f1 = 0
        // f2 = 1

        // f[n] = f[n-2] + f[n-1]
        static int fibonacci(int len)
        {
            //5 
            // fib = 1 + 1 + 2 + 3 + 5 + 8 + 13 + 21 +
            int num1 = 0, num2 = 1, sumTemp = 0;
            int sum = 0;
            for(int i = 2; i < len; i++)
            {
                sumTemp = num1 + num2;
                sum += sumTemp;
                Console.WriteLine(", {0}", sumTemp);
                num1 = num2;
                num2 = sumTemp;
            }
            return sum;
        }

        // f[n] = f[n - 2] + f[n - 1]
        static int fib(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;

            return fib(n - 1) + fib(n - 2);
        }
        
        static int fibonacciRecursive(int len)
        {
            if (len == 0) return 0;
            if (len == 1) return 1;
            return fibonacciRecursive(len - 1) + fibonacciRecursive(len - 2);
        }

   
        static int fakultat(int number)
        {
            if (number == 0 || number == 1)
                return 1;
            return number * fakultat(number - 1);
        }

        static int xPowerY(int b, int power)
        {
            int m;
            if (power == 0)
                return 1;

            if (power % 2 == 0)
            {
                m = xPowerY(b, power / 2);
                return m * m;
            }

            return b * xPowerY(b, power - 1);
        }

        static long xPowerYIterative(int b, int power)
        {
            long product = 1;
            for(int i = 0; i < power; i++)
            {
                product *= b;
            }

            return product;
        }
    }
}
