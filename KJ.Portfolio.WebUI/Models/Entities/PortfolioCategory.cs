using KJ.Portfolio.WebUI.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KJ.Portfolio.Web.Ui.Models.Entities
{
    [Table("PortfolioCategories")]
    public class PortfolioCategory
    {
        [Key] public Guid Id { get; set; }

        public string? Name { get; set; }

        public virtual ICollection<PortfolioItem>? Items { get; set; }
    }
}
