using System.ComponentModel.DataAnnotations;

namespace MoneyBook.Models
{
    public class Institution
    {
        [Key]
        public int InstId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string InstType { get; set; }

        public bool IsDeleted { get; set; }
    }
}
