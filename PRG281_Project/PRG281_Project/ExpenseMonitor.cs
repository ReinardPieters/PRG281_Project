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

        public void CheckExpensesExceedingThreshold(double totalIncome, double totalExpenses)
        {
            double thirtyPercent = totalIncome * 0.30;
            double fortyPercent = totalIncome * 0.40;
            double fiftyPercent = totalIncome * 0.50;

            if (totalExpenses > thirtyPercent)
            {
                ExpenseExceeded?.Invoke("Warning: Your expenses have exceeded 50% of your income!");
            }
            else if (totalExpenses > fortyPercent)
            {
                ExpenseExceeded?.Invoke("Warning: Your expenses have exceeded 40% of your income!");
            }
            else if (totalExpenses > fiftyPercent)
            {
                ExpenseExceeded?.Invoke("Warning: Your expenses have exceeded 30% of your income!");
            }
            else if(totalExpenses >= totalIncome)
            {
                ExpenseExceeded?.Invoke("Warning: Your expenses have exceeded 30% of your income!");
            }
        }
    }
}