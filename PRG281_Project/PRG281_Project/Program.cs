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

        [Description("Start Monitoring Expenses")]
        StartMonitoringExpenses,

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

            if (answer == "N")
            {
                Console.Clear();
                Console.WriteLine("Please enter your Username:");
                username = Console.ReadLine();
                Console.WriteLine("Please enter your Password");
                password = Console.ReadLine();
                UserManager userManager = new UserManager();
                userManager.SignUpUser(username, password);
            }
            else if (answer == "Y")
            {
                Console.Clear();
                Console.WriteLine("Please enter your Username:");
                username = Console.ReadLine();
                Console.WriteLine("Please enter your Password");
                password = Console.ReadLine();
                UserManager userManager = new UserManager();
                bool loginSuccess = userManager.LogIn(username, password);
                if (loginSuccess)
                { 
                    Console.WriteLine("Welcome to the application!");
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
                                break;
                            case MenuOptions.AddExpense:
                                Console.WriteLine("You chose to Add Expense.");
                                break;
                            case MenuOptions.SetSavings:
                                Console.WriteLine("You chose to Add Savings.");
                                break;
                            case MenuOptions.DisplaySummary:
                                Console.WriteLine("You chose to Display Summary.");
                                break;
                            case MenuOptions.StartMonitoringExpenses:
                                Console.WriteLine("You chose to Start Monitoring Expenses.");
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