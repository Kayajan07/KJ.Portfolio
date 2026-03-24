using KJ.Portfolio.Web.Ui.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KJ.Portfolio.WebUI.Models.Entities
{
    [Table("ExperienceListItems")]
    public class ExperienceListItem
    {
        [Key] public Guid Id { get; set; }

        public string? ImageUrl { get; set; }
        public string? FullName { get; set; }
        public string? Title { get; set; }
        public string? Comment { get; set; }

        public Guid HomePageId { get; set; }
        [ForeignKey(nameof(HomePageId))]
        public virtual HomePage? HomePage { get; set; }
    }
}
