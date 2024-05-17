using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeBlazorAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmployeeDatas",
                columns: table => new
                {
                    EmpId = table.Column<string>(type: "varchar(255)", nullable: false),
                    EmpName = table.Column<string>(type: "longtext", nullable: false),
                    Designation = table.Column<string>(type: "longtext", nullable: false),
                    Department = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDatas", x => x.EmpId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDatas");
        }
    }
}
