﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetClinic.DAL.Migrations
{
    public partial class addNormalizedNametoRoleEntityConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("396f1365-f763-4f2a-a873-fdbef1c12ba3"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "NormalizedName", "UpdatedAt" },
                values: new object[] { "fd473cc4-eca5-4dad-bbaa-580102c6fe75", new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc), "Admin", new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("85300f9e-e1e5-423f-a759-059e4a6a7f3a"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "NormalizedName", "UpdatedAt" },
                values: new object[] { "10ed275a-1800-4383-ab7d-352fe0d863c2", new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc), "Client", new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("328b1872-1141-47f5-8f67-62c50562ad39"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc), new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc), new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("de1e6cc5-3e62-4459-9496-8a5fc0b2593f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc), new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: new Guid("0605974a-977c-4739-aa55-7e26e4eb2422"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc), new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: new Guid("13109317-ea78-4274-ad6e-e9a159f7f2f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc), new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: new Guid("a160449b-fb70-4991-9ddb-918b707829a8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc), new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: new Guid("c9a68d44-b5b8-4b96-9558-b4e52e750987"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc), new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: new Guid("f4dc2dab-9477-4ebe-8fb2-40306e739dee"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc), new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("01b2b3b3-0f43-49c1-a138-dd39d76bb65a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc), new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("2b513574-cabc-41ce-9fbc-e67255b84431"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc), new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("fb29bcb5-4493-4b03-b18e-11c50c650621"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc), new DateTime(2023, 6, 15, 5, 27, 36, 0, DateTimeKind.Utc) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("396f1365-f763-4f2a-a873-fdbef1c12ba3"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "NormalizedName", "UpdatedAt" },
                values: new object[] { "99954212-7546-496e-bfd4-20fbbb6e66bd", new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc), null, new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("85300f9e-e1e5-423f-a759-059e4a6a7f3a"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "NormalizedName", "UpdatedAt" },
                values: new object[] { "14938563-d80f-4edb-b8e4-5f382480f244", new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc), null, new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("328b1872-1141-47f5-8f67-62c50562ad39"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc), new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc), new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("de1e6cc5-3e62-4459-9496-8a5fc0b2593f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc), new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: new Guid("0605974a-977c-4739-aa55-7e26e4eb2422"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc), new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: new Guid("13109317-ea78-4274-ad6e-e9a159f7f2f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc), new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: new Guid("a160449b-fb70-4991-9ddb-918b707829a8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc), new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: new Guid("c9a68d44-b5b8-4b96-9558-b4e52e750987"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc), new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "PetTypes",
                keyColumn: "Id",
                keyValue: new Guid("f4dc2dab-9477-4ebe-8fb2-40306e739dee"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc), new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("01b2b3b3-0f43-49c1-a138-dd39d76bb65a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc), new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("2b513574-cabc-41ce-9fbc-e67255b84431"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc), new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("fb29bcb5-4493-4b03-b18e-11c50c650621"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc), new DateTime(2023, 6, 15, 4, 29, 18, 0, DateTimeKind.Utc) });
        }
    }
}