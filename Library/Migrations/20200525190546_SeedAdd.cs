using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class SeedAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BirthDate", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(1965, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Георг", "Кельвінгтон" },
                    { 2, new DateTime(1873, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Фрідріх", "Ніцше" },
                    { 3, new DateTime(1983, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Себастьян", "Крудз" },
                    { 4, new DateTime(1878, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Фредеріка", "Крудз" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Том в Гренландії" },
                    { 2, "Філософія думок" },
                    { 3, "Останній листок" }
                });

            migrationBuilder.InsertData(
                table: "ReaderCards",
                columns: new[] { "Id", "Age", "DateOfRegistration", "Email", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, 17, new DateTime(2018, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "pupkin_v@gmail.com", "Василій", "Пупкін" },
                    { 2, 19, new DateTime(2016, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "koz_a@gmail.com", "Анастасія", "Козаченко" },
                    { 3, 24, new DateTime(2019, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "vitalii_dziuba@gmail.com", "Віталій", "Дзюба" }
                });

            migrationBuilder.InsertData(
                table: "AuthorBooks",
                columns: new[] { "Id", "AuthorId", "BookId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 2 },
                    { 4, 3, 3 },
                    { 5, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Chapters",
                columns: new[] { "Id", "BookId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Вступ" },
                    { 2, 1, "Пригоди тома" },
                    { 3, 1, "Завершення історії" },
                    { 4, 2, "Усе починається з думки" },
                    { 5, 2, "Думай серцем" },
                    { 6, 3, "Холодна осінь" },
                    { 7, 3, "Опале листя" }
                });

            migrationBuilder.InsertData(
                table: "Readers",
                columns: new[] { "Id", "ReaderCardId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "Id", "BookId", "DateOfReceiving", "ReaderId" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2019, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 1, new DateTime(2020, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 2, new DateTime(2019, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, 3, new DateTime(2019, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 1, new DateTime(2019, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AuthorBooks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Records",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Records",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Records",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Records",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Records",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Readers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ReaderCards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReaderCards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReaderCards",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
