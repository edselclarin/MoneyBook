using System.ComponentModel.DataAnnotations;

namespace MoneyBook.Models
{
    public class Category
    {
        [Key]
        public int CatId { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
