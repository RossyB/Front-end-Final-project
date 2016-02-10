namespace BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        private ICollection<Comment> comments;

        public Book()
        {
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string Author { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [MaxLength(20)]
        public string Isbn { get; set; }

        public Decimal Price { get; set; }

        public string BookImageUrl { get; set; }

        public DateTime AddedOn { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }
    }
}
