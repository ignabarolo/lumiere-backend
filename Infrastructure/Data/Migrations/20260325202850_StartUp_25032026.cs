using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class StartUp_25032026 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cinema",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modified_by = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    state = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cinema", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "movie",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    duration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    genre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    classification = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modified_by = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    state = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_movie", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    last_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modified_by = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    state = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "room",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    room_number = table.Column<int>(type: "integer", nullable: false),
                    capacity = table.Column<int>(type: "integer", nullable: false),
                    cinema_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modified_by = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    state = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_room", x => x.id);
                    table.ForeignKey(
                        name: "fk_room_cinema_cinema_id",
                        column: x => x.cinema_id,
                        principalTable: "cinema",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "screening",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    room_id = table.Column<Guid>(type: "uuid", nullable: false),
                    movie_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modified_by = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    state = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_screening", x => x.id);
                    table.ForeignKey(
                        name: "fk_screening_movie_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_screening_room_room_id",
                        column: x => x.room_id,
                        principalTable: "room",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "seat",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    row = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    column = table.Column<int>(type: "integer", nullable: false),
                    room_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modified_by = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    state = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_seat", x => x.id);
                    table.ForeignKey(
                        name: "fk_seat_room_room_id",
                        column: x => x.room_id,
                        principalTable: "room",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "booking",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    total = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    payment_method = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    screening_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modified_by = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    state = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_booking", x => x.id);
                    table.ForeignKey(
                        name: "fk_booking_screening_screening_id",
                        column: x => x.screening_id,
                        principalTable: "screening",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_booking_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "cinema",
                columns: new[] { "id", "address", "created", "created_by", "modified", "modified_by", "state" },
                values: new object[] { new Guid("a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6"), "Av. Arístides Villanueva 123, Mendoza", new DateTime(2026, 3, 25, 12, 0, 0, 0, DateTimeKind.Utc), "SeedUser", new DateTime(2026, 3, 25, 12, 0, 0, 0, DateTimeKind.Utc), "SeedUser", 1 });

            migrationBuilder.InsertData(
                table: "movie",
                columns: new[] { "id", "classification", "created", "created_by", "duration", "genre", "modified", "modified_by", "state", "title" },
                values: new object[] { new Guid("c3d4e5f6-a7b8-49c0-d1e2-f3a4b5c6d7e8"), "PG-13", new DateTime(2026, 3, 25, 12, 0, 0, 0, DateTimeKind.Utc), "SeedUser", new TimeSpan(0, 2, 49, 0, 0), "Sci-Fi", new DateTime(2026, 3, 25, 12, 0, 0, 0, DateTimeKind.Utc), "SeedUser", 1, "Interstellar" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "address", "created", "created_by", "first_name", "last_name", "modified", "modified_by", "phone", "state" },
                values: new object[] { new Guid("f2a3b4c5-d6e7-48a9-b0c1-d2e3f4a5b6c7"), "Mendoza, Argentina", new DateTime(2026, 3, 25, 12, 0, 0, 0, DateTimeKind.Utc), "SeedUser", "Ignacio", "Dev", new DateTime(2026, 3, 25, 12, 0, 0, 0, DateTimeKind.Utc), "SeedUser", "2615551234", 1 });

            migrationBuilder.InsertData(
                table: "room",
                columns: new[] { "id", "capacity", "cinema_id", "created", "created_by", "modified", "modified_by", "room_number", "state" },
                values: new object[] { new Guid("b2c3d4e5-f6a7-48b9-c0d1-e2f3a4b5c6d7"), 50, new Guid("a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6"), new DateTime(2026, 3, 25, 12, 0, 0, 0, DateTimeKind.Utc), "SeedUser", new DateTime(2026, 3, 25, 12, 0, 0, 0, DateTimeKind.Utc), "SeedUser", 1, 1 });

            migrationBuilder.InsertData(
                table: "screening",
                columns: new[] { "id", "created", "created_by", "end_date", "modified", "modified_by", "movie_id", "room_id", "start_date", "state" },
                values: new object[] { new Guid("d4e5f6a7-b8c9-40d1-e2f3-a4b5c6d7e8f9"), new DateTime(2026, 3, 25, 12, 0, 0, 0, DateTimeKind.Utc), "SeedUser", new DateTime(2026, 3, 26, 15, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 25, 12, 0, 0, 0, DateTimeKind.Utc), "SeedUser", new Guid("c3d4e5f6-a7b8-49c0-d1e2-f3a4b5c6d7e8"), new Guid("b2c3d4e5-f6a7-48b9-c0d1-e2f3a4b5c6d7"), new DateTime(2026, 3, 26, 12, 0, 0, 0, DateTimeKind.Utc), 1 });

            migrationBuilder.InsertData(
                table: "seat",
                columns: new[] { "id", "column", "created", "created_by", "modified", "modified_by", "room_id", "row", "state" },
                values: new object[] { new Guid("f6a7b8c9-d0e1-42f2-a3b4-c5d6e7f8a9b0"), 5, new DateTime(2026, 3, 25, 12, 0, 0, 0, DateTimeKind.Utc), "SeedUser", new DateTime(2026, 3, 25, 12, 0, 0, 0, DateTimeKind.Utc), "SeedUser", new Guid("b2c3d4e5-f6a7-48b9-c0d1-e2f3a4b5c6d7"), "A", 1 });

            migrationBuilder.InsertData(
                table: "booking",
                columns: new[] { "id", "created", "created_by", "date", "modified", "modified_by", "payment_method", "screening_id", "state", "total", "user_id" },
                values: new object[] { new Guid("e5f6a7b8-c9d0-41e1-f2a3-b4c5d6e7f8a9"), new DateTime(2026, 3, 25, 12, 0, 0, 0, DateTimeKind.Utc), "SeedUser", new DateTime(2026, 3, 26, 12, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 25, 12, 0, 0, 0, DateTimeKind.Utc), "SeedUser", 1, new Guid("d4e5f6a7-b8c9-40d1-e2f3-a4b5c6d7e8f9"), 1, 4500.50m, new Guid("f2a3b4c5-d6e7-48a9-b0c1-d2e3f4a5b6c7") });

            migrationBuilder.CreateIndex(
                name: "ix_booking_screening_id",
                table: "booking",
                column: "screening_id");

            migrationBuilder.CreateIndex(
                name: "ix_booking_user_id",
                table: "booking",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_room_cinema_id",
                table: "room",
                column: "cinema_id");

            migrationBuilder.CreateIndex(
                name: "ix_screening_movie_id",
                table: "screening",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "ix_screening_room_id",
                table: "screening",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "ix_seat_room_id",
                table: "seat",
                column: "room_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "booking");

            migrationBuilder.DropTable(
                name: "seat");

            migrationBuilder.DropTable(
                name: "screening");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "movie");

            migrationBuilder.DropTable(
                name: "room");

            migrationBuilder.DropTable(
                name: "cinema");
        }
    }
}
