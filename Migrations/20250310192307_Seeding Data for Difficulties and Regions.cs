using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NzWalks.Migrations
{
    public partial class SeedingDataforDifficultiesandRegions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("b75d59ff-04e4-44ff-8bb1-d5f68ee8fec8"), "Hard" },
                    { new Guid("b984ecd3-e578-43c5-8565-6ec56cac3216"), "Medium" },
                    { new Guid("c900add3-213f-4615-bcd7-788c75805d91"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0d32f077-5f74-40ba-bd0f-3fa2b6e7757c"), "SC", "Stem Center", "stem.jpeg" },
                    { new Guid("1270242a-44a1-42d6-9d0d-c1372c852e1a"), "GP", "Globalization Partners", "gp.jpeg" },
                    { new Guid("76cdfc42-5e6b-4696-ac77-ea8759ce71d0"), "KE", "Kenya", "kenya.jpeg" },
                    { new Guid("f807fc4d-69d7-4da7-9e2b-b0d63f75d9c6"), "USA", "America", "states.jpeg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b75d59ff-04e4-44ff-8bb1-d5f68ee8fec8"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b984ecd3-e578-43c5-8565-6ec56cac3216"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("c900add3-213f-4615-bcd7-788c75805d91"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0d32f077-5f74-40ba-bd0f-3fa2b6e7757c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1270242a-44a1-42d6-9d0d-c1372c852e1a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("76cdfc42-5e6b-4696-ac77-ea8759ce71d0"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f807fc4d-69d7-4da7-9e2b-b0d63f75d9c6"));
        }
    }
}
