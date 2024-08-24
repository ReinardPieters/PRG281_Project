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
        public void CheckExpenses(double totalIncome, double totalExpenses)
        {
            if (totalExpenses > totalIncome)
            {
                ExpenseExceeded?.Invoke("Warning: Your expenses have exceeded your income!");
            }
        }
        public void CheckExpenseVsSavings(double expenseAmount, double totalSavings)
        {
            if (expenseAmount > totalSavings)
            {
                ExpenseExceeded?.Invoke($"Warning: The expense of {expenseAmount:C} exceeds your savings!");
            }
        }
    }
}
