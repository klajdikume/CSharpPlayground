import unittest
from arr.algoshashset import Solution

class TestSolution(unittest.TestCase):
    
    def setUp(self):
        self.solution = Solution()

    def test_numJewelsInStones(self):
        self.assertEqual(self.solution.numJewelsInStones("aA", "aAAbbbb"), 3)
        self.assertEqual(self.solution.numJewelsInStones("z", "ZZ"), 0)

    def test_numJewels(self):
        self.assertEqual(self.solution.numJewels("aA", "aAAbbbb"), 3)
        self.assertEqual(self.solution.numJewels("z", "ZZ"), 0)

    def test_twoSum(self):
        self.assertEqual(self.solution.twoSum([2, 7, 11, 15], 9), [0, 1])
        self.assertEqual(self.solution.twoSum([3, 2, 4], 6), [1, 2])
        self.assertEqual(self.solution.twoSum([3, 3], 6), [0, 1])

    def test_twoSum2(self):
        self.assertEqual(self.solution.twoSum2([2, 7, 11, 15], 9), [0, 1])
        self.assertEqual(self.solution.twoSum2([3, 2, 4], 6), [1, 2])
        self.assertEqual(self.solution.twoSum2([3, 3], 6), [0, 1])

    def test_longestConsuctiveSequence(self):
        self.assertEqual(self.solution.longestConsuctiveSequence([100, 4, 200, 1, 3, 2]), 4)
        self.assertEqual(self.solution.longestConsuctiveSequence([0, -1]), 2)
        self.assertEqual(self.solution.longestConsuctiveSequence([]), 0)

if __name__ == '__main__':
    unittest.main()