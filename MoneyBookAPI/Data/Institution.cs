namespace MoneyBookAPI.Data;

public partial class Institution
{
    public int InstId { get; set; }

    public string Name { get; set; } = null!;

    public string InstType { get; set; } = null!;

    public bool? IsDeleted { get; set; }
}
