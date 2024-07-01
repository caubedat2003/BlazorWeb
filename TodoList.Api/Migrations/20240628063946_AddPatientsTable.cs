using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
           name: "Patients",
           columns: table => new
           {
               PatientId = table.Column<Guid>(nullable: false),
               Name = table.Column<string>(nullable: false),
               Gender = table.Column<int>(nullable: false),
               Job = table.Column<string>(nullable: true),
               DateOfBirth = table.Column<DateTime>(nullable: false),
               PhoneNumber = table.Column<string>(nullable: true),
               CreatedDate = table.Column<DateTime>(nullable: false),
               Address = table.Column<string>(nullable: true)
           },
           constraints: table =>
           {
               table.PrimaryKey("PK_Patients", x => x.PatientId);
           });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
           name: "Patients");
        }
    }
}
