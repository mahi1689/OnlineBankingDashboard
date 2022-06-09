using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBankingDashboard.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChangerUserIdPwdContexts",
                columns: table => new
                {
                    AccountNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmLoginPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmTransactionPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnterOtp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangerUserIdPwdContexts", x => x.AccountNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangerUserIdPwdContexts");
        }
    }
}
