using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetClinic.DAL.Migrations
{
    public partial class makefieldnullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Reviews_ReviewId",
                table: "Appointments");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReviewId",
                table: "Appointments",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("328b1872-1141-47f5-8f67-62c50562ad39"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 13, 8, 39, 43, 0, DateTimeKind.Utc), new DateTime(2023, 6, 13, 8, 39, 43, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 13, 8, 39, 43, 0, DateTimeKind.Utc), new DateTime(2023, 6, 13, 8, 39, 43, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("de1e6cc5-3e62-4459-9496-8a5fc0b2593f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 13, 8, 39, 43, 0, DateTimeKind.Utc), new DateTime(2023, 6, 13, 8, 39, 43, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: new Guid("0605974a-977c-4739-aa55-7e26e4eb2422"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 13, 8, 39, 43, 0, DateTimeKind.Utc), new DateTime(2023, 6, 13, 8, 39, 43, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: new Guid("13109317-ea78-4274-ad6e-e9a159f7f2f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 13, 8, 39, 43, 0, DateTimeKind.Utc), new DateTime(2023, 6, 13, 8, 39, 43, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: new Guid("a160449b-fb70-4991-9ddb-918b707829a8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 13, 8, 39, 43, 0, DateTimeKind.Utc), new DateTime(2023, 6, 13, 8, 39, 43, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: new Guid("c9a68d44-b5b8-4b96-9558-b4e52e750987"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 13, 8, 39, 43, 0, DateTimeKind.Utc), new DateTime(2023, 6, 13, 8, 39, 43, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: new Guid("f4dc2dab-9477-4ebe-8fb2-40306e739dee"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 13, 8, 39, 43, 0, DateTimeKind.Utc), new DateTime(2023, 6, 13, 8, 39, 43, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("01b2b3b3-0f43-49c1-a138-dd39d76bb65a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 13, 8, 39, 43, 0, DateTimeKind.Utc), new DateTime(2023, 6, 13, 8, 39, 43, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("2b513574-cabc-41ce-9fbc-e67255b84431"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 13, 8, 39, 43, 0, DateTimeKind.Utc), new DateTime(2023, 6, 13, 8, 39, 43, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("fb29bcb5-4493-4b03-b18e-11c50c650621"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 13, 8, 39, 43, 0, DateTimeKind.Utc), new DateTime(2023, 6, 13, 8, 39, 43, 0, DateTimeKind.Utc) });

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Reviews_ReviewId",
                table: "Appointments",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Reviews_ReviewId",
                table: "Appointments");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReviewId",
                table: "Appointments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("328b1872-1141-47f5-8f67-62c50562ad39"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc), new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc), new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("de1e6cc5-3e62-4459-9496-8a5fc0b2593f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc), new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: new Guid("0605974a-977c-4739-aa55-7e26e4eb2422"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc), new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: new Guid("13109317-ea78-4274-ad6e-e9a159f7f2f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc), new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: new Guid("a160449b-fb70-4991-9ddb-918b707829a8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc), new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: new Guid("c9a68d44-b5b8-4b96-9558-b4e52e750987"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc), new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: new Guid("f4dc2dab-9477-4ebe-8fb2-40306e739dee"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc), new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("01b2b3b3-0f43-49c1-a138-dd39d76bb65a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc), new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("2b513574-cabc-41ce-9fbc-e67255b84431"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc), new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("fb29bcb5-4493-4b03-b18e-11c50c650621"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc), new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc) });

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Reviews_ReviewId",
                table: "Appointments",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
