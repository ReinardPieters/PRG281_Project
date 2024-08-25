﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PRG281_Project
{
    internal class Expense: FinancialEntity, iFinancialOperation
    {

        public Expense(string name, double amount) : base(name, amount) { }

        public void Execute()
        {
           
        }

        protected virtual void OnOverspendingAlert(EventArgs e)
        {
        }

        public override void Display()
        {
        }
    

}
}
