using static ArraySortInt.Sort;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NET1.S._2018.Petrovich._06
{
    public static class SortJuggedArray
    {
        /// <summary>
        /// Sorting jugged array.
        /// Operation modes:
        /// "InsideEachRow" - sorts element in each row;
        /// "RowsBySum"     - sorts rows of array according sum of elements each row;
        /// "RowsByMax"     - sorts rows of array according max element each row;
        /// "RowsByMin"     - sorts rows of array according min element each row.
        /// Ascending - order of sorting:
        /// true  - ascending;
        /// false - descending.
        /// </summary>
        /// <param name="inJuggedArray">
        /// Array for sorting.
        /// </param>
        /// <param name="mode">
        /// Selecting operation mode:
        /// "InsideEachRow" - sorts element in each row;
        /// "RowsBySum"     - sorts rows of array according sum of elements each row;
        /// "RowsByMax"     - sorts rows of array according max element each row;
        /// "RowsByMin"     - sorts rows of array according min element each row.
        /// </param>
        /// <param name="ascending">
        /// Selecting order of sorting:
        /// true  - ascending;
        /// false - descending.
        /// (ascending as default)
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throw if reference of jugged array or mode is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws if mode is incorrect.
        /// </exception>
        public static void SortJugged(int[][] inJuggedArray, string mode, bool ascending = true)
            => SortJugged(inJuggedArray, 0, inJuggedArray.Length - 1, mode, ascending);
        //{
        //    if (inJuggedArray == null)
        //    {
        //        throw new ArgumentNullException(nameof(inJuggedArray));
        //    }

        //    for (int i = 0; i < inJuggedArray.Length; i++)
        //    {
        //        if (inJuggedArray[i] == null)
        //            throw new ArgumentNullException($"{nameof(inJuggedArray)} contain null reference at {i} row.");
        //    }

        //    if (mode == null)
        //        throw new ArgumentNullException(nameof(mode));

        //    switch (mode)
        //    {
        //        case "InsideEachRow":
        //            if (ascending)
        //            {
        //                SortInsideEachRow(inJuggedArray);
        //            }
        //            else
        //            {
        //                SortInsideEachRowDescending(inJuggedArray);
        //            }
        //            break;

        //        case "RowsBySum":
        //            SortRowsBySum(inJuggedArray, 0, inJuggedArray.Length - 1);
        //            break;

        //        case "RowsByMax":
        //            SortRowsByMax(inJuggedArray, 0, inJuggedArray.Length - 1);
        //            break;

        //        case "RowsByMin":
        //            SortRowsByMin(inJuggedArray, 0, inJuggedArray.Length - 1);
        //            break;

        //        default:
        //            throw new ArgumentException("Incorrect mode!");    
        //    }

        //    if (!ascending && mode != "InsideEachRow")
        //    {
        //        ReverseJuggedArray(inJuggedArray, 0, inJuggedArray.Length - 1);
        //    }
        //}

        /// <summary>
        /// Sorting jugged array.
        /// Operation modes:
        /// "InsideEachRow" - sorts element in each row;
        /// "RowsBySum"     - sorts rows of array according sum of elements each row;
        /// "RowsByMax"     - sorts rows of array according max element each row;
        /// "RowsByMin"     - sorts rows of array according min element each row.
        /// Ascending - order of sorting:
        /// true  - ascending;
        /// false - descending.
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
        /// <param name="mode">
        /// Selecting operation mode:
        /// "InsideEachRow" - sorts element in each row;
        /// "RowsBySum"     - sorts rows of array according sum of elements each row;
        /// "RowsByMax"     - sorts rows of array according max element each row;
        /// "RowsByMin"     - sorts rows of array according min element each row.
        /// </param>
        /// <param name="ascending">
        /// Selecting order of sorting:
        /// true  - ascending;
        /// false - descending.
        /// (ascending as default)</param>
        /// <exception cref="ArgumentNullException">
        /// Throw if reference of jugged array or mode is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws if mode is incorrect or high index less than low index.
        /// </exception>
        public static void SortJugged(int[][] inJuggedArray, int lowIndex, int highIndex, string mode, bool ascending = true)
        {
            if (inJuggedArray == null)
                throw new ArgumentNullException(nameof(inJuggedArray));

            for (int i = 0; i < inJuggedArray.Length; i++)
            {
                if (inJuggedArray[i] == null)
                    throw new ArgumentNullException($"{nameof(inJuggedArray)} contain null reference at {i} row.");
            }

            if (mode == null)
                throw new ArgumentNullException(nameof(mode));

            if (lowIndex >= highIndex)
                throw new ArgumentException($"{nameof(highIndex)} must be greater than {nameof(lowIndex)}!");

            if (lowIndex < 0 || lowIndex >= inJuggedArray.Length)
                throw new ArgumentException($"{nameof(lowIndex)} out of range.");

            if (highIndex < 0 || highIndex >= inJuggedArray.Length)
                throw new ArgumentException($"{nameof(lowIndex)} out of range.");

            switch (mode)
            {
                case "InsideEachRow":
                    if (ascending)
                    {
                        SortInsideEachRow(inJuggedArray, lowIndex, highIndex);
                    }
                    else
                    {
                        SortInsideEachRowDescending(inJuggedArray, lowIndex, highIndex);
                    }
                    break;

                case "RowsBySum":
                    SortRowsBySum(inJuggedArray, lowIndex, highIndex);
                    break;

                case "RowsByMax":
                    SortRowsByMax(inJuggedArray, lowIndex, highIndex);
                    break;

                case "RowsByMin":
                    SortRowsByMin(inJuggedArray, lowIndex, highIndex);
                    break;

                default:
                    throw new ArgumentException("Incorrect mode!");
            }

            if (!ascending && mode != "InsideEachRow")
            {
                ReverseJuggedArray(inJuggedArray, lowIndex, highIndex);
            }
        }

        private static void SortInsideEachRow(int[][] inJuggedArray, int lowIndex, int highIndex)
        {
            for (int i = lowIndex; i <= highIndex; i++)
            {
                MergeSort(inJuggedArray[i]);
            }
        }

        private static void SortInsideEachRowDescending(int[][] inJuggedArray, int lowIndex, int highIndex)
        {
            for (int i = lowIndex; i <= highIndex; i++)
            {
                MergeSort(inJuggedArray[i]);
                Reverse(inJuggedArray[i]);
            }
        }

        private static void SortRowsBySum(int[][] inJuggedArray, int lowIndex, int highIndex)
        {
            SortedDictionary<int, int[][]> sortedDictionary = new SortedDictionary<int, int[][]>();
            Dictionary<int, int> numArrays = new Dictionary<int, int>();
            for (int i = lowIndex; i <= highIndex ; i++)
            {
                int key = inJuggedArray[i].GetSum();

                if (numArrays.ContainsKey(key))
                {
                    int[][] temp = new int[numArrays[key] + 1][];
                    for (int j = 0; j < numArrays[key]; j++)
                    {
                        temp[j] = sortedDictionary[key][j];
                    }

                    temp[numArrays[key]++] = inJuggedArray[i];
                    sortedDictionary[key] = temp;
                }
                else
                {
                    numArrays.Add(key, 0);

                    int[][] temp = new int[1][];
                    temp[numArrays[key]++] = inJuggedArray[i];
                    sortedDictionary[key] = temp;
                }
            }

            int count = lowIndex;
            foreach (var sortedDictionaryKey in sortedDictionary.Keys)
            {
                for (int j = 0; j < numArrays[sortedDictionaryKey]; j++)
                {
                    inJuggedArray[count++] = sortedDictionary[sortedDictionaryKey][j];
                }
            }            
        }
        
        private static void SortRowsByMax(int[][] inJuggedArray, int lowIndex, int highIndex)
        {
            SortedDictionary<int, int[][]> sortedDictionary = new SortedDictionary<int, int[][]>();
            Dictionary<int, int> numArrays = new Dictionary<int, int>();
            for (int i = lowIndex; i <= highIndex; i++)
            {
                int key = inJuggedArray[i].GetMax();

                if (numArrays.ContainsKey(key))
                {
                    int[][] temp = new int[numArrays[key] + 1][];
                    for (int j = 0; j < numArrays[key]; j++)
                    {
                        temp[j] = sortedDictionary[key][j];
                    }

                    temp[numArrays[key]++] = inJuggedArray[i];
                    sortedDictionary[key] = temp;
                }
                else
                {
                    numArrays.Add(key, 0);

                    int[][] temp = new int[1][];
                    temp[numArrays[key]++] = inJuggedArray[i];
                    sortedDictionary[key] = temp;
                }
            }

            int count = lowIndex;
            foreach (var sortedDictionaryKey in sortedDictionary.Keys)
            {
                for (int j = 0; j < numArrays[sortedDictionaryKey]; j++)
                {
                    inJuggedArray[count++] = sortedDictionary[sortedDictionaryKey][j];
                }
            }
        }

        private static void SortRowsByMin(int[][] inJuggedArray, int lowIndex, int highIndex)
        {
            SortedDictionary<int, int[][]> sortedDictionary = new SortedDictionary<int, int[][]>();
            Dictionary<int, int> numArrays = new Dictionary<int, int>();
            for (int i = lowIndex; i <= highIndex; i++)
            {
                int key = inJuggedArray[i].GetMin();

                if (numArrays.ContainsKey(key))
                {
                    int[][] temp = new int[numArrays[key] + 1][];
                    for (int j = 0; j < numArrays[key]; j++)
                    {
                        temp[j] = sortedDictionary[key][j];
                    }

                    temp[numArrays[key]++] = inJuggedArray[i];
                    sortedDictionary[key] = temp;
                }
                else
                {
                    numArrays.Add(key, 0);

                    int[][] temp = new int[1][];
                    temp[numArrays[key]++] = inJuggedArray[i];
                    sortedDictionary[key] = temp;
                }
            }

            int count = lowIndex;
            foreach (var sortedDictionaryKey in sortedDictionary.Keys)
            {
                for (int j = 0; j < numArrays[sortedDictionaryKey]; j++)
                {
                    inJuggedArray[count++] = sortedDictionary[sortedDictionaryKey][j];
                }
            }
        }

        private static int GetSum(this int[] array)
        {
            int sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }

        private static int GetMax(this int[] array)
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

        private static int GetMin(this int[] array)
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

        private static void SwapValue(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        private static void SwapReference(ref int[] refA, ref int[] refB)
        {
            int[] temp = refA;
            refA = refB;
            refB = temp;
        }

        private static void Reverse(int[] array, int lowIndex, int highIndex)
        {
            while (lowIndex < highIndex)
            {
                SwapValue(ref array[lowIndex++], ref array[highIndex--]);
            }
        }

        private static void Reverse(int[] array)
            => Reverse(array, 0, array.Length - 1);

        private static void ReverseJuggedArray(int[][] juggedArray, int lowIndex, int highIndex)
        {
            while(lowIndex < highIndex)
            {
                SwapReference(ref juggedArray[lowIndex++], ref juggedArray[highIndex--]);
            }
        }
    }
}
