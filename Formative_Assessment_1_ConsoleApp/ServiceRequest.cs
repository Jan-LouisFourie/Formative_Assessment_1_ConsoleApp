using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formative_Assessment_1_ConsoleApp
{
    public class ServiceRequest
    {
        public string RequestType { get; set; }
        public int PriorityLevel { get; set; } // 1 to 5
        public int SeverityLevel { get; set; } // 1 to 10
        public double EstimatedHours { get; set; }
        public Resident AssociatedResident { get; set; }
        public double UrgencyScore { get; set; }

        public ServiceRequest(string type, int priority, int severity, double hours, Resident resident)
        {
            RequestType = type;
            PriorityLevel = priority;
            SeverityLevel = severity;
            EstimatedHours = hours;
            AssociatedResident = resident;
        }
    }
}
