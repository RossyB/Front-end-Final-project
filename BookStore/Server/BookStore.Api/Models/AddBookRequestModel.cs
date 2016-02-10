using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BookStore.Models;

namespace BookStore.Api.Models
{
    public class AddBookRequestModel
    {
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

        public string OwnerId { get; set; }
    }
}