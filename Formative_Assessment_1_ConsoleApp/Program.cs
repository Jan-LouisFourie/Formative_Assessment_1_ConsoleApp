using Formative_Assessment_1_ConsoleApp;
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

            UtilitiesManager manager = new UtilitiesManager();
            List<Resident> residentsList = new List<Resident>();
            List<ServiceRequest> allRequests = new List<ServiceRequest>();

            Console.WriteLine("=== Welcome to Emfuleni Municipality Service Desk ===");

            Console.Write("How many residents do you want to register? ");
            if (int.TryParse(Console.ReadLine(), out int resCount))
            {
                for (int i = 0; i < resCount; i++)
                {
                    Console.WriteLine($"\n--- Resident {i + 1} ---");
                    Console.Write("Name: "); string name = Console.ReadLine();
                    Console.Write("Address: "); string addr = Console.ReadLine();
                    Console.Write("Account Number: "); string acc = Console.ReadLine();
                    Console.Write("Monthly Utility Usage (kWh or litres): ");
                    double usage = double.Parse(Console.ReadLine());

                    residentsList.Add(new Resident(name, addr, acc, usage));
                }
            }

            Console.Write("\nHow many service requests do you want to log? ");
            if (int.TryParse(Console.ReadLine(), out int reqCount))
            {
                for (int i = 0; i < reqCount; i++)
                {
                    Console.WriteLine($"\n--- Service Request {i + 1} ---");

                    Console.Write($"Select resident by number (1 to {residentsList.Count}): ");
                    int resIdx = int.Parse(Console.ReadLine()) - 1;

                    Console.Write("Request Type (e.g., Water Outage, Burst Pipe): "); string type = Console.ReadLine();
                    Console.Write("Priority Level (1-5): "); int prio = int.Parse(Console.ReadLine());
                    Console.Write("Severity Level (1-10): "); int sev = int.Parse(Console.ReadLine());
                    Console.Write("Estimated Resolution Hours: "); double hours = double.Parse(Console.ReadLine());

                    ServiceRequest newReq = new ServiceRequest(type, prio, sev, hours, residentsList[resIdx]);
                    allRequests.Add(newReq);

                    Console.WriteLine();
                    manager.GenerateReport(newReq);
                }
            }

            if (allRequests.Count > 0)
            {
                var highest = allRequests.OrderByDescending(r => manager.CalculateUrgency(r.PriorityLevel, r.SeverityLevel)).First();

                double hUrgency = manager.CalculateUrgency(highest.PriorityLevel, highest.SeverityLevel);
                double hAdj = manager.CalculateAdjustedResolution(highest.EstimatedHours, highest.PriorityLevel);
                double hImpact = manager.CalculateImpactScore(highest.AssociatedResident.MonthlyUsage, highest.SeverityLevel);

                Console.WriteLine($"""

                    ==== FINAL MUNICIPAL SUMMARY ====
                    Highest priority issue:
                    Resident: {highest.AssociatedResident.Name}
                    Service Type: {highest.RequestType}
                    Urgency Score: {hUrgency}
                    Adjusted Resolution: {hAdj} hours
                    Household Impact Score: {hImpact:N2}

                    Thank you for using the Emfuleni Municipality Service Desk.
                    """);
            }

            Console.WriteLine("\nPress any key to close...");
            Console.ReadKey();
        }
    }
}