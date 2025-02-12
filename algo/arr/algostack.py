from typing import List


class Solution:
    def __init__(self):
        pass

    # ["5", "2", "C", ""D", "+"]
    # "5" - Add 5 to the record, record is now [5].
    # "2" - Add 2 to the record, record is now [5, 2].
    # "C" - Invalidate the previous score, record is now [5].
    # "D" - Add double the previous score to the record, record is now [5, 10].
    # "+" - Add the previous two scores to the record, record is now [5, 10, 15].
    # Sum the record. 
    def calPoints(self, operations: List[str]) -> int:
        record = []
        for operation in operations:
            if operation == 'C':
                record.pop()
            elif operation == 'D':
                record.append(record[-1] * 2)
            elif operation == '+':
                record.append(record[-1] + record[-2])
            else:
                record.append(int(operation))
 
        return sum(record)
    
    def isValidParatheses(self, s: str) -> bool:
        hashmap = {')': '(', '}': '{', ']': '['}
        stack = []
        for char in s:
            if char in hashmap:
                top = stack.pop() if stack else '#'
                if hashmap[char] != top:
                    return False
            else:
                stack.append(char)

        return not stack

    # return an array of the days that have to wait to get warmer
    # temperatures = [73, 74, 75, 71, 69, 72, 76, 73]
    # result = [1, 1, 4, 2, 1, 1, 0, 0]
    def dailyTemperatures(self, temperatures: List[int]) -> List[int]:
        n = len(temperatures)
        answer = [0] * n
        stack = []

        for i, t in enumerate(temperatures):
            while stack and temperatures[stack[-1]] < t:
                cur = stack.pop()
                answer[cur] = i - cur
        
            stack.append(i)

        return answer
    
if __name__ == '__main__':
    a = Solution()
    print(a.dailyTemperatures([73, 74, 75, 71, 69, 72, 76, 73]))