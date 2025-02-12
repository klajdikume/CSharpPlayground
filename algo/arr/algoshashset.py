from typing import List


class Solution:
    # jewels = "aA", stones = "aAAbbbb" 
    # output: 3
    def numJewelsInStones(self, jewels: str, stones: str) -> str:
        return sum(s in jewels for s in stones)
    
    def numJewels(self, jewels: str, stones: str) -> int:
        s = set(jewels)
        count = 0

        for stone in stones:
            if stone in s:
                count += 1

        return count # Time: O (m + n), Space: O(n)
    
    # [1, 2, 3, 4, 5, 6, 7], k = 5 
    # 
    def twoSum(self, nums: List[int], target: int) -> List[int]:
        h = {}
        for i in range(len(nums)):
            h[nums[i]] = i

        for i in range(len(nums)):
            y = target - nums[i]

            if y in h and h[y] != i:
                return [i, h[y]]
            
    def twoSum2(self, nums: List[int], target: int) -> List[int]:
        h = {}
        for i, num in enumerate(nums):
            y = target - num
            if y in h:
                return [h[y], i]
            h[num] = i
    
    # [100, 4, 200, 1, 3, 2]
    # create a set with array input
    # iterate the array 
        # if num - 1 not in h -> make sure is the start of the sequence
        # check if the next number is in the set and increment the streak
        # update the longest streak
    # h -> {100, 4, 200, 1, 3, 2}
    def longestConsuctiveSequence(self, nums: List[int]) -> int:
        h = set(nums)
        longest = 0

        for num in nums:
            if num - 1 not in h:
                current_num = num
                current_streak = 1

                while current_num + 1 in h:
                    current_num += 1
                    current_streak += 1

                longest = max(longest, current_streak)

        return longest
    
    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:
        h = {}
        for s in strs:
            key = tuple(sorted(s))
            if key not in h:
                h[key] = []
            h[key].append(s)
        return list(h.values())
    
if __name__ == '__main__':
    a = Solution()
    b = a.longestConsuctiveSequence([100, 4, 200, 1, 3, 2])
    print(b)
    print(a.groupAnagrams(["tea", "ate", "eat", "apple", "java", "vaja", "orange", "egnaro"]))
    
    