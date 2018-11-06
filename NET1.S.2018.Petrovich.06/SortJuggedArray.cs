using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NET1.S._2018.Petrovich._06
{
    public interface IComparer
    {
        int Compare(int[] firstSubArray, int[] secondSubArray);
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
        /// Instance class containing comparison logic.
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
        /// Instance class containing comparison logic.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throw if reference of jugged array or comparator is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws if mode is incorrect or high index less than low index.
        /// </exception>
        public static void BubbleSortJuggedArray(int[][] inJuggedArray, IComparer comparator)
        {
            if (ReferenceEquals(inJuggedArray, null))
                throw new ArgumentNullException(nameof(inJuggedArray));

            BubbleSortJuggedArray(inJuggedArray, 0, inJuggedArray.Length - 1, comparator);
        }

        public delegate int DelegateComparator(int[] x, int[] y);

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
        /// Delegate-comparer containing comparison logic.
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
            DelegateComparator comparator)
        {
            if (ReferenceEquals(inJuggedArray, null))
                throw new ArgumentNullException(nameof(inJuggedArray));

            if (ReferenceEquals(comparator, null))
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
                    if (comparator.Invoke(inJuggedArray[j], inJuggedArray[j + 1]) > 0)
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
        /// Delegate-comparer containing comparison logic.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throw if reference of jugged array or comparator is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws if mode is incorrect or high index less than low index.
        /// </exception>
        public static void BubbleSortJuggedArray(int[][] inJuggedArray, DelegateComparator comparator)
        {
            if (ReferenceEquals(inJuggedArray, null))
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

    public static class SortJuggedArrayImplementationForTests
    {
        public delegate int DelegateComparator(int[] x, int[] y);

        /// <summary>
        /// Class-adapter for delegate.
        /// </summary>
        public class Adapter : IComparer
        {
            private readonly DelegateComparator comparator;

            public Adapter(DelegateComparator comparator)
            {
                this.comparator = comparator;
            }

            public int Compare(int[] a, int[] b)
            {
                return comparator.Invoke(a, b);
            }
        }

        /// <summary>
        /// Call version with class-comparer, invoke version with delegate.
        /// </summary>
        public static void BubbleSortJuggedArray(int[][] inJuggedArray, IComparer comparator)
            => SortJuggedArray.BubbleSortJuggedArray(inJuggedArray, comparator.Compare);

        /// <summary>
        /// Call version with class-comparer, invoke version with delegate.
        /// </summary>
        public static void BubbleSortJuggedArray(int[][] inJuggedArray, int lowIndex, int highIndex, IComparer comparator)
            => SortJuggedArray.BubbleSortJuggedArray(inJuggedArray, lowIndex, highIndex, comparator.Compare);

        /// <summary>
        /// Call version with delegate, invoke version with class-comparer.
        /// </summary>
        public static void BubbleSortJuggedArray(int[][] inJuggedArray, DelegateComparator comparator)
            => SortJuggedArray.BubbleSortJuggedArray(inJuggedArray, new Adapter(comparator));

        /// <summary>
        /// Call version with delegate, invoke version with class-comparer.
        /// </summary>
        public static void BubbleSortJuggedArray(int[][] inJuggedArray, int lowIndex, int highIndex, DelegateComparator comparator)
            => SortJuggedArray.BubbleSortJuggedArray(inJuggedArray, lowIndex, highIndex, new Adapter(comparator));
    }
}
