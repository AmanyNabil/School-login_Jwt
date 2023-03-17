using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagment_API.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "Schools",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "8f0274fd-8d89-4d08-9512-9283f43213ff", "amany@gmail.com", true, false, null, null, "amany", "AQAAAAEAACcQAAAAEBzanmaNRzPeIuOsv3xUS9z6Csrd+qikbnscA2lJprbIX0XOMHpWgj8IfDFJCgswcw==", null, false, "14e26e84-9b57-4024-a3f3-5afe5e909f4a", false, "amany" },
                    { "2", 0, "891654cd-2bca-4863-9177-ad512eaae961", "ahmed@gmail.com", true, false, null, null, "ahmed", "AQAAAAEAACcQAAAAEC6hg7q1eFwtb82YFzPZKEJyKN2yJCS/uzZ/cXCwxWovoJAMNEj9KGj+MzXeG27RbA==", null, false, "e3276266-4873-49ba-b661-bc5af895f24e", false, "ahmed" },
                    { "3", 0, "f801bc01-9a18-470a-9716-2639c5b3e42e", "amal@gmail.com", true, false, null, null, "amal", "AQAAAAEAACcQAAAAEMqtudsRDhpYxsKgc/RyniTVp9JcaDK1MIFv44cVDDFIYqSLL+yhaH8zIvk5BNe/fA==", null, false, "56c3a039-3b00-45c8-ab37-cc4134047737", false, "amal" },
                    { "4", 0, "e9f9c673-70eb-4077-b95e-44ff91b3c2ce", "heba@gmail.com", true, false, null, null, "heba", "AQAAAAEAACcQAAAAEOfPMslyhHXb/FWU5hg/0f/BC2tF04y5b/Avr7pOTJJwg4ZVssZz7Q6GVj692ZFWSA==", null, false, "a7dba93d-b3fb-4255-8734-a21e88e56027", false, "heba" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "0b66067a-ae03-4593-a04e-815d54e7dc44", "Admin", "ADMIN" },
                    { "2", "2ced9ea5-1627-4d74-87ea-683476dd1e35", "Normal", "NORMAL" }
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "id", "address", "name", "phone" },
                values: new object[,]
                {
                    { 1, "El-Sherouk", "School S1", "01234567890" },
                    { 2, "Madinaty", "School S2", "01287654390" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "id", "floor", "name", "schoolId" },
                values: new object[,]
                {
                    { 1, 1, "S1-C1", 1 },
                    { 2, 2, "S1-C2", 1 },
                    { 3, 3, "S1-C3", 1 },
                    { 4, 1, "S2-C1", 2 },
                    { 5, 2, "S2-C2", 2 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "schoolId" },
                values: new object[,]
                {
                    { "1", 1 },
                    { "2", 1 },
                    { "3", 2 },
                    { "4", 2 }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "2" },
                    { "1", "3" },
                    { "2", "4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schools_name",
                table: "Schools",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schools_phone",
                table: "Schools",
                column: "phone",
                unique: true,
                filter: "[phone] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_name_schoolId",
                table: "Classes",
                columns: new[] { "name", "schoolId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Schools_name",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Schools_phone",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Classes_name_schoolId",
                table: "Classes");

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "2" });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "3" });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
