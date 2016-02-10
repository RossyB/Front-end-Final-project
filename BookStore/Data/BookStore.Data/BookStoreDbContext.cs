using System.Data.Entity;
using System.Runtime.InteropServices;

namespace BookStore.Data
{
    using BookStore.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class BookStoreDbContext : IdentityDbContext<User>, IBookStoreDbContext
    {
        public BookStoreDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Category> Categories { get; set; } 

        public virtual IDbSet<Book> Books { get; set; } 

        public virtual IDbSet<Rating> Ratings { get; set; } 

        public static BookStoreDbContext Create()
        {
            return new BookStoreDbContext();
        }
    }
}
