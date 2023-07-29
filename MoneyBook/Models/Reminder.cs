using System.ComponentModel.DataAnnotations;

namespace MoneyBook.Models
{
    public class Reminder
    {
        [Key]
        public int RmdrId { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public string TrnsType { get; set; }

        [Required]
        public string Payee { get; set; }

        public string Memo { get; set; }

        public string Website { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Frequency { get; set; }   

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
