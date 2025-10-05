using System;
using System.Collections.Generic;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment
{
    public class StudentSolution : IAssignment
    {
        #region Lecture

        public void LCT01_SequentialSearch1DArray()
        {
            int[] array = new int[] { 34, 21, 56, 12, 78, 90, 11, 23 };
            int target = 90;
            int index = -1;

            // Your code here ...
            // ...


            Debug.Log(index);
        }

        public void LCT02_SequentialSearch2DArray()
        {
            int[,] array = new int[,]
            {
                { 34, 21, 56 },
                { 12, 78, 90 },
                { 11, 23, 45 }
            };
            int target = 23;
            int row = -1;
            int col = -1;

            // Your code here ...
            // ...

            Debug.Log($"({row}, {col})");
        }

        public void LCT03_BinarySearch()
        {
            int[] array = new int[] { 11, 12, 21, 23, 34, 45, 56, 78, 90 };
            int target = 23;
            int index = -1;

            // Your code here ...
            // ...

            Debug.Log(index);
        }

        #endregion

        #region Assignment

        public void AS01_FindFirstAndLastElementOfArray(int[] array, int target)
        {
            throw new NotImplementedException();
        }

        public void AS02_FindMaxLessThan(int[] array, int target)
        {
            throw new NotImplementedException();
        }

        public void AS03_FindRange(int[] array, int min, int max)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Extra

        public void EX01_FindTargetEnemies(int[] enemyHPs, int mana)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}