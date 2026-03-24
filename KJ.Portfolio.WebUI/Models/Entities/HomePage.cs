using KJ.Portfolio.WebUI.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KJ.Portfolio.Web.Ui.Models.Entities
{
    [Table("HomePages")]
    public class HomePage
    {
        [Key]
        public Guid Id { get; set; }

        #region Hero Section
        public string? HeroTitle { get; set; }
        public string? HeroDescription { get; set; }
        public string? HeroImageUrl { get; set; }
        public string? HeroButtonTitle { get; set; }
        public string? HeroButtonUrl { get; set; }
        public string? HeroVideoButtonTitle { get; set; }
        public string? HeroVideoButtonUrl { get; set; }
        public string? HeroProjectTitle { get; set; }
        public short? HeroProjectCount { get; set; }
        public string? HeroClient { get; set; }
        public float? HeroClientPercent { get; set; }
        public string? HeroExperienceListTitle { get; set; }
        public DateOnly? HeroExperienceListYear { get; set; }
        #endregion

        #region About Section
        public string? AboutUpperTitle { get; set; }
        public string? AboutTitle { get; set; }
        public string? AboutDescription { get; set; }
        public string? AboutContentTitle { get; set; }
        public string? AboutContentDescription { get; set; }
        public string? AboutImageUrl { get; set; }
        public string? AboutButtonTitle { get; set; }
        public string? AboutButtonUrl { get; set; }
        public string? AboutExperienceListTitle { get; set; }
        public byte? AboutExperienceListCount { get; set; }
        public string? AboutProjectTitle { get; set; }
        public short? AboutProjectCount { get; set; }
        public string? AboutClientTitle { get; set; }
        public short? AboutClientCount { get; set; }
        public string? AboutAwardTitle { get; set; }
        public string? AboutAwardDescription { get; set; }
        public string? AboutAwardIconClass { get; set; }

        #endregion

        #region WhatIKnow Section
        public string? WhatIKnowUpperTitle { get; set; }
        public string? WhatIKnowTitle { get; set; }
        public string? WhatIKnowDescription { get; set; }
        public virtual ICollection<WhatIKnowCard>? WhatIKnowCards { get; set; }
        #endregion

        #region Technologies Section
        public string? TechnologiesUpperTitle { get; set; }
        public string? TechnologiesTitle { get; set; }
        public string? TechnologiesDescription { get; set; }
        public string? EducationTitle { get; set; }
        public string? EducationDescription { get; set; }
        public string? EducationImageUrl { get; set; }
        //public virtual ICollection<TechnologiesCard>? TechnologiesCards { get; set; }
        #endregion

        #region Portfolio
        public string? PortfolioUpperTitle { get; set; }
        public string? PortfolioTitle { get; set; }
        public string? PortfolioDescription { get; set; }
        [NotMapped]
        public virtual ICollection<PortfolioCategory>? Categories { get; set; }

        public string? PortfolioContactTitle { get; set; }
        public string? PortfolioContactDescription { get; set; }
        public string? PortfolioContactContactButtonTitle { get; set; }
        public string? PortfolioContactPortfolioButtonTitle { get; set; }
        #endregion

        #region Experience Seaction
        public string? ExperienceUpperTitle { get; set; }
        public string? ExperienceTitle { get; set; }
        public string? ExperienceDescription { get; set; }
        public virtual ICollection<Experience>? Experiences { get; set; }

        #endregion

        #region ExperienceList Section
        public string? ExperienceListUpperTitle { get; set; }
        public string? ExperienceListTitle { get; set; }
        public string? ExperienceListDescription { get; set; }
        public virtual ICollection<ExperienceListItem>? ExperienceListItems { get; set; }
        #endregion

        #region Contact Section
        public string? ContactUpperTitle { get; set; }
        public string? ContactTitle { get; set; }
        public string? ContactDescription { get; set; }
        public string? ContactContentTitle { get; set; }
        public string? ContactContentDescription { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }
        public string? ContactAddress { get; set; }
        public string? ContactFormTitle { get; set; }
        #endregion
    }
}
