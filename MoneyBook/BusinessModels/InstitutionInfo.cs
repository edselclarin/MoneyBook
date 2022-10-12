using System.ComponentModel;

namespace MoneyBook.BusinessModels
{
    public class InstitutionInfo
    {
        [Browsable(false)] 
        public int InstId { get; set; }

        public string Name { get; set; }
        
        public string InstType { get; set; }
    }
}
