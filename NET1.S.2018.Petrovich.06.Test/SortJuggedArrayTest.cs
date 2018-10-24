using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NET1.S._2018.Petrovich._06.Test
{
    [TestFixture]
    public class SortJuggedArrayTest
    {
        [Test]
        public void SortJuggedBySumRows1_RightIn_RightOut()
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

            SortJuggedArray.SortJugged(inJuggedArray, "RowsBySum", false);

            Assert.IsTrue(IsEqualJuggedArray(inJuggedArray, expectedJuggedArray));
        }

        [Test]
        public void SortJuggedBySumRows2_RightIn_RightOut()
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
                new[] { -1 },
                new[] { 5, 14, 2, 0 },
                new[] { 9, 2, 13, 0 },
                new[] { 17, 1, 90, -2 }
            };

            SortJuggedArray.SortJugged(inJuggedArray, "RowsBySum");

            Assert.IsTrue(IsEqualJuggedArray(inJuggedArray, expectedJuggedArray));
        }
        
        [Test]
        public void SortJuggedByMaxRows1_RightIn_RightOut()
        {
            int[][] inJuggedArray =
            {
                new[] { 3, 2, 2, 6 },
                new[] { 10, 3 },
                new[] { 1, 1, 1, 1 }
            };

            int[][] expectedJuggedArray =
            {
                new[] { 1, 1, 1, 1 },
                new[] { 3, 2, 2, 6},
                new[] { 10, 3 }
            };

            SortJuggedArray.SortJugged(inJuggedArray, "RowsByMax");

            Assert.IsTrue(IsEqualJuggedArray(inJuggedArray, expectedJuggedArray));
        }

        [Test]
        public void SortJuggedByMaxRows2_RightIn_RightOut()
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

            SortJuggedArray.SortJugged(inJuggedArray, 0, 2, "RowsByMax", false);

            Assert.IsTrue(IsEqualJuggedArray(inJuggedArray, expectedJuggedArray));
        }

        [Test]
        public void SortJuggedByMinRows1_RightIn_RightOut()
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

            SortJuggedArray.SortJugged(inJuggedArray, "RowsByMin", false);

            Assert.IsTrue(IsEqualJuggedArray(inJuggedArray, expectedJuggedArray));
        }

        [Test]
        public void SortJuggedByMinRows2_RightIn_RightOut()
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

            SortJuggedArray.SortJugged(inJuggedArray, 0, 1, "RowsByMin");

            Assert.IsTrue(IsEqualJuggedArray(inJuggedArray, expectedJuggedArray));
        }

        [Test]
        public void SortJuggedInsideEachRow1_RightIn_RightOut()
        {
            int[][] inJuggedArray =
            {
                new[] { 3, 2, 2, 6 },
                new[] { 10, 3 },
                new[] { 1, 1, 1, 1 }
            };

            int[][] expectedJuggedArray =
            {
                new[] { 2, 2, 3, 6},
                new[] { 3, 10 },
                new[] { 1, 1, 1, 1 }
            };

            SortJuggedArray.SortJugged(inJuggedArray, "InsideEachRow");

            Assert.IsTrue(IsEqualJuggedArray(inJuggedArray, expectedJuggedArray));
        }

        [Test]
        public void SortJuggedInsideEachRow2_RightIn_RightOut()
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
                new[] { 9, 2, 13, 0 },
                new[] { 17, 1, 90, -2 },
                new[] { -1 },
                new[] { 14, 5, 2, 0 }
            };

            SortJuggedArray.SortJugged(inJuggedArray, 2, 3, "InsideEachRow", false);

            Assert.IsTrue(IsEqualJuggedArray(inJuggedArray, expectedJuggedArray));
        }

        [Test]
        public void SortJugged_WithNullReferenceArray()
            => Assert.Throws<ArgumentNullException>(() => SortJuggedArray.SortJugged(null, 0, 1, "RowsBySum"));

        [Test]
        public void SortJugged_WithNullReferenceMode()
        {
            int[][] array = { new[] { 0 } };

            Assert.Throws<ArgumentNullException>(() => SortJuggedArray.SortJugged(array, null));
        }

        [Test]
        public void SortJugged_WithLeftEdgeGraterThanRight()
        {
            int[][] array = { new[] { 0 } };

            Assert.Throws<ArgumentException>(() => SortJuggedArray.SortJugged(array, 10, 1, "RowsBySum"));
        }

        private bool IsEqualJuggedArray(int[][] firstArray, int[][] secondArray)
        {
            if (firstArray.Length != secondArray.Length)
                return false;

            for (int i = 0; i < firstArray.Length; i++)
            {
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
