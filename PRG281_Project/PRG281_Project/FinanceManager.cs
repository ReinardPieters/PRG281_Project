using System;
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
        private readonly UserManager userManager;
        private ExpenseMonitor expenseMonitor;
        private readonly object lockObj = new object();
        public FinanceManager(UserManager userManager)
        {
            this.userManager = userManager;
            transactions = new List<FinancialEntity>();
            expenseMonitor = new ExpenseMonitor();
            expenseMonitor.ExpenseExceeded += message => 
            {
                Console.WriteLine(message);
            };
        }

        public void AddTransaction(FinancialEntity entity)
        {
            //exception for invalid entry
            ThreadPool.QueueUserWorkItem(state =>
            {
                lock (lockObj) 
                {
                    if (entity.Amount < 0)
                    {
                        throw new ArgumentException("Transaction amount cannot be negative.");
                    }
                    transactions.Add(entity);

                    if (entity is Income income)
                    {
                        totalIncome += income.Amount;
                        userManager.UpdateIncome(income.Amount);

                    }
                    else if (entity is Expense expense)
                    {
                        double remainingIncome = userManager.GetCurrentUser().TotalIncome - userManager.GetCurrentUser().TotalExpenses;

                        if (expense.Amount <= remainingIncome)
                        {
                            totalExpenses += expense.Amount;
                            userManager.UpdateExpenses(expense.Amount);
                        }
                        else
                        {
                            Console.WriteLine("Expense not added because it exceeds your income or savings.");
                        }
                    }
                    else if (entity is Savings save)
                    {
                        totalSavings += save.Amount;
                        userManager.SetSavingsGoal(save.Amount);
                    }
                    entity.Display();
                }
            });
        }

        public void DisplaySummary()
        { 
            Console.WriteLine($"Total Income: {totalIncome:C}");
            Console.WriteLine($"Total Expenses: {totalExpenses:C}");
            Console.WriteLine($"Total Savings: {totalSavings:C}");
            Console.WriteLine($"Balance: {(totalIncome - totalExpenses - totalSavings):C}");
        }
        private void HandleExpensesExceeded(string message)
        {
            Console.WriteLine(message);
        }
    }
}

