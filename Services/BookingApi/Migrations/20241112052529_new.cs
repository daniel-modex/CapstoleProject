using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApi.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CancallationResponse",
                table: "BookingResponse",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BookingResponse",
                table: "BookingDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BookingSuccessful",
                table: "BookingDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "BookingDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PaymetSuccessful",
                table: "BookingDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancallationResponse",
                table: "BookingResponse");

            migrationBuilder.DropColumn(
                name: "BookingResponse",
                table: "BookingDetails");

            migrationBuilder.DropColumn(
                name: "BookingSuccessful",
                table: "BookingDetails");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "BookingDetails");

            migrationBuilder.DropColumn(
                name: "PaymetSuccessful",
                table: "BookingDetails");
        }
    }
}
