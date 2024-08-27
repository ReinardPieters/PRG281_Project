using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG281_Project
{
    internal class ExpenseMonitor
    {
        public event Action<string> ExpenseExceeded;

        public bool CheckExpenses(double totalIncome, double expenseAmount)
        {
            if (expenseAmount > totalIncome)
            {
                ExpenseExceeded?.Invoke("Warning: Your expenses have exceeded your income!");
                return false; // Expense exceeds income
            }
            return true; // Expense is within income
        }
        public void CheckExpensesExceedingThreshold(double totalIncome, double totalExpenses)
        {
            double threshold = totalIncome * 0.30; // 30% of income

            if (totalExpenses > threshold)
            {
                ExpenseExceeded?.Invoke($"Warning: Your expenses have exceeded 30% of your income!");
            }
        }
    }
}