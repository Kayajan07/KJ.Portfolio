using KJ.Portfolio.Web.Ui.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KJ.Portfolio.WebUI.Models.Entities
{
    [Table("WhatIKnowCards")]
    public class WhatIKnowCard
    {
        [Key]
        public Guid Id { get; set; }
    
        public string? IconClass { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public Guid HomePageId { get; set; }

        [ForeignKey(nameof(HomePageId))]
        public virtual HomePage? HomePage { get; set; }
    }
}
