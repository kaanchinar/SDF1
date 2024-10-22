namespace Task4
{
    // Abstract class Category with CategoryID and CategoryName properties
    public abstract class Category
    {
        public int CategoryID { get; set; }
        public required string CategoryName { get; set; }

        public abstract void GetCategoryDetails();
    }

    // Derived class Tag with Metadata property
    public class Tag : Category
    {
        public required string Metadata { get; set; }

        public override void GetCategoryDetails()
        {
            Console.WriteLine($"Tag ID: {CategoryID}, Name: {CategoryName}, Metadata: {Metadata}");
        }
    }

    // Derived class Genre with no additional properties
    public class Genre : Category
    {
        public override void GetCategoryDetails()
        {
            Console.WriteLine($"Genre ID: {CategoryID}, Name: {CategoryName}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create instances of Tag and Genre
                Tag tag = new Tag { CategoryID = 1, CategoryName = "Technology", Metadata = "Tech-related tags" };
                Genre genre = new Genre { CategoryID = 2, CategoryName = "Science Fiction" };

                // Display details using polymorphism
                DisplayCategoryDetails(tag);
                DisplayCategoryDetails(genre);

                // Attempt to display details for a non-existent category
                Category? nonExistentCategory = null;
                DisplayCategoryDetails(nonExistentCategory);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void DisplayCategoryDetails(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category), "Category cannot be null");
            }
            category.GetCategoryDetails();
        }
    }
}