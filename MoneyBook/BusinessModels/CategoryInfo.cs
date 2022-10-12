using System.ComponentModel;

namespace MoneyBook.BusinessModels
{
    public class CategoryInfo
    {
        [Browsable(false)]
        public int CatId { get; set; }

        public string Name { get; set; }
    }
}
