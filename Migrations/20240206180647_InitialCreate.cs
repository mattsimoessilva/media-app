using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deepflix.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "meu_aplicativo_channel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meu_aplicativo_channel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "meu_aplicativo_episode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Show_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Season = table.Column<int>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    Thumbnail = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meu_aplicativo_episode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "meu_aplicativo_show",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Thumbnail = table.Column<string>(type: "TEXT", nullable: false),
                    Wallpaper = table.Column<string>(type: "TEXT", nullable: false),
                    Logo = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meu_aplicativo_show", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "meu_aplicativo_video",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Channel_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    Thumbnail = table.Column<string>(type: "TEXT", nullable: false),
                    Wallpaper = table.Column<string>(type: "TEXT", nullable: false),
                    Logo = table.Column<string>(type: "TEXT", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meu_aplicativo_video", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "meu_aplicativo_tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ShowId = table.Column<int>(type: "INTEGER", nullable: true),
                    VideoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meu_aplicativo_tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_meu_aplicativo_tag_meu_aplicativo_show_ShowId",
                        column: x => x.ShowId,
                        principalTable: "meu_aplicativo_show",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_meu_aplicativo_tag_meu_aplicativo_video_VideoId",
                        column: x => x.VideoId,
                        principalTable: "meu_aplicativo_video",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_meu_aplicativo_tag_ShowId",
                table: "meu_aplicativo_tag",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_meu_aplicativo_tag_VideoId",
                table: "meu_aplicativo_tag",
                column: "VideoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "meu_aplicativo_channel");

            migrationBuilder.DropTable(
                name: "meu_aplicativo_episode");

            migrationBuilder.DropTable(
                name: "meu_aplicativo_tag");

            migrationBuilder.DropTable(
                name: "meu_aplicativo_show");

            migrationBuilder.DropTable(
                name: "meu_aplicativo_video");
        }
    }
}
