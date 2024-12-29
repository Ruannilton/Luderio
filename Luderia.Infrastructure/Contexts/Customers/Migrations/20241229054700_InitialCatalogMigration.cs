using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Luderia.Infrastructure.Contexts.Customers.Migrations
{
    /// <inheritdoc />
    public partial class InitialCatalogMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Address_Street = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Address_Number = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    Address_Complement = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Address_Neighborhood = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Address_City = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Address_State = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    Address_Country = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Address_ZipCode = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
