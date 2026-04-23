using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formative_Assessment_1_ConsoleApp
{
    public class UtilitiesManager
    {
        public double CalculateUrgency(int priority, int severity) => (priority * severity) * 2;

        public double CalculateAdjustedResolution(double estHours, int priority) => estHours + priority;

        public double CalculateImpactScore(double usage, int severity) => usage * (severity / 10.0);

        public void GenerateReport(ServiceRequest req)
        {
            double urgency = CalculateUrgency(req.PriorityLevel, req.SeverityLevel);
            double adjRes = CalculateAdjustedResolution(req.EstimatedHours, req.PriorityLevel);
            double impact = CalculateImpactScore(req.AssociatedResident.MonthlyUsage, req.SeverityLevel);

            Console.WriteLine($"""
            ==== Service Report ====
            Resident: {req.AssociatedResident.Name}
            Service Type: {req.RequestType}
            Urgency Score: {urgency}
            Adjusted Resolution: {adjRes} hours
            Household Impact Score: {impact:N2}
            """);
        }
    }
}
