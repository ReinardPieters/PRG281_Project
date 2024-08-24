using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG281_Project
{
    abstract class FinancialEntity
    {
        public string Name { get; }
        public double Amount { get; }
        protected FinancialEntity(string name, double amount)
        {
            this.Name = name;
            this.Amount = amount;
        }

        public abstract void Display();
        
              
    }
}
