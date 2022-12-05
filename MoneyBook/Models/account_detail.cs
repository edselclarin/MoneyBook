using System.ComponentModel.DataAnnotations;

namespace MoneyBook.Models
{
    public class account_detail
	{
        [Key]
        public int pk_acct_id { get; set; }
		public string acct_name { get; set; }
        public string acct_description { get; set; }
        public decimal starting_balance { get; set; }
        public decimal reserve_amount { get; set; }
        public decimal credits { get; set; }
        public decimal debits { get; set; }
        public decimal balance { get; set; }
        public decimal available_balance { get; set; }
        public string ext_acct_id { get; set; }
        public string acct_type_name { get; set; }
        public string inst_name { get; set; }
        public string inst_description { get; set; }
    }
}
