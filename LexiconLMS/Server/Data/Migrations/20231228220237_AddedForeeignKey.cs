using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconLMS.App.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedForeeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_ActivityType_TypeId",
                table: "Activity");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Activity",
                newName: "ActivityTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Activity_TypeId",
                table: "Activity",
                newName: "IX_Activity_ActivityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_ActivityType_ActivityTypeId",
                table: "Activity",
                column: "ActivityTypeId",
                principalTable: "ActivityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_ActivityType_ActivityTypeId",
                table: "Activity");

            migrationBuilder.RenameColumn(
                name: "ActivityTypeId",
                table: "Activity",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Activity_ActivityTypeId",
                table: "Activity",
                newName: "IX_Activity_TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_ActivityType_TypeId",
                table: "Activity",
                column: "TypeId",
                principalTable: "ActivityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
