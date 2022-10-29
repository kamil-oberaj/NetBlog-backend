using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetBlog.Infrastructure.Persistence.Migrations.Business
{
    public partial class PersonEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Business");

            migrationBuilder.CreateTable(
                name: "Persons",
                schema: "Business",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    LastName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons",
                schema: "Business");
        }
    }
}
