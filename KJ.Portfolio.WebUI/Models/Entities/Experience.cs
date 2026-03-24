using KJ.Portfolio.Web.Ui.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KJ.Portfolio.WebUI.Models.Entities
{
    [Table("Experiences")]
    public class Experience
    {
        [Key] public Guid Id { get; set; }

        public string? ImageUrl { get; set; }
        public string? FullName { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public string? SocialIconClass1 { get; set; }
        public string? SocialIconClass2 { get; set; }
        public string? SocialIconClass3 { get; set; }

        public string? SocialUrl1 { get; set; }
        public string? SocialUrl2 { get; set; }
        public string? SocialUrl3 { get; set; }

        public Guid HomePageId {  get; set; }
        [ForeignKey(nameof(HomePageId))]
        public virtual HomePage? HomePage { get; set; }
    }
}
