﻿using System;
using System.Collections;
using System.Runtime.ExceptionServices;
using System.Runtime.Serialization.Json;

namespace GenericDelegate
{
    delegate int Compare<T>(T a, T b);
    class Program
    {
        static int AscendCompare<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b);
        }
        static int DescendCompare<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) * -1;
        }
        static void BubbleSort<T>(T[] DataSet, Compare<T> Comparer)
        {
            int i = 0;
            int j = 0;
            T temp;

            for (i = 0; i < DataSet.Length - 1; i++)
            {
                for(j=0; j< DataSet.Length - (i + 1); j++)
                {
                    if (Comparer(DataSet[j], DataSet[j + 1]) > 0)
                    {
                        temp = DataSet[j + 1];
                        DataSet[j + 1] = DataSet[j];
                        DataSet[j] = temp;
                    }
                }
            }

        }
        static void Main(string[] args)
        {
            int[] array = { 3, 2, 6, 8, 4, 20 };
            Console.WriteLine("Sorting Ascending");
            BubbleSort<int>(array, new Compare<int>(AscendCompare));

            for (int i = 0; i < array.Length;i++)
                Console.WriteLine($"{array[i]}");

            string[] array2 = { "abc", "mhe", "rew", "tbr", "btr", "kurt", "fdw" };

            Console.WriteLine("Sorting Descending..");
            BubbleSort<string>(array2, new Compare<string>(DescendCompare));

            for (int i = 0; i < array2.Length; i++)
                Console.WriteLine($"{array2[i]}");
        }
    }
}
