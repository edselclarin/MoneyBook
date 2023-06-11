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
        public int AcctTypeId { get; set; }

        [Required]
        public decimal StartingBalance { get; set; }

        public decimal ReserveAmount { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public DateTime DateModified { get; set; }

        [Required]
        public string ExtAcctId { get; set; }

        [Required]
        public int InstId { get; set; }

        public string ImportFilePath { get; set; }

        public bool IsDeleted { get; set; }
    }
}
