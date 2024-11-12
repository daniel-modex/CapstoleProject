using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApi.Migrations
{
    /// <inheritdoc />
    public partial class new1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookingSuccessful",
                table: "BookingDetails",
                newName: "ServiceProviderResponse");

            migrationBuilder.RenameColumn(
                name: "BookingResponse",
                table: "BookingDetails",
                newName: "CancelationConfirmed");

            migrationBuilder.AddColumn<bool>(
                name: "BookingRequestedSuccessfully",
                table: "BookingDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingRequestedSuccessfully",
                table: "BookingDetails");

            migrationBuilder.RenameColumn(
                name: "ServiceProviderResponse",
                table: "BookingDetails",
                newName: "BookingSuccessful");

            migrationBuilder.RenameColumn(
                name: "CancelationConfirmed",
                table: "BookingDetails",
                newName: "BookingResponse");
        }
    }
}
