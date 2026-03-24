using KJ.Portfolio.Web.Ui.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KJ.Portfolio.WebUI.Models.Entities
{

    [Table("PortfolioItems")]
    public class PortfolioItem
    {
        [Key] public Guid Id { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Client { get; set; }
        public DateOnly? ProjectYear { get; set; }

        public Guid CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual PortfolioCategory? Category { get; set; }

        public virtual ICollection<PortfolioTag>? Tags { get; set; }
    }
}
