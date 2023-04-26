/*
 * 2.	Write a program, which creates a chain of four Tasks.
 * First Task – creates an array of 10 random integer.
 * Second Task – multiplies this array with another random integer.
 * Third Task – sorts this array by ascending.
 * Fourth Task – calculates the average value. All this tasks should print the values to console.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiThreading.Task2.Chaining
{
    class Program
    {
        private static Random _rnd = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine(".Net Mentoring Program. MultiThreading V1 ");
            Console.WriteLine("2.	Write a program, which creates a chain of four Tasks.");
            Console.WriteLine("First Task – creates an array of 10 random integer.");
            Console.WriteLine("Second Task – multiplies this array with another random integer.");
            Console.WriteLine("Third Task – sorts this array by ascending.");
            Console.WriteLine("Fourth Task – calculates the average value. All this tasks should print the values to console");
            Console.WriteLine();

            // feel free to add your code
            var result = Task.Factory.StartNew(() => GenerateArray())
                .ContinueWith(taskMultiply => MultiplyArray(taskMultiply.Result), TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith(sortArray => SortArray(sortArray.Result), TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith(average => CalculateAverageValue(average.Result), TaskContinuationOptions.OnlyOnRanToCompletion).Result;
        }

        public static double CalculateAverageValue(int[] array)
        {
            var averageValue = array.Average();
            Console.WriteLine($"\nAverage value -> {averageValue}");

            return averageValue;
        }

        public static int[] MultiplyArray(int[] array) => array.Select(numb => numb * _rnd.Next(1, 10)).ToArray();

        public static int[] SortArray(int[] array)
        {
            Array.Sort(array);
            Console.WriteLine("\n");
            foreach (int value in array)
            {
                Console.WriteLine($"Sorted array value -> {value}");
            }
            return array;
        }

        public static int[] GenerateArray()
        {
            var array = Enumerable
              .Repeat(0, 10)
              .Select(i => _rnd.Next(0, 10))
              .ToArray();
            foreach (int value in array)
            {
                Console.WriteLine($"Generated array value -> {value}");
            }

            return array;
        }
    }
}
