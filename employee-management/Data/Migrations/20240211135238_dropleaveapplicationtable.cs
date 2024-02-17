using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace employee_management.Data.Migrations
{
    /// <inheritdoc />
    public partial class dropleaveapplicationtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "LeaveApplications");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
