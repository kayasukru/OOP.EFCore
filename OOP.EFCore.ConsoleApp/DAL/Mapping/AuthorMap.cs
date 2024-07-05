using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OOP.EFCore.ConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.EFCore.ConsoleApp.DAL.Mapping
{
    public class AuthorMap : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.AuthorId);

            builder.Property(a => a.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
                //.HasDefaultValue(DateTime.Now.Year);

            builder.Ignore(a => a.FullName);

            builder.HasData(
                new Author { AuthorId = 1, FirstName = "Şükrü", LastName = "Kaya" },
                new Author { AuthorId = 2, FirstName = "Ali", LastName = "Kıran" },
                new Author { AuthorId = 3, FirstName = "Seher", LastName = "Gül" },
                new Author { AuthorId = 4, FirstName = "Koray", LastName = "Çırpan" }
                );
        }
    }
}
