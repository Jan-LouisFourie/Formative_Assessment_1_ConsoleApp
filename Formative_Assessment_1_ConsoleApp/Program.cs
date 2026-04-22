using System;

namespace StudentResultApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            double[] marks = new double[3];
            double markTotal = 0;

            Console.Write("""

                =====================
                STUDENT GRADING APP
                =====================
                
                """);

            Console.Write("\nEnter Student Name: ");
            string studentName = Console.ReadLine();

            for (int i = 0; i < 3; i++)
            {
                bool isValid = false;
                while (!isValid)
                {
                    Console.Write($"Enter Mark for Subject {i + 1}: ");
                    string input = Console.ReadLine();

                    if (double.TryParse(input, out marks[i]))
                    {
                        markTotal += marks[i];
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Please enter a numeric value.");
                    }
                }
            }

            double average = markTotal / 3;
            string result = (average >= 50) ? "PASS" : "FAIL";

            Console.WriteLine("\n");
            Console.WriteLine($"""
                =====================
                       Results
                =====================

                Student Name    : {studentName}
                Total Marks     : {markTotal}
                Average Mark    : {average:f2}%
                Result          : {result}
                Result issued at: {DateTime.Now:f}
                """);
        }
    }
}