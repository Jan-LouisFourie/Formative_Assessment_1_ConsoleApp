using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formative_Assessment_1_ConsoleApp
{
    public class Resident
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string AccountNumber { get; set; }
        public double MonthlyUsage { get; set; }

        public Resident(string name, string address, string accNum, double usage)
        {
            Name = name;
            Address = address;
            AccountNumber = accNum;
            MonthlyUsage = usage;
        }
    }
}
