using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.EFCore.ConsoleApp.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Price { get; set; }


        // foreign key -> Çoka bir ilişki - kategori/kitap ilişkisi
        public int? CategoryId { get; set; }

        //simple navigation propperty -> Çoka bir ilişki - kategori/kitap ilişkisi
        public Category Category { get; set; }


        // navigation property -> Bire bir ilişki - kitap ve kitap detayı  ilişkisi
        public BookDetail BookDetail { get; set; }


        // collection navigation propperty -> çoka çok ilişki Kitap/Yazar ilişkisi
        public ICollection<BookAuthor> BookAuthors { get; set; }

    }
}
