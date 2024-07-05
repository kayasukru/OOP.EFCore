namespace OOP.EFCore.ConsoleApp.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }

        // Collection navigation property
        // Category ile Books verisinin çoklu ilişki kurabilceği tanımlanır
        public ICollection<Book> Books { get; set; }
    }
}
