﻿using System;

namespace ExceptionFiltering
{
    class FilterableException : Exception
    {
        public int ErrorNo { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number between 0~10! : ");
            string input = Console.ReadLine();
            try
            {
                int num = Convert.ToInt32(input);
                if (num < 0 || num > 10)
                    throw new FilterableException() { ErrorNo = num };
                else
                    Console.WriteLine($"Output: {num} ");
            }
            catch(FilterableException e) when (e.ErrorNo < 0)
            {
                Console.WriteLine("Negative input is not allowed");
            }
            catch(FilterableException e) when (e.ErrorNo > 0)
            {
                Console.WriteLine("Too big number is not allowed");
            }
        }
    }
}