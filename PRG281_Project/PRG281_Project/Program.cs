using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Reflection;
using System.Xml;

namespace PRG281_Project
{
    public enum MenuOptions
    {
        [Description("Add Income")]
        AddIncome = 1,

        [Description("Add Expense")]
        AddExpense,

        [Description("Set Savings")]
        SetSavings,

        [Description("Display Summary")]
        DisplaySummary,

        [Description("Exit")]
        Exit
    }
    class Program
    {
        static void Main()
        {
            Console.Write("Welcome to the our Project for PR281");
            Console.WriteLine("");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("=");

                Thread.Sleep(333);
            }
            Console.Clear();
            bool running = false;


            string username, password;

            Console.WriteLine("Do you have an account? (Y/N)");
            string answer = Console.ReadLine();
            UserManager userManager = new UserManager();
            if (answer == "N")
            {
                Console.Clear();
                Console.WriteLine("Please enter your Username:");
                username = Console.ReadLine();
                Console.WriteLine("Please enter your Password");
                password = Console.ReadLine();
              
                userManager.SignUpUser(username, password);
            }
            else if (answer == "Y")
            {
                Console.Clear();
                Console.WriteLine("Please enter your Username:");
                username = Console.ReadLine();
                Console.WriteLine("Please enter your Password");
                password = Console.ReadLine();
          
                bool loginSuccess = userManager.LogIn(username, password);
                if (loginSuccess)
                {
                    
                    running = true;
                    Thread.Sleep(1000);
                    Console.Clear();
                    
                }
                else if(!loginSuccess)
                {
                    Console.WriteLine("Please check your username or password");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice");
                return;
            }

            FinanceManager manager = new FinanceManager();
            
            while (running)
            {
                Console.WriteLine("Menu:");
                foreach (MenuOptions option in Enum.GetValues(typeof(MenuOptions)))
                {
                    Console.WriteLine($"{(int)option}. {GetEnumDescription(option)}");
                }

                Console.Write("Select an option: ");
                try
                {
                    int selectedOption = int.Parse(Console.ReadLine());

                    if (Enum.IsDefined(typeof(MenuOptions), selectedOption))
                    {
                        MenuOptions choice = (MenuOptions)selectedOption;
                        switch (choice)
                        {
                            case MenuOptions.AddIncome:
                                Console.WriteLine("You chose to Add Income.");
                                Console.WriteLine("Enter income source:");
                                string incomeSource = Console.ReadLine();
                                Console.WriteLine("Enter your amount:");
                                double IncomeAmount = double.Parse(Console.ReadLine());
                                manager.AddTransaction(new Income(incomeSource, IncomeAmount));
                                userManager.UpdateIncome(IncomeAmount);
                                break;
                            case MenuOptions.AddExpense:
                                Console.WriteLine("You chose to Add Expense.");
                                Console.WriteLine("Enter expense name:");
                                string expenseName = Console.ReadLine();
                                Console.WriteLine("Enter expense amount:");
                                double expenseAmount = double.Parse(Console.ReadLine());
                                manager.AddTransaction(new Expense(expenseName, expenseAmount));
                                userManager.UpdateExpenses(expenseAmount);
                                break;
                            case MenuOptions.SetSavings:
                                Console.WriteLine("You chose to Add Savings.");
                                Console.WriteLine("Enter your savings goal:");
                                string savingsGoal = Console.ReadLine();
                                Console.WriteLine("Enter your savings Amount:");
                                double savingsAmount = double.Parse(Console.ReadLine());
                                manager.AddTransaction(new Savings(savingsGoal, savingsAmount));
                                break;
                            case MenuOptions.DisplaySummary:
                                Console.Clear();
                                Console.WriteLine($"{userManager.GetCurrentUser()?.Username}'s MoneyMentor summary:");
                                manager.DisplaySummary();
                                Console.WriteLine("Press enter to continue.");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case MenuOptions.Exit:
                                Console.WriteLine("Exiting...");
                                running = false;
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Please choose a valid menu option.");
                        Console.Clear();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Thread.Sleep(1000);
                    Console.Clear();
                }

                Console.WriteLine();
            }

        }
        public static string GetEnumDescription(Enum value)
        {
            try
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0)
                {
                    return attributes[0].Description;
                }
                else
                {
                    return value.ToString().Replace('_', ' ');
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving the description: " + ex.Message);
                return "Unknown"; // Return a default value in case of an error
            }
        }
    }

}