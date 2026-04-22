using System;

namespace StudentResultApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("SECTION: A");
            // Question 1:

            Console.Write("Question 1:\n\n");

            double[] marks = new double[3];
            double markTotal = 0;

            Console.Write("""

                ====================================
                        STUDENT GRADING APP
                ====================================
                
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
                ====================================
                               Results
                ====================================

                Student Name    : {studentName}
                Total Marks     : {markTotal}
                Average Mark    : {average:f2}%
                Result          : {result}
                Result issued at: {DateTime.Now:f}
                """);



            // Question 2:

            Console.WriteLine("\n");
            Console.Write("Question 2:\n\n");

            Console.WriteLine("===== CTU SIMPLE ATM SYSTEM =====\n");

            Console.WriteLine("Hi, What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine($"\nWelcome {userName}");


            Console.Write("Enter account balance: ");
            double accountBalance;
            while (!double.TryParse(Console.ReadLine(), out accountBalance))
            {
                Console.WriteLine("Invalid input! Please enter a numeric value.");
            }

            Console.Write("\nEnter amount to withdraw: ");
            double withdrawalAmount;
            while (!double.TryParse(Console.ReadLine(), out withdrawalAmount))
            {
                Console.WriteLine("Invalid input! Please enter a numeric value.");
            }


            if (withdrawalAmount > accountBalance)
            {
                Console.WriteLine("\nInsufficient funds! Transaction failed.");
            }
            else
            {
                accountBalance -= withdrawalAmount;
                Console.WriteLine("\n");
                Console.WriteLine($"""
                    Withdrawal successful!
                    Updated balance: {accountBalance:C}
                    Transaction Time: {DateTime.Now:f}
                    """);
            }



            Console.WriteLine("SECTION :B");

            // Question 1:
             Console.Write("Question 1:\n\n");
        }
    }
}