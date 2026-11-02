using System;
using System.Collections.Generic;

namespace CalculatorApp
{
    class Calculator
    {
        static void Main(string[] args)
        {
            bool exitProgram = false;

            // ==========================================================
            // OUTER LOOP: while loop - keeps the program running
            // ==========================================================
            while (!exitProgram)
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("       KIWOTOKWA WELCOMES YOU TO C# CALCULATOR             ");
                Console.WriteLine("==============================================");
                Console.WriteLine(" 1. Basic Arithmetic (+, -, *, /)");
                Console.WriteLine(" 2. Power Calculation (x^y)");
                Console.WriteLine(" 3. Factorial (for loop)");
                Console.WriteLine(" 4. Multiplication Table (nested loop)");
                Console.WriteLine(" 5. Sum of Numbers 1 to N (foreach loop)");
                Console.WriteLine(" 6. Fibonacci Series (do-while loop)");
                Console.WriteLine(" 7. Exit");
                Console.WriteLine("==============================================");
                Console.Write(" Enter your choice (1-7): ");

                int choice;
                bool validChoice = int.TryParse(Console.ReadLine(), out choice);

                if (!validChoice)
                {
                    Console.WriteLine(" Invalid input! Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        BasicArithmetic();
                        break;
                    case 2:
                        PowerCalculation();
                        break;
                    case 3:
                        FactorialUsingForLoop();
                        break;
                    case 4:
                        MultiplicationTableUsingNestedLoops();
                        break;
                    case 5:
                        SumUsingForeachLoop();
                        break;
                    case 6:
                        FibonacciUsingDoWhileLoop();
                        break;
                    case 7:
                        exitProgram = true;
                        Console.WriteLine("\n Thank you for using the calculator. Goodbye!");
                        break;
                    default:
                        Console.WriteLine(" Invalid choice! Please select 1-7.");
                        break;
                }

                if (!exitProgram)
                {
                    Console.WriteLine("\n Press any key to return to the main menu...");
                    Console.ReadKey();
                }
            }
        }

        // ==========================================================
        // METHOD 1: Basic Arithmetic
        // Uses a while loop for continuous calculation
        // ==========================================================
        static void BasicArithmetic()
        {
            Console.Clear();
            Console.WriteLine("=== BASIC ARITHMETIC ===");

            bool keepCalculating = true;

            // while loop - repeats calculations until user exits
            while (keepCalculating)
            {
                Console.Write("Enter first number: ");
                double num1;
                while (!double.TryParse(Console.ReadLine(), out num1))
                {
                    Console.Write("Invalid! Enter a valid number: ");
                }

                Console.Write("Enter operator (+, -, *, /): ");
                string op = Console.ReadLine();

                Console.Write("Enter second number: ");
                double num2;
                while (!double.TryParse(Console.ReadLine(), out num2))
                {
                    Console.Write("Invalid! Enter a valid number: ");
                }

                double result = 0;
                bool validOperation = true;

                switch (op)
                {
                    case "+": result = num1 + num2; break;
                    case "-": result = num1 - num2; break;
                    case "*": result = num1 * num2; break;
                    case "/":
                        if (num2 == 0)
                        {
                            Console.WriteLine("Error: Division by zero!");
                            validOperation = false;
                        }
                        else result = num1 / num2;
                        break;
                    default:
                        Console.WriteLine("Invalid operator!");
                        validOperation = false;
                        break;
                }

                if (validOperation)
                    Console.WriteLine($"Result: {num1} {op} {num2} = {result}");

                Console.Write("\nDo another calculation? (y/n): ");
                string answer = Console.ReadLine().ToLower();
                if (answer != "y") keepCalculating = false;
            }
        }

        // ==========================================================
        // METHOD 2: Power Calculation
        // Uses a for loop to multiply the base 'exponent' times
        // ==========================================================
        static void PowerCalculation()
        {
            Console.Clear();
            Console.WriteLine("=== POWER CALCULATION (x^y) ===");

            Console.Write("Enter base (x): ");
            double baseNum = double.Parse(Console.ReadLine());

            Console.Write("Enter exponent (y, whole number): ");
            int exponent = int.Parse(Console.ReadLine());

            double result = 1;
            int absExponent = Math.Abs(exponent);

            // for loop - multiply base by itself 'absExponent' times
            for (int i = 0; i < absExponent; i++)
            {
                result *= baseNum;
            }

            // Handle negative exponent
            if (exponent < 0)
                result = 1 / result;

            Console.WriteLine($"Result: {baseNum}^{exponent} = {result}");
        }

        // ==========================================================
        // METHOD 3: Factorial
        // Uses a for loop to calculate n!
        // ==========================================================
        static void FactorialUsingForLoop()
        {
            Console.Clear();
            Console.WriteLine("=== FACTORIAL (n!) ===");

            Console.Write("Enter a positive integer: ");
            int n = int.Parse(Console.ReadLine());

            if (n < 0)
            {
                Console.WriteLine("Factorial is not defined for negative numbers.");
                return;
            }

            long factorial = 1;

            // for loop - multiply from 1 to n
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            Console.WriteLine($"{n}! = {factorial}");
        }

        // ==========================================================
        // METHOD 4: Multiplication Table
        // Uses NESTED loops (for inside for)
        // ==========================================================
        static void MultiplicationTableUsingNestedLoops()
        {
            Console.Clear();
            Console.WriteLine("=== MULTIPLICATION TABLE ===");

            Console.Write("Enter table size (e.g., 5 for 5x5 table): ");
            int size = int.Parse(Console.ReadLine());

            // Outer for loop
            for (int i = 1; i <= size; i++)
            {
                // Inner for loop
                for (int j = 1; j <= size; j++)
                {
                    Console.Write($"{i * j,4}");
                }
                Console.WriteLine();
            }
        }

        // ==========================================================
        // METHOD 5: Sum of numbers 1 to N
        // Uses a foreach loop over a List<int>
        // ==========================================================
        static void SumUsingForeachLoop()
        {
            Console.Clear();
            Console.WriteLine("=== SUM OF NUMBERS 1 TO N ===");

            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());

            // Build a list of numbers
            List<int> numbers = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                numbers.Add(i);
            }

            int sum = 0;

            // foreach loop - iterate through the list
            foreach (int number in numbers)
            {
                sum += number;
            }

            Console.WriteLine($"Sum of numbers from 1 to {n} = {sum}");
            Console.WriteLine($"Total numbers in the list: {numbers.Count}");
        }

        // ==========================================================
        // METHOD 6: Fibonacci Series
        // Uses a do-while loop
        // ==========================================================
        static void FibonacciUsingDoWhileLoop()
        {
            Console.Clear();
            Console.WriteLine("=== FIBONACCI SERIES ===");

            Console.Write("How many terms? ");
            int terms = int.Parse(Console.ReadLine());

            if (terms <= 0)
            {
                Console.WriteLine("Please enter a positive number.");
                return;
            }

            int a = 0, b = 1, count = 0;

            Console.Write("Fibonacci Series: ");

            // do-while loop - runs at least once
            do
            {
                Console.Write($"{a} ");
                int next = a + b;
                a = b;
                b = next;
                count++;
            } while (count < terms);

            Console.WriteLine();
        }
    }
}