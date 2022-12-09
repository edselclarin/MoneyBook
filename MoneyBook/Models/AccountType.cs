using System.ComponentModel.DataAnnotations;

namespace MoneyBook.Models
{
    public class AccountType
    {
        [Key]
        public int AcctTypeId { get; set; }

        [Required]
        public string TypeName { get; set; }
    }
}
