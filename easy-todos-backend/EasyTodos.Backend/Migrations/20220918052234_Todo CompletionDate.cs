using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class TodoCompletionDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "Todos");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2022, 9, 18, 13, 22, 34, 542, DateTimeKind.Unspecified).AddTicks(8398), new TimeSpan(0, 8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2022, 9, 11, 18, 24, 27, 759, DateTimeKind.Unspecified).AddTicks(689), new TimeSpan(0, 8, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Todos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2022, 9, 18, 13, 22, 34, 542, DateTimeKind.Unspecified).AddTicks(8644), new TimeSpan(0, 8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2022, 9, 11, 18, 24, 27, 759, DateTimeKind.Unspecified).AddTicks(1103), new TimeSpan(0, 8, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CompletionDate",
                table: "Todos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "Ordinal",
                table: "Todos",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompletionDate",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "Ordinal",
                table: "Todos");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2022, 9, 11, 18, 24, 27, 759, DateTimeKind.Unspecified).AddTicks(689), new TimeSpan(0, 8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2022, 9, 18, 13, 22, 34, 542, DateTimeKind.Unspecified).AddTicks(8398), new TimeSpan(0, 8, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Todos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2022, 9, 11, 18, 24, 27, 759, DateTimeKind.Unspecified).AddTicks(1103), new TimeSpan(0, 8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2022, 9, 18, 13, 22, 34, 542, DateTimeKind.Unspecified).AddTicks(8644), new TimeSpan(0, 8, 0, 0, 0)));

            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "Todos",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
