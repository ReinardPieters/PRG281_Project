using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG281_Project
{
    internal class UserManager
    {
        private readonly string filePath = "users.json";
        private User currentUser;
        public void SignUpUser(string username, string password)
        {
            var users = new UserCollection();
            if (File.Exists(filePath))
            {
                users = ReadUsers();
            }
            if (users.Users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Username already exists. Please choose a different username.");
                return;
            }
            users.Users.Add(new User
            {
                Username = username,
                Password = password,
                TotalIncome = 0.0,
                TotalExpenses = 0.0,
                TotalSavings = 0.0
            });
            SaveUsers(users);
            Console.WriteLine("Successfully signed in");
        }
        public bool LogIn(string username, string password)
        {
            var users = ReadUsers();

            currentUser = users.Users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Password == password);
            if (currentUser !=null)
            {
                Console.WriteLine("Login successful!");
                return true; // Login successful
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
                currentUser = null;
                return false; // Login failed
            }
        }

        public User GetCurrentUser()
        {
            return currentUser;
        }

        public UserCollection ReadUsers() 
        {
            if (File.Exists(filePath)) 
            {
                var json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<UserCollection>(json) ?? new UserCollection();
            }
            return new UserCollection();
        }
        private void SaveUsers(UserCollection users) 
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(users, Formatting.Indented));
        }

        public void UpdateIncome(double income)
        {
            var users = ReadUsers();
            var user = users.Users.FirstOrDefault(u => u.Username == currentUser.Username);
            if (user != null)
            {
                user.TotalIncome = income;
                user.TotalSavings = user.TotalIncome - user.TotalExpenses;
                SaveUsers(users);
            }
        }

        // Update expenses and recalculate savings for a user
        public void UpdateExpenses(double expenses)
        {
            var users = ReadUsers();
            var user = users.Users.FirstOrDefault(u => u.Username == currentUser.Username);
            if (user != null)
            {
                user.TotalExpenses = expenses;
                user.TotalSavings = user.TotalIncome - user.TotalExpenses;
                SaveUsers(users);
            }
        }
    }
}
