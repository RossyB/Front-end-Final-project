using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookStore.Models;

namespace BookStore.Api.Models
{
    public class AddCommentModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Content { get; set; }

        public string UserId { get; set; }

        public int BookId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}