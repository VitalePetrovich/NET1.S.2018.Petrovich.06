using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NET1.S._2018.Petrovich._06
{
    public interface IComparer
    {
        int Compare(int[] firstSubArray, int[] secondSubArray);
    }

    /// <summary>
    /// Class containing comparison logic by sum.
    /// </summary>
    public class SortRowsBySum : IComparer
    {
        public int Compare(int[] firstSubArray, int[] secondSubArray)
        {
            if (ReferenceEquals(firstSubArray, secondSubArray))
                return 0;

            if (ReferenceEquals(firstSubArray, null))
                return -1;

            if (ReferenceEquals(secondSubArray, null))
                return 1;

            return GetSum(firstSubArray) - GetSum(secondSubArray);
        }

        private int GetSum(int[] array)
        {
            int sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }
    }

    /// <summary>
    /// Class containing comparison logic by sum.
    /// </summary>
    public class SortRowsBySumDescending : SortRowsBySum, IComparer
    {
        public new int Compare(int[] firstSubArray, int[] secondSubArray) 
            => -base.Compare(firstSubArray, secondSubArray);
    }

    /// <summary>
    /// Class containing comparison logic by max element.
    /// </summary>
    public class SortRowsByMaxElement : IComparer
    {
        public int Compare(int[] firstSubArray, int[] secondSubArray)
        {
            if (ReferenceEquals(firstSubArray, secondSubArray))
                return 0;

            if (firstSubArray == null)
                return -1;

            if (secondSubArray == null)
                return 1;

            return GetMax(firstSubArray) - GetMax(secondSubArray);
        }

        private int GetMax(int[] array)
        {
            int indexOfMax = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > array[indexOfMax])
                {
                    indexOfMax = i;
                }
            }

            return array[indexOfMax];
        }
    }

    /// <summary>
    /// Class containing comparison logic by max element.
    /// </summary>
    public class SortRowsByMaxElementDescending : SortRowsByMaxElement, IComparer
    {
        public new int Compare(int[] firstSubArray, int[] secondSubArray)
            => -base.Compare(firstSubArray, secondSubArray);
    }

    /// <summary>
    /// Class containing comparison logic by min element.
    /// </summary>
    public class SortRowsByMinElement : IComparer
    {
        public int Compare(int[] firstSubArray, int[] secondSubArray)
        {
            if (ReferenceEquals(firstSubArray, secondSubArray))
                return 0;

            if (firstSubArray == null)
                return -1;

            if (secondSubArray == null)
                return 1;

            return GetMin(firstSubArray) - GetMin(secondSubArray);
        }

        private int GetMin(int[] array)
        {
            int indexOfMin = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < array[indexOfMin])
                {
                    indexOfMin = i;
                }
            }

            return array[indexOfMin];
        }

    }

    /// <summary>
    /// Class containing comparison logic by min element.
    /// </summary>
    public class SortRowsByMinElementDescending : SortRowsByMinElement, IComparer
    {
        public int Compare(int[] firstSubArray, int[] secondSubArray)
            => -base.Compare(firstSubArray, secondSubArray);
    }

    /// <summary>
    /// Class for sorting jugged array.
    /// </summary>
    public static class SortJuggedArray
    {
        /// <summary>
        /// Bubble sorting jugged array.
        /// </summary>
        /// <param name="inJuggedArray">
        /// Array for sorting.
        /// </param>
        /// <param name="lowIndex">
        /// Low index of sub-array for sorting.
        /// </param>
        /// <param name="highIndex">
        /// High index of sub-array for sorting.
        /// </param>
        /// <param name="comparator">
        /// Class instance containing comparison logic.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throw if reference of jugged array or comparator is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws if mode is incorrect or high index less than low index.
        /// </exception>
        public static void BubbleSortJuggedArray(
            int[][] inJuggedArray,
            int lowIndex,
            int highIndex,
            IComparer comparator)
        {
            if (inJuggedArray == null)
                throw new ArgumentNullException(nameof(inJuggedArray));

            if (comparator == null)
                throw new ArgumentNullException(nameof(comparator));

            if (lowIndex >= highIndex)
                throw new ArgumentException($"{nameof(highIndex)} must be greater than {nameof(lowIndex)}!");

            if (lowIndex < 0 || lowIndex >= inJuggedArray.Length)
                throw new ArgumentException($"{nameof(lowIndex)} out of range.");

            if (highIndex < 0 || highIndex >= inJuggedArray.Length)
                throw new ArgumentException($"{nameof(lowIndex)} out of range.");

            for (int i = lowIndex; i <= highIndex; i++)
            {
                for (int j = lowIndex; j < highIndex - lowIndex; j++)
                {
                    if (comparator.Compare(inJuggedArray[j], inJuggedArray[j + 1]) > 0)
                    {
                        SwapReference(ref inJuggedArray[j], ref inJuggedArray[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Bubble sorting jugged array.
        /// </summary>
        /// <param name="inJuggedArray">
        /// Array for sorting.
        /// </param>
        /// <param name="comparator">
        /// Class instance containing comparison logic.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throw if reference of jugged array or comparator is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws if mode is incorrect or high index less than low index.
        /// </exception>
        public static void BubbleSortJuggedArray(int[][] inJuggedArray, IComparer comparator)
        {
            if (inJuggedArray == null)
                throw new ArgumentNullException(nameof(inJuggedArray));

            BubbleSortJuggedArray(inJuggedArray, 0, inJuggedArray.Length - 1, comparator);
        }

        private static void SwapReference(ref int[] refA, ref int[] refB)
        {
            int[] temp = refA;
            refA = refB;
            refB = temp;
        }
    }
}
