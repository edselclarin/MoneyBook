namespace MoneyBookAPI.Data;

public partial class RecurringTransaction
{
    public int RecTrnsId { get; set; }

    public DateTime DueDate { get; set; }

    public string TrnsType { get; set; } = null!;

    public string Payee { get; set; } = null!;

    public string? Memo { get; set; }

    public string? Website { get; set; }

    public decimal Amount { get; set; }

    public string? Frequency { get; set; }

    public DateTime DateAdded { get; set; }

    public DateTime DateModified { get; set; }

    public int AcctId { get; set; }

    public int CatId { get; set; }

    public bool? IsDeleted { get; set; }
}
