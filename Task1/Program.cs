using System.Text.RegularExpressions;

namespace Task1
{
    // User class
    public class User
    {
        // User spesific fields
        private string? _userid, _password, _email, _username;

        // User properties
        public string? UserID
        {
            get => _userid;
            set => _userid = value;
        }
        public string? Password
        {
            get => _password;
            set => _password = value;
        }
        public string? Email
        {
            get => _email;
            set
            {
                // Email check with regex
                if (!CheckEmail(value))
                {
                    throw new Exception("Invalid email address");
                }
                _email = value;
            }
        }
        public string? Username
        {
            get => _username;
            set => _username = value;
        }

        // Email check method
        public static bool CheckEmail(string email)
        {
            /* 
            * ^[\w-\.]+ : Start of the string, followed by one or more word characters (letters, digits, underscores), hyphens, or dots
            * @ : The '@' symbol
            * ([\w-]+\.)+ : One or more word characters, hyphens, followed by a dot, repeated one or more times
            * [\w-]{2,4} : Two to four word characters or hyphens (for the domain suffix)
            * $ : End of the string */
            string regExPtr = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            return Regex.IsMatch(email, regExPtr);
        }
        // BlogPost list
        private List<BlogPost> _blogPosts = new List<BlogPost>();
        // Add BlogPost method
        public void AddBlogPost(BlogPost post)
        {
            // Check if the author of the post is the user
            if (post.Author != this)
            {
                throw new Exception("The author of the post must be the user.");
            }

            _blogPosts.Add(post);
        }
        // Remove BlogPost method
        public void RemoveBlogPost(BlogPost post)
        {
            _blogPosts.Remove(post);
        }
        // Get BlogPosts method
        public List<BlogPost> GetBlogPosts()
        {
            return _blogPosts;
        }
    }

    public class BlogPost
    {
        // BlogPost spesific fields
        private string? _postid, _title, _content;
        private User? _author;
        private DateTime _datecreated;
        // BlogPost properties
        public string? PostID
        {
            get => _postid;
            set => _postid = value;
        }
        public string? Title
        {
            get => _title;
            set => _title = value;
        }
        public string? Content
        {
            get => _content;
            set
            {
                // Check if the content is too long (2500 characters)
                if (!CheckPostContent(value))
                {
                    throw new Exception("Post content is too long");
                }
                _content = value;
            }
        }
        public User? Author
        {
            get => _author;
            set => _author = value;
        }
        public DateTime DateCreated
        {
            get => _datecreated;
            set => _datecreated = value;
        }
        // CheckPostContent method
        public static bool CheckPostContent(string content)
        {
            return content.Length < 2500;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                User user1 = new User { UserID = "1", Username = "JohnDoe", Email = "john.doe@example.com", Password = "password123" };
                User user2 = new User { UserID = "2", Username = "JaneSmith", Email = "jane.smith@example.com", Password = "password456" };

                BlogPost post1 = new BlogPost
                {
                    PostID = "101",
                    Title = "First Post",
                    Content = "This is the content of the first post.",
                    Author = user1,
                    DateCreated = DateTime.Now
                };

                BlogPost post2 = new BlogPost
                {
                    PostID = "102",
                    Title = "Second Post",
                    Content = "This is the content of the second post.",
                    Author = user2,
                    DateCreated = DateTime.Now
                };

                user1.AddBlogPost(post1);
                user2.AddBlogPost(post2);

                Console.WriteLine("User 1 Blog Posts:");
                foreach (var post in user1.GetBlogPosts())
                {
                    Console.WriteLine($"Title: {post.Title}, Content: {post.Content}, Date: {post.DateCreated}");
                }

                Console.WriteLine("\nUser 2 Blog Posts:");
                foreach (var post in user2.GetBlogPosts())
                {
                    Console.WriteLine($"Title: {post.Title}, Content: {post.Content}, Date: {post.DateCreated}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
