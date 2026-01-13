using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace otep.api.Migrations
{
    /// <inheritdoc />
    public partial class Authen_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiKeys",
                columns: table => new
                {
                    key_id = table.Column<Guid>(type: "uuid", nullable: false),
                    api_key = table.Column<string>(type: "text", nullable: true),
                    org_id = table.Column<string>(type: "text", nullable: true),
                    key_name = table.Column<string>(type: "text", nullable: true),
                    key_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    key_expired_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    key_description = table.Column<string>(type: "text", nullable: true),
                    key_status = table.Column<string>(type: "text", nullable: true),
                    roles_list = table.Column<string>(type: "text", nullable: true),
                    custom_role_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiKeys", x => x.key_id);
                });

            migrationBuilder.CreateTable(
                name: "CustomRoles",
                columns: table => new
                {
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    org_id = table.Column<string>(type: "text", nullable: true),
                    role_name = table.Column<string>(type: "text", nullable: true),
                    role_description = table.Column<string>(type: "text", nullable: true),
                    role_definition = table.Column<string>(type: "text", nullable: true),
                    tags = table.Column<string>(type: "text", nullable: true),
                    level = table.Column<string>(type: "text", nullable: true),
                    role_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomRoles", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    org_id = table.Column<Guid>(type: "uuid", nullable: false),
                    org_custom_id = table.Column<string>(type: "text", nullable: true),
                    org_name = table.Column<string>(type: "text", nullable: true),
                    org_description = table.Column<string>(type: "text", nullable: true),
                    tags = table.Column<string>(type: "text", nullable: true),
                    addresses = table.Column<string>(type: "text", nullable: true),
                    channels = table.Column<string>(type: "text", nullable: true),
                    logo_image_path = table.Column<string>(type: "text", nullable: true),
                    org_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.org_id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationsUsers",
                columns: table => new
                {
                    org_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    org_custom_id = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<string>(type: "text", nullable: true),
                    user_name = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    roles_list = table.Column<string>(type: "text", nullable: true),
                    is_org_initial_user = table.Column<string>(type: "text", nullable: true),
                    user_status = table.Column<string>(type: "text", nullable: true),
                    tmp_user_email = table.Column<string>(type: "text", nullable: true),
                    previous_user_status = table.Column<string>(type: "text", nullable: true),
                    invited_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    invited_by = table.Column<string>(type: "text", nullable: true),
                    tags = table.Column<string>(type: "text", nullable: true),
                    custom_role_id = table.Column<string>(type: "text", nullable: true),
                    OrgName = table.Column<string>(type: "text", nullable: true),
                    OrgDesc = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationsUsers", x => x.org_user_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_name = table.Column<string>(type: "text", nullable: true),
                    user_email = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    lastname = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    secondary_email = table.Column<string>(type: "text", nullable: true),
                    phone_number_verified = table.Column<string>(type: "text", nullable: true),
                    secondary_email_verified = table.Column<string>(type: "text", nullable: true),
                    is_org_initial_user = table.Column<string>(type: "text", nullable: true),
                    user_created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                    table.CheckConstraint("CK_User_PhoneNumber_E164", "phone_number ~ '^\\+[1-9][0-9]{7,14}$'");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApiKeys_api_key",
                table: "ApiKeys",
                column: "api_key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiKeys_key_name",
                table: "ApiKeys",
                column: "key_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiKeys_org_id",
                table: "ApiKeys",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomRoles_org_id_role_name",
                table: "CustomRoles",
                columns: new[] { "org_id", "role_name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomRoles_role_name",
                table: "CustomRoles",
                column: "role_name");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_org_custom_id",
                table: "Organizations",
                column: "org_custom_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationsUsers_org_custom_id",
                table: "OrganizationsUsers",
                column: "org_custom_id");

            migrationBuilder.CreateIndex(
                name: "OrgUser_Unique1",
                table: "OrganizationsUsers",
                columns: new[] { "org_custom_id", "user_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_user_email",
                table: "Users",
                column: "user_email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_user_name",
                table: "Users",
                column: "user_name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiKeys");

            migrationBuilder.DropTable(
                name: "CustomRoles");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "OrganizationsUsers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
