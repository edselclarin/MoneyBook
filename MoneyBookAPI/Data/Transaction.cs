namespace MoneyBookAPI.Data;

public partial class Transaction
{
    public int TrnsId { get; set; }

    public DateTime Date { get; set; }

    public string TrnsType { get; set; } = null!;

    public string? RefNum { get; set; }

    public string Payee { get; set; } = null!;

    public string? Memo { get; set; }

    public string State { get; set; } = null!;

    public decimal Amount { get; set; }

    public string? ExtTrnsId { get; set; }

    public DateTime DateAdded { get; set; }

    public DateTime DateModified { get; set; }

    public int AcctId { get; set; }

    public int CatId { get; set; }

    public bool? IsDeleted { get; set; }
}
