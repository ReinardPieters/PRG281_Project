using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PRG281_Project
{
    internal class Savings : FinancialEntity, iFinancialOperation
    {
        public Savings(string name, double amount) : base(name, amount) { }

        public void Execute()
        {
            Console.WriteLine($"{Name} has added to savings: {Amount}");
        }

        public override void Display()
        {
            Console.WriteLine($"Savings goal: {Name} and amount{Amount}");
        }
    
    }
}
