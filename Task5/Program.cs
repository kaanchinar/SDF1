namespace Task5
{
    // Abstract class Notification with NotificationID and Message properties
    public class Notification
    {
        public int NotificationID { get; set; }
        public required string Message { get; set; }
        
        public virtual void DisplayNotification()
        {
            Console.WriteLine($"Notification ID: {NotificationID}, Message: {Message}");
        }
    }
    // Derived class NewPostNotification with PostTitle property
    public class NewPostNotification : Notification
    {
        public required string PostTitle { get; set; }
        public override void DisplayNotification()
        {
            Console.WriteLine($"New Post Alert! Title: {PostTitle}, Message: {Message}");
        }
    }
    // Derived class NewCommentNotification with CommentAuthor property
    public class NewCommentNotification : Notification
    {
        public required string CommentAuthor { get; set; }

        public override void DisplayNotification()
        {
            Console.WriteLine($"New Comment Alert! Author: {CommentAuthor}, Message: {Message}");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Notification[] notifications = new Notification[]
            {
                new NewPostNotification { NotificationID = 1, Message = "Check out the new post!", PostTitle = "Introduction to C#" },
                new NewCommentNotification { NotificationID = 2, Message = "Someone commented on your post.", CommentAuthor = "John Doe" }
            };

            try
            {
                if (notifications.Length == 0)
                {
                    throw new Exception("No notifications to display.");
                }

                foreach (var notification in notifications)
                {
                    notification.DisplayNotification();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}