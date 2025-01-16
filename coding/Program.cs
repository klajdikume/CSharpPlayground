// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
/*
Vending Machine

- accpets coins of 1,5,10,25 Cents
- User can select Products Cola(25)
- User can take refund by canceling the request
- Return the selected product and remaining change if any
- Reset operation for vending machine supplier

Vending machine
Item
Coin





 */

int MaxProfit(int[] prices)
{
    if (prices == null || prices.Length == 0)
        return 0;

    int buy1 = -prices[0];
    int sell1 = 0;
    int buy2 = -prices[0];
    int sell2 = 0;

    foreach (int price in prices)
    {
        buy1 = Math.Max(buy1, -price);
        sell1 = Math.Max(sell1, price + buy1);
        buy2 = Math.Max(buy2, sell1 - price);
        sell2 = Math.Max(sell2, price + buy2);
    }

    return sell2;
}


int[] prices1 = { 3, 3, 5, 0, 0, 3, 1, 4 };
Console.WriteLine(MaxProfit(prices1));

int LengthOfLongestSubstring(string s)
{
    if (string.IsNullOrEmpty(s)) return 0;

    int maxLength = 0;
    int left = 0;
    Dictionary<char, int> charIndexMap = new Dictionary<char, int>();

    for(int right = 0; right < s.Length; right++)
    {
        if (charIndexMap.ContainsKey(s[right]))
        {
            left = Math.Max(left, charIndexMap[s[right]] + 1);
        }

        charIndexMap[s[right]] = right;

        maxLength = Math.Max(maxLength, right - left + 1);
    }

    return maxLength;
}

string s1 = "abcabcbb";
Console.WriteLine(LengthOfLongestSubstring(s1)); // Output: 3

int LengthOfLongestSub(string s)
{
    if (string.IsNullOrEmpty(s)) { return 0; }

    // left and right pointer
    int maxLength = 0;
    int left = 0;
    Dictionary<char, int> charIndexMap = new Dictionary<char, int>();

    for(int right = 0; right < s.Length; right++)
    {
        if (charIndexMap.ContainsKey(s[right]))
        {
            left = Math.Max(left, charIndexMap[s[right]] + 1);
        }

        charIndexMap[s[right]] = right;

        maxLength = Math.Max(maxLength, right - left + 1);
    }

    return maxLength;
}

int RemoveDuplicates(int[] nums)
{
    int j = 1;
    for (int i = 1; i < nums.Length; i++)
    {
        if (nums[i] != nums[i - 1])
        {
            nums[j] = nums[i];
            j++;
        }
    }
    return j;
}

bool CanJump(int[] nums)
{
    if(nums == null || nums.Length == 0) return false;

    int n = nums.Length;
    int maxReachable = 0;

    for (int i = 0; i < nums.Length; i++)
    {
        if(i > maxReachable) return false;

        maxReachable = Math.Max(maxReachable, i + nums[i]);

        if (maxReachable >= n - 1) return true;
    }

    return false;
}

// Test cases
int[] nums1 = { 2, 3, 0, 1, 4 };
Console.WriteLine(CanJump(nums1));  // Output: true

/*

There are n gas stations along a circular route, where the amount of gas at the ith station is gas[i].

You have a car with an unlimited gas tank and it costs cost[i] of gas to travel from the ith station to its next (i + 1)th station.
You begin the journey with an empty tank at one of the gas stations.

Given two integer arrays gas and cost, return the starting gas station's index if you can travel around the circuit once in the clockwise direction,
otherwise return -1. If there exists a solution, it is guaranteed to be unique
 
 */

// amountGas = gas[iStation]

int CanCompleteCircuit(int[] gas, int[] cost)
{
    var n = gas.Length;
    var totalGas = gas.Sum();
    var totalCost = cost.Sum();
    var start = 0;
    var tank = 0;

    if (totalGas < totalCost) return -1;

    for (int i = 0; i < n; i++)
    {
        tank += gas[i];
        tank -= cost[i];

        if (tank < 0)
        {
            start = i + 1;
            tank = 0;
        }
    }
    return (tank >= 0) ? start : -1;
}

int[] gas1 = { 1, 2, 3, 4, 5 };
int[] cost1 = { 3, 4, 5, 1, 2 };
Console.WriteLine(CanCompleteCircuit(gas1, cost1));