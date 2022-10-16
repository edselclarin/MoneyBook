using System.ComponentModel.DataAnnotations;

namespace MoneyBook.Models
{
    public class RecurringTransaction
    {
        [Key]
        public int RecTrnsId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string TrnsType { get; set; }

        [Required]
        public string Payee { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public DateTime DateModified { get; set; }

        [Required]
        public int AcctId { get; set; }

        [Required]
        public int CatId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
