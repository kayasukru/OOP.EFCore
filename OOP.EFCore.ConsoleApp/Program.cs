using OOP.EFCore.ConsoleApp.DAL;

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

    }
}