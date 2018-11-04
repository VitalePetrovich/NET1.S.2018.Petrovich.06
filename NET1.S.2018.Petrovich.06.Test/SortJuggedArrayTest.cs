using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NET1.S._2018.Petrovich._06;
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

            Assert.AreEqual(inJuggedArray, expectedJuggedArray);
        }

        [Test]
        public void BubbleSortJuggedArrayBySumRows1D_RightIn_RightOut()
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

            BubbleSortJuggedArray(inJuggedArray, (x, y) => y.GetSum().CompareTo(x.GetSum()));
            
            Assert.AreEqual(inJuggedArray, expectedJuggedArray);
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

            Assert.AreEqual(inJuggedArray, expectedJuggedArray);
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

            Assert.AreEqual(inJuggedArray, expectedJuggedArray);
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

            Assert.AreEqual(inJuggedArray, expectedJuggedArray);
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

            Assert.AreEqual(inJuggedArray, expectedJuggedArray);
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

            Assert.AreEqual(inJuggedArray, expectedJuggedArray);
        }

        [Test]
        public void BubbleSortJuggedArrayByMinRows2D_RightIn_RightOut()
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

            BubbleSortJuggedArray(inJuggedArray, 0, 1, (x, y) => x.GetMin().CompareTo(y.GetMin()));

            Assert.AreEqual(inJuggedArray, expectedJuggedArray);
        }

        [Test]
        public void BubbleSortJuggedArray_WithNullReferenceArray()
            => Assert.Throws<ArgumentNullException>(() => BubbleSortJuggedArray(null, new SortRowsBySum()));
        
        [Test]
        public void BubbleSortJuggedArray_WithLeftEdgeGraterThanRight()
        {
            int[][] array = { new[] { 0 } };

            Assert.Throws<ArgumentException>(() => BubbleSortJuggedArray(array, 10, 1, new SortRowsBySum()));
        }

        [Test]
        public void BubbleSortJuggedArrayByMaxAdvancedImplementWithComparer_RightIn_RightOut()
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

            SortJuggedArrayImplementationForTests.BubbleSortJuggedArray(inJuggedArray, new SortRowsByMaxElement());

            Assert.AreEqual(inJuggedArray, expectedJuggedArray);
        }

        [Test]
        public void BubbleSortJuggedArrayByMaxAdvancedImplementWithDelegate_RightIn_RightOut()
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

            SortJuggedArrayImplementationForTests.BubbleSortJuggedArray(inJuggedArray, (x, y) => x.GetMax().CompareTo(y.GetMax()));

            Assert.AreEqual(inJuggedArray, expectedJuggedArray);
        }
    }
}
