using NUnit.Framework;
using UnityEngine;
using AssignmentSystem.Services;
using System.Linq;
using NUnit.Framework.Internal;

namespace Assignment
{
    public class Assignment_Testcase
    {
        private IAssignment assignment;

        [SetUp]
        public void Setup()
        {
            // Reset static state before each test
            AssignmentDebugConsole.Clear();

            // Use FinalSolution as the test subject
            assignment = new FinalSolution();
        }

        [TearDown]
        public void Teardown()
        {
            if (assignment is MonoBehaviour)
            {
                MonoBehaviour.DestroyImmediate(assignment as MonoBehaviour);
            }
        }

        #region Lecture

        [Category("Lecture")]
        [TestCase(TestName = "LCT01_SequentialSearch1DArray", Description = "Lecture: Sequential Search in 1D Array")]
        public void LCT01_SequentialSearch1DArray()
        {
            assignment.LCT01_SequentialSearch1DArray();
            string expected = "5";
            string actual = AssignmentDebugConsole.GetOutput().Trim();
            Assert.AreEqual(expected, actual, $"Expected output is {expected} but actual output is {actual}");
        }

        [Category("Lecture")]
        [TestCase(TestName = "LCT02_SequentialSearch2DArray", Description = "Lecture: Sequential Search in 2D Array")]
        public void LCT02_SequentialSearch2DArray()
        {
            assignment.LCT02_SequentialSearch2DArray();
            string expected = "(2, 1)";
            string actual = AssignmentDebugConsole.GetOutput().Trim();
            Assert.AreEqual(expected, actual, $"Expected output is {expected} but actual output is {actual}");
        }

        [Category("Lecture")]
        [TestCase(TestName = "LCT03_BinarySearch", Description = "Lecture: Binary Search")]
        public void LCT03_BinarySearch()
        {
            assignment.LCT03_BinarySearch();
            string expected = "3";
            string actual = AssignmentDebugConsole.GetOutput().Trim();
            Assert.AreEqual(expected, actual, $"Expected output is {expected} but actual output is {actual}");
        }

        #endregion

        #region Assignment

