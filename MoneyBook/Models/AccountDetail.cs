using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyBook.Models
{
    public class AccountDetail
    {
        [Key]
        public int AcctDetId { get; set; }

        [ForeignKey("AcctId")]
		public int AcctId { get; set; }

        [Required]
        public decimal Debits { get; set; }

        [Required]
        public decimal Credits { get; set; }

        [Required]
        public decimal AvailableBalance { get; set; }

        [Required]
        public decimal ActualBalance { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
