using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Birthday", "City", "Comment", "Created", "Email", "Name", "Phone" },
                values: new object[] { new Guid("df3b0e94-6ca7-4b53-be67-ac78953d2d05"), new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City1", "Comment1", new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c1@c1.c1", "Client1", "0122311" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Birthday", "City", "Comment", "Created", "Email", "Name", "Phone" },
                values: new object[] { new Guid("09da2dbe-64ff-466f-a516-681845dca32a"), new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City1", "Comment2", new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c2@c2.c2", "Client2", "0122311" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Birthday", "City", "Comment", "Created", "Email", "Name", "Phone" },
                values: new object[] { new Guid("2d5c7a86-625e-40b4-9081-7f0e19829e49"), new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City1", "Comment3", new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c3@c3.c3", "Client3", "0122311" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
