namespace OOP.EFCore.ConsoleApp.Entities
{
    public class BookDetail
    {
        public int BookDetailId { get; set; }

        // foreign key - unique
        // BookId ile birebir ilişki için gerekli
        public int BookId { get; set; }

        //navigation property
        // BookId ile birebir ilişki için gerekli
        public Book Book { get; set; }

        public string ISSN { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
    }
}
