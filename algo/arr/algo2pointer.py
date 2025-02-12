from typing import List


class Solution:
    def __init__(self):
        pass

    def sortedSquares(self, nums: List[int]) -> List[int]:
        left, right = 0, len(nums) - 1
        result = [0] * len(nums)
        position = len(nums) - 1

        while left <= right:
            if abs(nums[left]) > abs(nums[right]):
                result[position] = nums[left] ** 2
                left += 1
            else:
                result[position] = nums[right] ** 2
                right -= 1
                position -= 1

        return result
    
if __name__ == '__main__':
    a = Solution()
    print(a.sortedSquares([-4, -1, 0, 3, 10])) 
    # [0, 1, 9, 16, 100]