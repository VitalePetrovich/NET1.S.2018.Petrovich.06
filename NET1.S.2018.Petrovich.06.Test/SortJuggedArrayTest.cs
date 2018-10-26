using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static NET1.S._2018.Petrovich._06.SortJuggedArray;

namespace NET1.S._2018.Petrovich._06.Test
{
    [TestFixture]
    public class SortJuggedArrayTest
    {
        [Test]
        public void BubbleSortJuggedArrayBySumRows1_RightIn_RightOut()
        {
            int[][] inJuggedArray = 
            {
                new[] { 3, 2, 2, 6 },
                new[] { 10, 3 },
                new[] { 1, 1, 1, 1 }
            };

            int[][] expectedJuggedArray = 
            {
                new[] { 3, 2, 2, 6},
                new[] { 10, 3 },
                new[] { 1, 1, 1, 1 }
            };
            
            BubbleSortJuggedArray(inJuggedArray, new SortRowsBySumDescending());

            Assert.IsTrue(IsEqualJuggedArray(inJuggedArray, expectedJuggedArray));
        }

        [Test]
        public void BubbleSortJuggedArrayBySumRows2_RightIn_RightOut()
        {
            int[][] inJuggedArray = 
            {
                new[] { 9, 2, 13, 0 },
                null,
                new[] { 17, 1, 90, -2 },
                new[] { -1 },
                null,
                new[] { 5, 14, 2, 0 }
            };

            int[][] expectedJuggedArray = 
            {
                null,
                null,
                new[] { -1 },
                new[] { 5, 14, 2, 0 },
                new[] { 9, 2, 13, 0 },
                new[] { 17, 1, 90, -2 }
            };

            BubbleSortJuggedArray(inJuggedArray, new SortRowsBySum());

            Assert.IsTrue(IsEqualJuggedArray(inJuggedArray, expectedJuggedArray));
        }
        
        [Test]
        public void BubbleSortJuggedArrayByMaxRows1_RightIn_RightOut()
        {
            int[][] inJuggedArray =
            {
                new[] { 3, 2, 2, 6 },
                new[] { 10, 3 },
                null,
                null,
                new[] { 1, 1, 1, 1 }
            };

            int[][] expectedJuggedArray =
            {
                null,
                null,
                new[] { 1, 1, 1, 1 },
                new[] { 3, 2, 2, 6},
                new[] { 10, 3 }
            };

            BubbleSortJuggedArray(inJuggedArray, new SortRowsByMaxElement());

            Assert.IsTrue(IsEqualJuggedArray(inJuggedArray, expectedJuggedArray));
        }

        [Test]
        public void BubbleSortJuggedArrayByMaxRows2_RightIn_RightOut()
        {
            int[][] inJuggedArray =
            {
                new[] { 9, 2, 13, 0 },
                new[] { 17, 1, 90, -2 },
                new[] { -1 },
                new[] { 5, 14, 2, 0 }
            };

            int[][] expectedJuggedArray =
            {
                new[] { 17, 1, 90, -2 },
                new[] { 9, 2, 13, 0 },
                new[] { -1 },
                new[] { 5, 14, 2, 0 }
            };

            BubbleSortJuggedArray(inJuggedArray, 0, 2, new SortRowsByMaxElementDescending());

            Assert.IsTrue(IsEqualJuggedArray(inJuggedArray, expectedJuggedArray));
        }

        [Test]
        public void BubbleSortJuggedArrayByMinRows1_RightIn_RightOut()
        {
            int[][] inJuggedArray =
            {
                new[] { 3, 2, 2, 6 },
                new[] { 10, 3 },
                new[] { 1, 1, 1, 1 }
            };

            int[][] expectedJuggedArray =
            {
                new[] { 10, 3 },
                new[] { 3, 2, 2, 6},
                new[] { 1, 1, 1, 1 }
            };

            BubbleSortJuggedArray(inJuggedArray, new SortRowsByMinElementDescending());

            Assert.IsTrue(IsEqualJuggedArray(inJuggedArray, expectedJuggedArray));
        }

        [Test]
        public void BubbleSortJuggedArrayByMinRows2_RightIn_RightOut()
        {
            int[][] inJuggedArray =
            {
                new[] { 9, 2, 13, 0 },
                new[] { 17, 1, 90, -2 },
                null,
                new[] { -1 },
                new[] { 5, 14, 2, 0 }
            };

            int[][] expectedJuggedArray =
            {
                new[] { 17, 1, 90, -2 },
                new[] { 9, 2, 13, 0 },
                null,
                new[] { -1 },
                new[] { 5, 14, 2, 0 }
            };

            BubbleSortJuggedArray(inJuggedArray, 0, 1, new SortRowsByMinElement());

            Assert.IsTrue(IsEqualJuggedArray(inJuggedArray, expectedJuggedArray));
        }

        [Test]
        public void BubbleSortJuggedArray_WithNullReferenceArray()
            => Assert.Throws<ArgumentNullException>(() => BubbleSortJuggedArray(null, new SortRowsBySum()));

        [Test]
        public void BubbleSortJuggedArray_WithNullReferenceComparer()
        {
            int[][] array = { new[] { 0 } };

            Assert.Throws<ArgumentNullException>(() => BubbleSortJuggedArray(array, null));
        }

        [Test]
        public void BubbleSortJuggedArray_WithLeftEdgeGraterThanRight()
        {
            int[][] array = { new[] { 0 } };

            Assert.Throws<ArgumentException>(() => BubbleSortJuggedArray(array, 10, 1, new SortRowsBySum()));
        }

        private bool IsEqualJuggedArray(int[][] firstArray, int[][] secondArray)
        {
            if (firstArray == null && secondArray == null)
                return true;

            if (firstArray == null || secondArray == null)
                return false;

            if (firstArray.Length != secondArray.Length)
                return false;

            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] == null && secondArray[i] == null)
                    continue;

                if (firstArray[i] == null || secondArray[i] == null)
                    break;

                if (firstArray[i].Length != secondArray[i].Length)
                    return false;

                for (int j = 0; j < firstArray[i].Length; j++)
                {
                    if (firstArray[i][j] != secondArray[i][j])
                        return false;
                }
            }

            return true;
        }
    }

}
