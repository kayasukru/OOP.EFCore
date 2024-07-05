using OOP.EFCore.ConsoleApp.DAL;
using OOP.EFCore.ConsoleApp.Entities;
using System.Threading.Channels;
internal class Program
{
    private static void Main(string[] args)
    {
        /*
        //Cascade ifadesi 
        //Aşağıdaki kodlar 2 Id'li kategoriyi siler
        //Aynı zamanda bu kategorideki kitapları da siler
        //Ayrıca 2 Id'li kitaplara air BookDetail kaydını da siler
        var _context =new BookAppDbContext();
        var category = _context.Categories
            .Where(c=>c.CategoryId == 2)
            .SingleOrDefault();

        _context.Categories.Remove(category);
        _context.SaveChanges();

        Console.WriteLine("2 nolu kategori ve bu kategorideki kitaplar ve kitap detayları silindi");
        */

        /*
        //SetNull ifadesi
        //Aşağıdaki kodlar 3 Id'li kategoriyi siler
        //Ama bu kategorideki kitapların sadec CategoryId'lerini siler. Kitap kaydını silmez
        var _context = new BookAppDbContext();
        var category = _context.Categories
            .Where(c => c.CategoryId == 3)
            .SingleOrDefault();

        _context.Categories.Remove(category);
        _context.SaveChanges();

        Console.WriteLine("3 nolu kategori silindi, bu kategorideki kitapların CategoryId'si de NULL yapıldı. Kitaplar silinmedi.");
        */







        //UYGULAMALAR

        //Yeni bir kitabı Category'lerdeki ilk kayıtla ve BookDetail bilgilerini de kaydeder.
        //AddBookWithFirstCategoryAndBookDetail();

        // Kategorisi ile  birlikte bir kitap kaydı yapar
        //AddBookCategory();

        //En sondaki kitabı siler
        //DeleteBook();

        // İlk kitabın adını günceller
        //UpdateBook();

        //Veritabanındaki tüm kitapları listeler
        ListOfBooks();

        //Veritabanına 5 kitap ekler
        //Addbooks();

        //Veritabanına 1 kitap ekler
        //AddBook();

    }

    //Yeni bir kitabı Category'lerdeki ilk kayıtla ve BookDetail bilgilerini de kaydeder.
    private static void AddBookWithFirstCategoryAndBookDetail()
    {
        using (var _context = new BookAppDbContext())
        {
            //Yeni bir kitabın kaydı oluşturulur
            var book = new Book
            {
                // Kİtap bilgileri verilir
                Title = "Veritabanı Yönetimi",
                Price = 400,

                //kitaba kategori bilgisi verilir
                Category = _context.Categories.OrderBy(c => c.CategoryId).FirstOrDefault(), // Kategory'den ilk kaydı seçer ve kitaba category olarak verir.

                //Kitap detay bilgileri verilir
                BookDetail = new BookDetail
                {
                    City = "Bursa",
                    Country = "Türkiye",
                    ISSN = "1234-4567-7894"
                }
            };
            _context.Books.Add(book);
            _context.SaveChanges();

            ListOfBooks();

        }
    }

    // Kategorisi ile  birlikte bir kitap kaydı yapar
    private static void AddBookCategory()
    {
        var book = new Book
        {
            Title = "Yazılım Mühendisliği",
            Price = 240,
            Category = new Category
            {
                CategoryName = "Yazılım"
            }
        };

        using (var _context = new BookAppDbContext())
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            ListOfBooks();

            Console.WriteLine("---------------");
            _context.Categories.ToList().ForEach(c => Console.WriteLine(c.CategoryName));
        }
    }

    //En sondaki kitabı siler
    private static void DeleteBook()
    {
        using (var _context = new BookAppDbContext())
        {
            var book = _context.Books.OrderBy(b => b.BookId).LastOrDefault();

            _context.Books.Remove(book);
            _context.SaveChanges();

            ListOfBooks();
        }
    }

    // İlk kitabın adını günceller
    private static void UpdateBook()
    {
        using (var _context = new BookAppDbContext())
        {
            var book = _context.Books.OrderBy(b => b.BookId).FirstOrDefault();

            book.Title = "Updated Book";
            book.Price = 15;

            _context.SaveChanges();

            ListOfBooks();
        }
    }

    //Veritabanındaki tüm kitapları listeler
    private static void ListOfBooks()
    {
        var list = new List<Book>();
        using (var _context = new BookAppDbContext())
        {
            list = _context.Books.ToList();

            foreach (var item in list)
            {
                Console.WriteLine($"{item.BookId,-5} {item.Title,-25} {item.Price,-5}");
            }
        }
    }

    //Veritabanına 5 kitap ekler
    private static void Addbooks()
    {
        var list = new List<Book>
        {
            new Book{Title="EF Core 1", Price=25},
            new Book{Title="EF Core 2", Price=125},
            new Book{Title="EF Core 3", Price=225},
            new Book{Title="EF Core 4", Price=325},
            new Book{Title="EF Core 5", Price=425}
        };

        using (var _context = new BookAppDbContext())
        {
            _context.Books.AddRange(list);
            _context.SaveChanges();
        }

    }

    //Veritabanına 1 kitap ekler
    private static void AddBook()
    {
        // Uygulamalar
        var book = new Book
        {
            Title = "Entity Frame WOrk",
            Price = 100
        };

        using (var _context = new BookAppDbContext())
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

    }
}