using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalBusiness.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Businesses",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Businesses",
                columns: new[] { "BusinessId", "Address", "Category", "City", "Description", "Name", "Phone", "State", "Zip" },
                values: new object[,]
                {
                    { 1, "3106 SE Hawthorne Blvd", "Food & Drink", "Portland", "Cuban joint serves up homestyle fare plus cocktails in casual, vibrant surrounds with a patio.", "Cubo", "(971) 544-7801", "OR", "97214" },
                    { 2, "1801 NE Cesar E Chavez Blvd", "Food & Drink", "Portland", "Asian fusion dishes in quaint surrounds", "Gado Gado", "(503) 206-8778", "OR", "97212" },
                    { 3, "1005 W Burnside St", "Retail", "Portland", "Iconic bookstore occupying a city block", "Powell's City of Books", "(971) 544-7801", "OR", "97214" },
                    { 4, "4122 NE Sandy Blvd", "Entertainment", "Portland", "Historic movie house showing indie films.", "Hollywood Theatre", "(503) 493-1128", "OR", "97212" },
                    { 5, "3939 N Mississippi Ave", "Entertainment", "Portland", "A restored church houses this intimate live music spot", "Mississippi Studios", "(503) 288-3895", "OR", "97227" },
                    { 6, "6006 E Burnside St", "Service", "Portland", "Auto body shop.", "K&H Auto Shop", "(971) 300-8228", "OR", "97215" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Businesses",
                keyColumn: "BusinessId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Businesses",
                keyColumn: "BusinessId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Businesses",
                keyColumn: "BusinessId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Businesses",
                keyColumn: "BusinessId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Businesses",
                keyColumn: "BusinessId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Businesses",
                keyColumn: "BusinessId",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "City",
                table: "Businesses");
        }
    }
}
