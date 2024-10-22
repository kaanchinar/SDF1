using System;
using System.Collections.Generic;

namespace Task2
{
    // Base class User with UserID and Username properties
    public class User
    {
        public int UserID { get; set; }
        public string? Username { get; set; }

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"UserID: {UserID}, Username: {Username}");
        }
    }

    // Derived class AdminUser with ManageUsers and ManageBlogPosts methods
    public class AdminUser : User
    {
        public void ManageUsers()
        {
            Console.WriteLine("Managing users...");
        }

        public void ManageBlogPosts()
        {
            Console.WriteLine("Managing blog posts...");
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"[Admin] UserID: {UserID}, Username: {Username}");
        }
    }

    // Derived class RegularUser with no additional methods
    public class RegularUser : User
    {
        public override void DisplayDetails()
        {
            Console.WriteLine($"[Regular User] UserID: {UserID}, Username: {Username}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>
            {
            new AdminUser { UserID = 1, Username = "Admin1" },
            new RegularUser { UserID = 2, Username = "User1" }
            };

            foreach (var user in users)
            {
            user.DisplayDetails();
            try
            {
                if (user is AdminUser admin)
                {
                admin.ManageUsers();
                admin.ManageBlogPosts();
                }
                else
                {
                throw new UnauthorizedAccessException("User does not have admin permissions.");
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            }
        }
    }
}