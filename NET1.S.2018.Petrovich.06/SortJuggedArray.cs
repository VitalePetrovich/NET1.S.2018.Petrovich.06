using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NET1.S._2018.Petrovich._06
{
    public interface IComparator
    {
        bool Compare(int[] firstSubArray, int[] secondSubArray);
    }

    /// <summary>
    /// Class containing comparison logic by sum.
    /// </summary>
    public class SortRowsBySum : IComparator
    {
        public bool Compare(int[] firstSubArray, int[] secondSubArray)
        {
            if (firstSubArray == null && secondSubArray == null)
                return false;

            if (firstSubArray == null)
                return false;

            if (secondSubArray == null)
                return true;

            return GetSum(firstSubArray) > GetSum(secondSubArray);
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
    public class SortRowsBySumDescending : IComparator
    {
        public bool Compare(int[] firstSubArray, int[] secondSubArray)
        {
            if (firstSubArray == null && secondSubArray == null)
                return false;

            if (firstSubArray == null)
                return true;

            if (secondSubArray == null)
                return false;

            return GetSum(firstSubArray) < GetSum(secondSubArray);
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
    /// Class containing comparison logic by max element.
    /// </summary>
    public class SortRowsByMaxElement : IComparator
    {
        public bool Compare(int[] firstSubArray, int[] secondSubArray)
        {
            if (firstSubArray == null && secondSubArray == null)
                return false;

            if (firstSubArray == null)
                return false;

            if (secondSubArray == null)
                return true;

            return GetMax(firstSubArray) > GetMax(secondSubArray);
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
    public class SortRowsByMaxElementDescending : IComparator
    {
        public bool Compare(int[] firstSubArray, int[] secondSubArray)
        {
            if (firstSubArray == null && secondSubArray == null)
                return false;

            if (firstSubArray == null)
                return true;

            if (secondSubArray == null)
                return false;

            return GetMax(firstSubArray) < GetMax(secondSubArray);
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
    /// Class containing comparison logic by min element.
    /// </summary>
    public class SortRowsByMinElement : IComparator
    {
        public bool Compare(int[] firstSubArray, int[] secondSubArray)
        {
            if (firstSubArray == null && secondSubArray == null)
                return false;

            if (firstSubArray == null)
                return false;

            if (secondSubArray == null)
                return true;

            return GetMin(firstSubArray) > GetMin(secondSubArray);
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
    public class SortRowsByMinElementDescending : IComparator
    {
        public bool Compare(int[] firstSubArray, int[] secondSubArray)
        {
            if (firstSubArray == null && secondSubArray == null)
                return false;

            if (firstSubArray == null)
                return true;

            if (secondSubArray == null)
                return false;

            return GetMin(firstSubArray) < GetMin(secondSubArray);
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
            IComparator comparator)
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
                    if (comparator.Compare(inJuggedArray[j], inJuggedArray[j + 1]))
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
        public static void BubbleSortJuggedArray(int[][] inJuggedArray, IComparator comparator)
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
