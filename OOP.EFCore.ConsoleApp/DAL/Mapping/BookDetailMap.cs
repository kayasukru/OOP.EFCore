using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OOP.EFCore.ConsoleApp.Entities;

namespace OOP.EFCore.ConsoleApp.DAL.Mapping
{
    public class BookDetailMap : IEntityTypeConfiguration<BookDetail>
    {
        public void Configure(EntityTypeBuilder<BookDetail> builder)
        {
            builder.HasKey(bd => bd.BookDetailId);

            builder.Property(bd => bd.ISSN)
                .IsRequired()
                .HasDefaultValue("0000-0000-0000");

            builder.Property(bd => bd.Year)
                .HasDefaultValue(DateTime.Now.Year);
                //.HasDefaultValueSql("GETDATE()");

            builder.HasOne(bd => bd.Book) // birebir ilişiki
                .WithOne(b => b.BookDetail) //birebirilişki
                .HasForeignKey<BookDetail>(bd => bd.BookId)
                .OnDelete(DeleteBehavior.Cascade); // bir kategori silindiğinde bu kategorideki tüm kitapların silinmesini sağlar
        }
    }
}
