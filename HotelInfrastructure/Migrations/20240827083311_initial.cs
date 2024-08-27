using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelInfrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomType = table.Column<string>(type: "text", nullable: true),
                    RoomName = table.Column<string>(type: "text", nullable: true),
                    Guests = table.Column<int>(type: "integer", nullable: false),
                    Beds = table.Column<int>(type: "integer", nullable: false),
                    BedType = table.Column<string>(type: "text", nullable: true),
                    RoomDescription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Page = table.Column<int>(type: "integer", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reserveds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomName = table.Column<string>(type: "text", nullable: true),
                    RoomType = table.Column<string>(type: "text", nullable: true),
                    checkInDate = table.Column<string>(type: "text", nullable: true),
                    checkOutDate = table.Column<string>(type: "text", nullable: true),
                    Guests = table.Column<int>(type: "integer", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    Tc_PassportNo = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserveds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserveds_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Country", "CreatedDate", "Email", "FirstName", "LastName", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("4709dbb5-d36f-430d-8d2f-137d816cb0ac"), "USA", new DateTime(2024, 8, 27, 11, 33, 11, 160, DateTimeKind.Local).AddTicks(7183), "ali@gmail.com", "Ali", "Yagız", "Ali Yagız", null },
                    { new Guid("7ffd45e0-0b24-4390-b8b9-0046267c3baf"), "Turkiye", new DateTime(2024, 8, 27, 11, 33, 11, 160, DateTimeKind.Local).AddTicks(7475), "gokdeniz@gmail.com", "Gokdeniz", "Sahin", "Gokdeniz Sahin", null },
                    { new Guid("f6583844-e295-4aeb-9fc7-6683ff995cd4"), "England", new DateTime(2024, 8, 27, 11, 33, 11, 160, DateTimeKind.Local).AddTicks(7485), "mirac@gmail.com", "Mirac", "Kars", "Mirac Kars", null }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BedType", "Beds", "Guests", "RoomDescription", "RoomName", "RoomType" },
                values: new object[,]
                {
                    { new Guid("bd682482-c897-4ace-ade2-3564ab4e118b"), "Tek kişilik", 2, 3, "Klima Mevcut", "Standart-101", "Standart" },
                    { new Guid("99741f1f-1b86-4f8c-a2cc-1bfc0c2c3e70"), "Çift kişilik", 1, 2, "Klima Mevcut", "VIP-805", "VIP" },
                    { new Guid("f443bd0e-e2a0-4100-a5a7-e1c6b3a3cf37"), "Tek kişilik", 3, 5, "Klima Mevcut", "Standart-204", "Standart" }
                });

            migrationBuilder.InsertData(
                table: "Reserveds",
                columns: new[] { "Id", "FullName", "Guests", "Phone", "RoomId", "RoomName", "RoomType", "Tc_PassportNo", "checkInDate", "checkOutDate" },
                values: new object[,]
                {
                    { new Guid("6434fe36-f3d1-4667-a098-4468198f71c1"), "Ali Yagız", 3, "052484345", new Guid("bd682482-c897-4ace-ade2-3564ab4e118b"), "Standart-101", "Standart", "784548547824", "2024-05-12", "2024-05-15" },
                    { new Guid("5feae7e1-8c36-44fb-b1b7-836a00158ab3"), "Gokdeniz Sahin", 2, "05364854", new Guid("99741f1f-1b86-4f8c-a2cc-1bfc0c2c3e70"), "VIP-809", "VIP", "8849995584", "2024-06-18", "2024-06-28" },
                    { new Guid("9425dcd5-95b2-40c8-a8a2-cedd6aabfdde"), "Beyza Nur", 4, "0535889414", new Guid("f443bd0e-e2a0-4100-a5a7-e1c6b3a3cf37"), "Standart-206", "Standart", "231515354745", "2024-08-02", "2024-08-09" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserveds_RoomId",
                table: "Reserveds",
                column: "RoomId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Reserveds");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
