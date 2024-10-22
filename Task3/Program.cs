namespace Task3
{
    // Interface for managing comments
    public interface ICommentManager
    {
        void AddComment(BlogPost post, Comment comment);
        void DeleteComment(Comment comment);
    }
    // Abstract class Comment with abstract method DisplayComment
    public abstract class Comment
    {
        public int CommentID { get; set; }
        public string? Author { get; set; }
        public string? Content { get; set; }

        public abstract void DisplayComment();
    }

    // UserComment class that implements ICommentManager
    public class UserComment : Comment, ICommentManager
    {
        public void AddComment(BlogPost post, Comment comment)
        {
            if (post == null)
            {
                throw new ArgumentException("Blog post cannot be null.");
            }
            post.Comments.Add(comment);
        }

        public void DeleteComment(Comment comment)
        {
            // Logic to delete comment
            
        }

        public override void DisplayComment()
        {
            Console.WriteLine($"Comment by {Author}: {Content}");
        }
    }
    // BlogPost class with PostID, Title, Content, and Comments properties
    public class BlogPost
    {
        public int PostID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }

    class Program
    {
        static void Main(string[] args)
        {
            BlogPost post = new BlogPost { PostID = 1, Title = "First Post", Content = "This is the content of the first post." };
            UserComment comment = new UserComment { CommentID = 1, Author = "John Doe", Content = "Great post!" };

            try
            {
                comment.AddComment(post, comment);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            foreach (var comm in post.Comments)
            {
                comm.DisplayComment();
            }
        }
    }
}