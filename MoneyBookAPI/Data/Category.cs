namespace MoneyBookAPI.Data;

public partial class Category
{
    public int CatId { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsDeleted { get; set; }
}
