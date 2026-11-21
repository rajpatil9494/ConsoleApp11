using System;
using System.Collections.Generic;

namespace ArmstrongApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=== Armstrong Number Program ===");
                Console.WriteLine("1. Check if a number is an Armstrong number");
                Console.WriteLine("2. List all Armstrong numbers up to N");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    //case "1":
                    //    CheckArmstrong();
                    //    break;
                    case "2":
                        ListArmstrong();
                        break;
                    case "3":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please enter 1, 2, or 3.");
                        break;
                }
            }
        }

        //static void CheckArmstrong()
        //{
        //    Console.Write("Enter a non-negative whole number: ");
        //    if (!long.TryParse(Console.ReadLine(), out long n) || n < 0)
        //    {
        //        Console.WriteLine("That's not a valid non-negative whole number.");
        //        return;
        //    }

        //    Console.WriteLine(IsArmstrong(n)
        //        ? $"{n} is an Armstrong number."
        //        : $"{n} is not an Armstrong number.");
        //}

        static void ListArmstrong()
        {
            Console.Write("Enter the upper limit (N): ");
            if (!int.TryParse(Console.ReadLine(), out int limit) || limit < 0)
            {
                Console.WriteLine("Please enter a non-negative whole number.");
                return;
            }

            List<int> found = new List<int>();
            for (int i = 0; i <= limit; i++)
            {
                if (IsArmstrong(i)) found.Add(i);
            }

            Console.WriteLine($"\nThere are {found.Count} Armstrong numbers up to {limit}:");
            Console.WriteLine(string.Join(", ", found));
        }

        // A number is an Armstrong number if the sum of its digits, each raised
        // to the power of the digit count, equals the number itself.
        // Example: 153 = 1^3 + 5^3 + 3^3
        static bool IsArmstrong(long n)
        {
            if (n < 0) return false;

            int digitCount = n.ToString().Length;
            long sum = 0;
            long temp = n;

            while (temp > 0)
            {
                int digit = (int)(temp % 10);
                sum += IntPow(digit, digitCount);
                temp /= 10;
            }

            return sum == n;
        }

        // Integer power; avoids floating-point errors from Math.Pow.
        static long IntPow(int baseNum, int exponent)
        {
            long result = 1;
            for (int i = 0; i < exponent; i++)
            {
                result *= baseNum;
            }
            return result;
        }
    }
}
