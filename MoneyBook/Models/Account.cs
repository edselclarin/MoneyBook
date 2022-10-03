using System.ComponentModel.DataAnnotations;

namespace MoneyBook.Models
{
    public class Account
    {
        [Key]
        public int AcctId { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string ExtAcctId { get; set; }

        [Required]
        public int InstId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
