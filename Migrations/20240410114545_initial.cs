using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImpactTraining.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Id = table.Column<long>(type: "bigint", nullable: false),
                    Account_No = table.Column<long>(type: "bigint", nullable: false),
                    Ifsc_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account_Holder_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Check_No = table.Column<long>(type: "bigint", nullable: false),
                    MICR_Code = table.Column<long>(type: "bigint", nullable: false),
                    Is_Processed = table.Column<bool>(type: "bit", nullable: false)
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
