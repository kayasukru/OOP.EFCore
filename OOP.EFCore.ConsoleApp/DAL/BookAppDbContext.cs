using Microsoft.EntityFrameworkCore;
using OOP.EFCore.ConsoleApp.DAL.Mapping;
using OOP.EFCore.ConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.EFCore.ConsoleApp.DAL
{
    public class BookAppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SKYN\\SQLEXPRESS; Initial Catalog=BookAppDb; User=sa; Password=Password1; Integrated Security=True; MultipleActiveResultSets=False; Encrypt=False; TrustServerCertificate=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            //BookMap.cs de tanımlandı.
            modelBuilder.Entity<Book>().
                HasKey(b => b.BookId);

            //BookMap.cs de tanımlandı.
            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(150);
            */

            //BookMap sınıfı kullanlıarak Code First işlemi
            modelBuilder.ApplyConfiguration(new BookMap());

            //CategoryMap sınıfı kullanılarak Code First İşlemi
            modelBuilder.ApplyConfiguration(new CategoryMap());

            //BookDetailMp sınıfı kullanılarak Code First işlemi
            modelBuilder.ApplyConfiguration(new BookDetailMap());
        }
    }
}
