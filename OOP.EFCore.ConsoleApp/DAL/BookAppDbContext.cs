using Microsoft.EntityFrameworkCore;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SKYN\\SQLEXPRESS; Initial Catalog=BookAppDb; User=sa; Password=Password1; Integrated Security=True; MultipleActiveResultSets=False; Encrypt=False; TrustServerCertificate=False;");
        }
    }
}
