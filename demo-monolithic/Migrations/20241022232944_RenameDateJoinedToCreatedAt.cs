using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace demo_monolithic.Migrations
{
    /// <inheritdoc />
    public partial class RenameDateJoinedToCreatedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateJoined",
                table: "Employees",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Employees",
                newName: "DateJoined");
        }
    }
}
