using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG281_Project
{
    abstract class FinancialEntity
    {
        private string name { get; set; }
        private double amount { get; set; }
        protected FinancialEntity(string name, double amount)
        {
            this.name = name;
            this.amount = amount;
        }


        public abstract void Display();
        

      
    }
}
