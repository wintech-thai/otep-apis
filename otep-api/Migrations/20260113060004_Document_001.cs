using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace otep.api.Migrations
{
    /// <inheritdoc />
    public partial class Document_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    doc_id = table.Column<Guid>(type: "uuid", nullable: false),
                    org_id = table.Column<string>(type: "text", nullable: true),
                    doc_name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    tags = table.Column<string>(type: "text", nullable: true),
                    doc_type = table.Column<string>(type: "text", nullable: true),
                    bucket = table.Column<string>(type: "text", nullable: true),
                    path = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.doc_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_doc_name",
                table: "Documents",
                column: "doc_name");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_org_id_doc_name",
                table: "Documents",
                columns: new[] { "org_id", "doc_name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");
        }
    }
}