        [Category("Assignment")]
        [TestCase(new int[] { 1, 2, 2, 2, 3 }, 2, new int[] { 1, 3 }, TestName = "AS01_FindFirstAndLastElementOfArray_Basic", Description = "Basic case with multiple occurrences")]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6, new int[] { -1 }, TestName = "AS01_FindFirstAndLastElementOfArray_NotFound", Description = "Target not in array")]
        [TestCase(new int[] { 5, 5, 5, 5, 5 }, 5, new int[] { 0, 4 }, TestName = "AS01_FindFirstAndLastElementOfArray_AllSame", Description = "All elements are target")]
        [TestCase(new int[] { 1 }, 1, new int[] { 0, 0 }, TestName = "AS01_FindFirstAndLastElementOfArray_SingleElement", Description = "Single element array")]
        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 1, 1 }, TestName = "AS01_FindFirstAndLastElementOfArray_SingleOccurrence", Description = "Single occurrence in middle")]
        public void Test_AS01_FindFirstAndLastElementOfArray(int[] array, int target, int[] expected)
        {
            assignment.AS01_FindFirstAndLastElementOfArray(array, target);
            string output = AssignmentDebugConsole.GetOutput().Trim();
            string[] lines = output.Split('\n');
            int[] actual = lines.Select(int.Parse).ToArray();
            CollectionAssert.AreEquivalent(expected, actual, $"Expected numbers {string.Join(",", expected)} but actual {string.Join(",", actual)}");
        }

        [Category("Assignment")]
        [TestCase(new int[] { 4, 2, 10, 9, 8, 11 }, 9, "8", TestName = "AS02_FindMaxLessThan_Basic", Description = "Basic case")]
        [TestCase(new int[] { 4, 2, 10, 9, 8, 11 }, 2, "-1", TestName = "AS02_FindMaxLessThan_NoLess", Description = "No value less than target")]
        [TestCase(new int[] { 1, 2, 3, 5, 6 }, 5, "3", TestName = "AS02_FindMaxLessThan_Middle", Description = "Target in middle")]
        [TestCase(new int[] { 15, 5, 20, 40, 30 }, 5, "-1", TestName = "AS02_FindMaxLessThan_Smallest", Description = "Target is smallest")]
        [TestCase(new int[] { 1, 2, 3 }, 4, "3", TestName = "AS02_FindMaxLessThan_AllLess", Description = "All values less than target")]
        public void Test_AS02_FindMaxLessThan(int[] array, int target, string expected)
        {
            assignment.AS02_FindMaxLessThan(array, target);
            string actual = AssignmentDebugConsole.GetOutput().Trim();
            Assert.AreEqual(expected, actual, $"Expected output is {expected} but actual output is {actual}");
        }

        [Category("Assignment")]
        [TestCase(new int[] { 1, 3, 5, 7, 9 }, 4, 8, new int[] { 5, 7 }, TestName = "AS03_FindRange_Basic", Description = "Basic range")]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6, 10, new int[] { }, TestName = "AS03_FindRange_Empty", Description = "No values in range")]
        [TestCase(new int[] { 10, 20, 30, 40, 50 }, 10, 50, new int[] { 10, 20, 30, 40, 50 }, TestName = "AS03_FindRange_All", Description = "All values in range")]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 4, new int[] { 2, 3, 4 }, TestName = "AS03_FindRange_Middle", Description = "Range in middle")]
        [TestCase(new int[] { 5 }, 5, 5, new int[] { 5 }, TestName = "AS03_FindRange_Single", Description = "Single element in range")]
        public void Test_AS03_FindRange(int[] array, int min, int max, int[] expected)
        {
            assignment.AS03_FindRange(array, min, max);
            string output = AssignmentDebugConsole.GetOutput().Trim();
            if (expected.Length == 0)
            {
                Assert.AreEqual("Empty", output, $"Expected Empty but actual {output}");
            }
            else
            {
                string[] lines = output.Split('\n');
                int[] actual = lines.Select(int.Parse).ToArray();
                CollectionAssert.AreEquivalent(expected, actual, $"Expected numbers {string.Join(",", expected)} but actual {string.Join(",", actual)}");
            }
        }

        #endregion

        #region Extra

        [Category("Extra")]
        [TestCase(new int[] { 2, 3, 7, 8, 10 }, 15, new int[] { 2, 3, 7 }, TestName = "EX01_FindTargetEnemies_Basic", Description = "Basic case with multiple enemies")]
        [TestCase(new int[] { 2, 3, 7, 8, 10 }, 3, new int[] { 2 }, TestName = "EX01_FindTargetEnemies_Single", Description = "Mana enough for one enemy")]
        [TestCase(new int[] { 2, 3, 7, 8, 10 }, 6, new int[] { 2, 3 }, TestName = "EX01_FindTargetEnemies_Two", Description = "Mana enough for two enemies")]
        [TestCase(new int[] { 1, 2, 3 }, 10, new int[] { 1, 2, 3 }, TestName = "EX01_FindTargetEnemies_All", Description = "Mana enough for all")]
        [TestCase(new int[] { 5, 10 }, 4, new int[] { }, TestName = "EX01_FindTargetEnemies_None", Description = "Mana not enough for any")]
        public void Test_EX01_FindTargetEnemies(int[] enemyHPs, int mana, int[] expected)
        {
            assignment.EX01_FindTargetEnemies(enemyHPs, mana);
            string output = AssignmentDebugConsole.GetOutput().Trim();
            if (expected.Length == 0)
            {
                Assert.AreEqual("", output, $"Expected no output but actual {output}");
            }
            else
            {
                string[] lines = output.Split('\n');
                int[] actual = lines.Select(int.Parse).ToArray();
                CollectionAssert.AreEquivalent(expected, actual, $"Expected numbers {string.Join(",", expected)} but actual {string.Join(",", actual)}");
            }
        }

        #endregion

    }
}