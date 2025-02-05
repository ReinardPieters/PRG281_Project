﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PRG281_Project
{
    internal class Income:FinancialEntity, iFinancialOperation
    {
        public Income(string name, double amount) : base(name, amount) { }

        public void Execute()
        {
            Console.WriteLine($"{Name} added to income: {Amount:C}");

        }

        public override void Display()
        {
            Console.WriteLine($"Income: {Name} - Amount: {Amount:C}");

        }
    }
}