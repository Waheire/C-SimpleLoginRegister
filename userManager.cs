using login_Registration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login_Registration
{
    internal class userManager
    {
        private List<User> _users = new List<User>();

        private User _isLoggedIn;
        private string _filePath;

        public userManager(string filePath ) 
        {
            _filePath = filePath;
            LoadUsers();
        }
        //register users
        public void RegisterUser() 
        {
            Console.WriteLine("===== Register =====");
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            // Check if the username already exists
            if (_users.Exists(u => u.username == username))
            {
                Console.WriteLine("Username already exists. Please choose a different one.");
                return;
            }
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();


            User newUser = new User(username, email, password);
            _users.Add(newUser);
            //save user information 
            saveUsers();
            Console.WriteLine("Registration successful!");
        }

        //loginUsers
        public void LoginUser() {
            Console.WriteLine("===== Login =====");
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            User user = _users.Find(u => u.username == username && u.password == password);

            if (user != null)
            {
                _isLoggedIn = user;
                Console.WriteLine("Login successful!");
                loadDashboard();
            }
            else
            {
                Console.WriteLine("Invalid username or password. Please try again.");
            }
        }

        //show dashboard
        public void loadDashboard() 
        {
            Console.WriteLine("===== Dashboard =====");

            if (_isLoggedIn != null && _isLoggedIn.role == "admin")
            {
                Console.WriteLine($"Welcome, {_isLoggedIn.username}!");
            }
            else
            {
                Console.WriteLine("You are not logged in. Please log in to view the dashboard.");
            }
        }


        //load users
        public void LoadUsers()
        {
            if (File.Exists(_filePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(_filePath);

                    foreach (var line in lines)
                    {
                        string[] parts = line.Split(':');
                        if (parts.Length == 5)
                        {
                            string storedUsername = parts[1].Trim();
                            string storedPassword = parts[2].Trim();
                            string storedEmail = parts[3].Trim();   
                            _users.Add(new User(
                                storedUsername,
                                storedPassword,
                                storedEmail
                                ));
                        }
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error reading from file: {ex.Message}");
                }
            }

        }

        //save users to file
        public void saveUsers() 
        {
            try
            {
                List<string> userLines = new List<string>();

                foreach (var user in _users)
                {
                    userLines.Add($"{user.Id}:{user.username}:{user.email}:{user.password}:{user.role}");
                }

                File.WriteAllLines(_filePath, userLines);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }
    }
    }

