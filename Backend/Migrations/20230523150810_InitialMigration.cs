using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemCategories",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastChanged = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ItemCategoryID = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastChanged = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Items_ItemCategories_ItemCategoryID",
                        column: x => x.ItemCategoryID,
                        principalTable: "ItemCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    DiscountChain = table.Column<int>(type: "integer", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    ItemCategoryID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Shops_ItemCategories_ItemCategoryID",
                        column: x => x.ItemCategoryID,
                        principalTable: "ItemCategories",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ShopOrderedItemCategories",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    ItemCategoryID = table.Column<Guid>(type: "uuid", nullable: true),
                    ShopID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOrderedItemCategories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShopOrderedItemCategories_ItemCategories_ItemCategoryID",
                        column: x => x.ItemCategoryID,
                        principalTable: "ItemCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ShopOrderedItemCategories_Shops_ShopID",
                        column: x => x.ShopID,
                        principalTable: "Shops",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ShoppingLists",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    ShopID = table.Column<Guid>(type: "uuid", nullable: false),
                    RangeStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RangeEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastChanged = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ItemID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingLists", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShoppingLists_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ShoppingLists_Shops_ShopID",
                        column: x => x.ShopID,
                        principalTable: "Shops",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingListItem",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemID = table.Column<Guid>(type: "uuid", nullable: true),
                    ShoppingListID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShoppingListItem_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ShoppingListItem_ShoppingLists_ShoppingListID",
                        column: x => x.ShoppingListID,
                        principalTable: "ShoppingLists",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "ItemCategories",
                columns: new[] { "ID", "DateCreated", "LastChanged", "Name" },
                values: new object[,]
                {
                    { new Guid("1d18d1d8-ebaf-4c1d-9698-aacb2cb06ae1"), new DateTime(2023, 5, 23, 15, 8, 10, 696, DateTimeKind.Utc).AddTicks(6757), new DateTime(2023, 5, 23, 15, 8, 10, 696, DateTimeKind.Utc).AddTicks(6757), "Dairy products" },
                    { new Guid("9e2b00e6-023a-464d-baf5-b68e6302365e"), new DateTime(2023, 5, 23, 15, 8, 10, 696, DateTimeKind.Utc).AddTicks(6749), new DateTime(2023, 5, 23, 15, 8, 10, 696, DateTimeKind.Utc).AddTicks(6749), "Vegetables" },
                    { new Guid("a0c8cd9a-c2db-40ee-b648-3740a814ad3a"), new DateTime(2023, 5, 23, 15, 8, 10, 696, DateTimeKind.Utc).AddTicks(6754), new DateTime(2023, 5, 23, 15, 8, 10, 696, DateTimeKind.Utc).AddTicks(6754), "Meat" }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ID", "DiscountChain", "ItemCategoryID", "Latitude", "Longitude" },
                values: new object[,]
                {
                    { new Guid("3c173df0-317a-4287-a616-9b844d049dab"), 4, null, 0f, 0f },
                    { new Guid("d4fb61b7-42af-4e0b-b382-e9c8ee9a0021"), 0, null, 0f, 0f }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ID", "DateCreated", "ItemCategoryID", "LastChanged", "Name" },
                values: new object[,]
                {
                    { new Guid("3b4c22b9-c1d1-4e14-b3fb-cf19954d3e25"), new DateTime(2023, 5, 23, 15, 8, 10, 696, DateTimeKind.Utc).AddTicks(6769), new Guid("1d18d1d8-ebaf-4c1d-9698-aacb2cb06ae1"), new DateTime(2023, 5, 23, 15, 8, 10, 696, DateTimeKind.Utc).AddTicks(6769), "Eggs" },
                    { new Guid("9a2eb9ed-e3f5-4270-a5fc-1097f20f869a"), new DateTime(2023, 5, 23, 15, 8, 10, 696, DateTimeKind.Utc).AddTicks(6766), new Guid("a0c8cd9a-c2db-40ee-b648-3740a814ad3a"), new DateTime(2023, 5, 23, 15, 8, 10, 696, DateTimeKind.Utc).AddTicks(6766), "Beef" },
                    { new Guid("a7617465-fc92-489d-a71c-ee89d5b94d48"), new DateTime(2023, 5, 23, 15, 8, 10, 696, DateTimeKind.Utc).AddTicks(6760), new Guid("9e2b00e6-023a-464d-baf5-b68e6302365e"), new DateTime(2023, 5, 23, 15, 8, 10, 696, DateTimeKind.Utc).AddTicks(6761), "Potatoes" },
                    { new Guid("d9308ae9-3f34-4265-add6-6d4b91bfe46e"), new DateTime(2023, 5, 23, 15, 8, 10, 696, DateTimeKind.Utc).AddTicks(6772), new Guid("1d18d1d8-ebaf-4c1d-9698-aacb2cb06ae1"), new DateTime(2023, 5, 23, 15, 8, 10, 696, DateTimeKind.Utc).AddTicks(6773), "Eggs" }
                });

            migrationBuilder.InsertData(
                table: "ShopOrderedItemCategories",
                columns: new[] { "ID", "ItemCategoryID", "Order", "ShopID" },
                values: new object[,]
                {
                    { new Guid("2dde3a0d-4407-4d2c-92de-895a750fddc7"), new Guid("a0c8cd9a-c2db-40ee-b648-3740a814ad3a"), 0, new Guid("d4fb61b7-42af-4e0b-b382-e9c8ee9a0021") },
                    { new Guid("bd5f5ad2-e934-4436-8511-0b9ee8c1081e"), new Guid("1d18d1d8-ebaf-4c1d-9698-aacb2cb06ae1"), 0, new Guid("3c173df0-317a-4287-a616-9b844d049dab") },
                    { new Guid("c1c5ed19-0d1e-4656-bc12-1e50884c47f3"), new Guid("9e2b00e6-023a-464d-baf5-b68e6302365e"), 1, new Guid("d4fb61b7-42af-4e0b-b382-e9c8ee9a0021") }
                });

            migrationBuilder.InsertData(
                table: "ShoppingLists",
                columns: new[] { "ID", "Code", "DateCreated", "ItemID", "LastChanged", "RangeEnd", "RangeStart", "ShopID" },
                values: new object[] { new Guid("d428ffe0-a2f1-4735-b852-63304b6468e2"), "ABC", new DateTime(2023, 5, 23, 15, 8, 10, 696, DateTimeKind.Utc).AddTicks(6776), null, new DateTime(2023, 5, 23, 15, 8, 10, 696, DateTimeKind.Utc).AddTicks(6777), new DateTime(2023, 5, 23, 15, 8, 10, 696, DateTimeKind.Utc).AddTicks(6776), new DateTime(2023, 5, 23, 15, 8, 10, 696, DateTimeKind.Utc).AddTicks(6776), new Guid("d4fb61b7-42af-4e0b-b382-e9c8ee9a0021") });

            migrationBuilder.InsertData(
                table: "ShoppingListItem",
                columns: new[] { "ID", "ItemID", "ShoppingListID" },
                values: new object[,]
                {
                    { new Guid("04cd11b7-44fb-410a-9036-e7c339432ba2"), new Guid("a7617465-fc92-489d-a71c-ee89d5b94d48"), new Guid("d428ffe0-a2f1-4735-b852-63304b6468e2") },
                    { new Guid("2abd590b-5988-4349-b6e3-b5e4af385951"), new Guid("9a2eb9ed-e3f5-4270-a5fc-1097f20f869a"), new Guid("d428ffe0-a2f1-4735-b852-63304b6468e2") },
                    { new Guid("4b2f3b99-f8ff-436a-9660-95d4e6afc967"), new Guid("d9308ae9-3f34-4265-add6-6d4b91bfe46e"), new Guid("d428ffe0-a2f1-4735-b852-63304b6468e2") },
                    { new Guid("c490e1f8-0705-4a62-83d3-7acbe349a141"), new Guid("3b4c22b9-c1d1-4e14-b3fb-cf19954d3e25"), new Guid("d428ffe0-a2f1-4735-b852-63304b6468e2") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemCategoryID",
                table: "Items",
                column: "ItemCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrderedItemCategories_ItemCategoryID",
                table: "ShopOrderedItemCategories",
                column: "ItemCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrderedItemCategories_ShopID",
                table: "ShopOrderedItemCategories",
                column: "ShopID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItem_ItemID",
                table: "ShoppingListItem",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItem_ShoppingListID",
                table: "ShoppingListItem",
                column: "ShoppingListID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_ItemID",
                table: "ShoppingLists",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_ShopID",
                table: "ShoppingLists",
                column: "ShopID");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_ItemCategoryID",
                table: "Shops",
                column: "ItemCategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopOrderedItemCategories");

            migrationBuilder.DropTable(
                name: "ShoppingListItem");

            migrationBuilder.DropTable(
                name: "ShoppingLists");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "ItemCategories");
        }
    }
}
