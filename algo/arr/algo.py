from typing import List


def find_closest_to_zero(numbers):
    if not numbers:
        return None
    closest = numbers[0]
    for num in numbers:
        if abs(num) < abs(closest) or (abs(num) == abs(closest) and num > closest):
            closest = num
    return closest

# Example usage

numbers = [3, -2, 2, -1, 5, -3]
print("The closest number to zero is:", find_closest_to_zero(numbers))

# Remove Duplicates from an array
# [1, 1, 2] -> [1, 2, _]
# [0, 0->1, 1-> 1, 1, 1, 2, 2, 3, 3, 4]
#                  i       
#                  j

class Solution:
    def removeDuplicates(self, nums: List[int]) -> int:
        n = len(nums)
        j = 1

        for i in range(1, n):
            if nums[i] != nums[i-1]:
                nums[j] = nums[i]
                j += 1

        return j
    
    def mergeAlternately(self, word1: str, word2: str) -> str:
        A, B = len(word1), len(word2)
        a, b = 0, 0
        s = []

        word = 1
        while a < A and b < B:
            if word == 1:
                s.append(word1[a])
                a += 1
                word = 2
            else:
                s.append(word2[b])
                b += 1
                word = 1
        while a < A:
            s.append(word1[a])
            a += 1

        while b < B:
            s.append(word2[b])
            b += 1
        
        return ''.join(s)

    def romanToInt(self, s: str) -> int:
        roman_to_int = {
            'I': 1, 'V': 5, 'X': 10, 'L': 50,
            'C': 100, 'D': 500, 'M': 1000
        }
        total = 0
        prev_value = 0
        for char in reversed(s):
            value = roman_to_int[char]
            if value < prev_value:
                total -= value
            else:
                total += value
            prev_value = value
        return total
    
    def isSubsequence(s: str, t: str) -> bool:
        i = 0
        for char in t:
            if i < len(s) and s[i] == char:
                i += 1
        return i == len(s)

    def rotate90Degree(self, matrix: List[List[int]]) -> None:
        n = len(matrix)
        for i in range(n):
            for j in range(i, n):
                matrix[i][j], matrix[j][i] = matrix[j][i], matrix[i][j]
        for i in range(n):
            matrix[i].reverse()
        
    # max profit to sell stock

    def maxProfit(self, prices: List[int]) -> int:
        i = 0
        lo = prices[0]
        hi = prices[0]
        profit = 0
        n = len(prices)

        while i < n - 1:
            # look where to buy
            while i < n - 1 and prices[i] >= prices[i+1]:
                i += 1
            lo = prices[i] # buy
            # look where to sell
            while i < n - 1 and prices[i] <= prices[i+1]:
                i += 1
            hi = prices[i] # sell
            profit += hi - lo

        return profit
    # intervals = [[1,3],[2,6],[8,10],[15,18]]
    # Output: [[1,6],[8,10],[15,18]]

    def merge(self, intervals: List[List[int]]) -> List[List[int]]:
        intervals.sort(key = lambda x: x[0])
        merged = []
        
        for interval in intervals:
            if not merged or merged[-1][1] < interval[0]:
                merged.append(interval)
            else:
                merged[-1] = [merged[-1], max(merged[-1][1], interval[1])]
        return merged

    def longestCommonPrefix(self, strs: List[str]) -> str:
        min_length = float('inf')
        i = 0
        
        for s in strs:
            if(len(s) < min_length):
                min_length = len(s)
        
        while i < min_length: 
            for s in strs:
                if s[i] != strs[0][i]:
                    return s[:i]
                
            i += 1

        return strs[:i]
    
if __name__ == '__main__':
    print(Solution().longestCommonPrefix(["flower","flow","flight"])) # fl