using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KJ.Portfolio.WebUI.Models.Entities
{
    [Table("PortfolioTags")]
    public class PortfolioTag
    {
        [Key] public Guid Id { get; set; }
    
        public string? Name { get; set; }

        public virtual ICollection<PortfolioItem>? Items { get; set; }
    }
}
