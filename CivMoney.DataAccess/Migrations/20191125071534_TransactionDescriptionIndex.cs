using Microsoft.EntityFrameworkCore.Migrations;

namespace CivMoney.DataAccess.Migrations
{
    public partial class TransactionDescriptionIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Transactions_Description",
                table: "Transactions",
                column: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_Description",
                table: "Transactions");
        }
    }
}
