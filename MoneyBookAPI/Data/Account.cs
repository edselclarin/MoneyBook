namespace MoneyBookAPI.Data;

public partial class Account
{
    public int AcctId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string AcctType { get; set; } = null!;

    public int AcctTypeId { get; set; }

    public decimal StartingBalance { get; set; }

    public decimal ReserveAmount { get; set; }

    public DateTime DateAdded { get; set; }

    public DateTime DateModified { get; set; }

    public string ExtAcctId { get; set; } = null!;

    public int InstId { get; set; }

    public string? ImportFilePath { get; set; }

    public bool? IsDeleted { get; set; }
}
