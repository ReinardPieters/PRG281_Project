﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG281_Project
{
    internal class FinanceManager
    {
        private double totalIncome;
        private double totalExpenses;
        private double totalSavings;
        private readonly List<FinancialEntity> transactions;
        public FinanceManager()
        {
            transactions = new List<FinancialEntity>();
        }

        public void AddTransaction(FinancialEntity entity)
        {
          //exception for invalid entry


           transactions.Add(entity);

            if (entity is Income income)
            {
                totalIncome += income.Amount; 
            }
            else if(entity is Expense expense)
            {
                totalExpenses += expense.Amount;
            }
            else if (entity is Savings save)
            {
                totalSavings += save.Amount;
            }
            entity.Display();
        }

        public void MonitorExpenses()
        {
           foreach(var item in transactions)
            {
                if (item is Expense expense)
                {
                    //trigger spending altert
                }
            }
        }

       

        public void DisplaySummary()
        {
            Console.WriteLine("Your MoneyMentor summary:");
            Console.WriteLine($"Total Income: {totalIncome:C}");
            Console.WriteLine($"Total Expenses: {totalExpenses:C}");
            Console.WriteLine($"Total Savings: {totalSavings:C}");
            Console.WriteLine($"Balance: {(totalIncome - totalExpenses - totalSavings):C}");
        }
    }
}

