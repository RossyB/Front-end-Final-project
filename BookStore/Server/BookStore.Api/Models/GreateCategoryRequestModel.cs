namespace BookStore.Api.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class GreateCategoryRequestModel
    {
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}