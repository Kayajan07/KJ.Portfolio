using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KJ.Portfolio.WebUI.Migrations
{
    /// <inheritdoc />
    public partial class t1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomePages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HeroTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroButtonTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroButtonUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroVideoButtonTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroVideoButtonUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroProjectTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroProjectCount = table.Column<short>(type: "smallint", nullable: true),
                    HeroClient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroClientPercent = table.Column<float>(type: "real", nullable: true),
                    HeroExperienceListTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroExperienceListYear = table.Column<byte>(type: "tinyint", nullable: true),
                    AboutUpperTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutContentTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutContentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutButtonTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutButtonUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutExperienceListTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutExperienceListCount = table.Column<byte>(type: "tinyint", nullable: true),
                    AboutProjectTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutProjectCount = table.Column<short>(type: "smallint", nullable: true),
                    AboutClientTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutClientCount = table.Column<short>(type: "smallint", nullable: true),
                    AboutAwardTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutAwardDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutAwardIconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatIKnowUpperTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatIKnowTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatIKnowDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnologiesUpperTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnologiesTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnologiesDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioUpperTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioContactTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioContactDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioContactContactButtonTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortfolioContactPortfolioButtonTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceUpperTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceListUpperTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceListTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceListDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactUpperTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactContentTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactContentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactFormTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WhatIKnowCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhatIKnowCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WhatIKnowCards_HomePages_HomePageId",
                        column: x => x.HomePageId,
                        principalTable: "HomePages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialIconClass1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialIconClass2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialIconClass3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialUrl1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialUrl3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_HomePages_HomePageId",
                        column: x => x.HomePageId,
                        principalTable: "HomePages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceListItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceListItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperienceListItems_HomePages_HomePageId",
                        column: x => x.HomePageId,
                        principalTable: "HomePages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechnologiesCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnologiesCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnologiesCards_HomePages_HomePageId",
                        column: x => x.HomePageId,
                        principalTable: "HomePages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Client = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectYear = table.Column<DateOnly>(type: "date", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioItems_PortfolioCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "PortfolioCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioItemPortfolioTag",
                columns: table => new
                {
                    ItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioItemPortfolioTag", x => new { x.ItemsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_PortfolioItemPortfolioTag_PortfolioItems_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "PortfolioItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortfolioItemPortfolioTag_PortfolioTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "PortfolioTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioItemPortfolioTag_TagsId",
                table: "PortfolioItemPortfolioTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioItems_CategoryId",
                table: "PortfolioItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WhatIKnowCards_HomePageId",
                table: "WhatIKnowCards",
                column: "HomePageId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_HomePageId",
                table: "Experiences",
                column: "HomePageId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceListItems_HomePageId",
                table: "ExperienceListItems",
                column: "HomePageId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnologiesCards_HomePageId",
                table: "TechnologiesCards",
                column: "HomePageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PortfolioItemPortfolioTag");

            migrationBuilder.DropTable(
                name: "WhatIKnowCards");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "ExperienceListItems");

            migrationBuilder.DropTable(
                name: "TechnologiesCards");

            migrationBuilder.DropTable(
                name: "PortfolioItems");

            migrationBuilder.DropTable(
                name: "PortfolioTags");

            migrationBuilder.DropTable(
                name: "HomePages");

            migrationBuilder.DropTable(
                name: "PortfolioCategories");
        }
    }
}
